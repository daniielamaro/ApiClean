using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NSwag;
using WebApi.Modules;
using WebApi.Swagger;

[assembly: ApiConventionType(typeof(ApiConventions))]

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer (ContainerBuilder builder)
        {
            builder.RegisterModule(new ConfigurationModule(Configuration));
        }
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerDocument(document =>
            {
                document.Title = "WebApi Alfa Bravo";
                document.Version = "v1";
                document.PostProcess = s =>
                {
                    s.Paths.ToList().ForEach(p =>
                    {
                        p.Value.Parameters.Add(
                        new OpenApiParameter()
                        {
                            Kind = OpenApiParameterKind.Header,
                            Type = NJsonSchema.JsonObjectType.String,
                            IsRequired = false,
                            Name = "Accept-Language",
                            Description = "pt-BR or en-US",
                            Default = "pt-BR"
                        });
                    });
                };
            });

            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            builder.RegisterModule<Infrastructure.PostgresDataAccess.Module>();
            builder.RegisterModule<InfrastructureDefaultModule>();
            builder.RegisterModule<WebApiModule>();
            builder.Populate(services);

            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseOpenApi(config =>
            {
                config.PostProcess = (document, request) =>
                {
                    document.Host = ExtractHost(request);
                    document.BasePath = ExtractPath(request);
                    document.Schemes.Clear();
                };
            });

            app.UseSwaggerUi3(config => config.TransformToExternalPath = (route, request) => ExtractPath(request) + route);            
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseRewriter(option);
        }

        private string ExtractHost(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Host") ?
                new Uri($"{ExtractProto(request)}://{request.Headers["X-Forwarded-Host"].First()}").Host :
                    request.Host.Value;

         private string ExtractProto(HttpRequest request) =>
            request.Headers["X-Forwarded-Proto"].FirstOrDefault() ?? request.Protocol;

        private string ExtractPath(HttpRequest request) =>
            request.Headers.ContainsKey("X-Forwarded-Prefix") ?
                request.Headers["X-Forwarded-Prefix"].FirstOrDefault() :
                string.Empty;
    }
}
