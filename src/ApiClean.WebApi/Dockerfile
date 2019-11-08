FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["../ApiClean.WebApi/ApiClean.WebApi.csproj", "../ApiClean.WebApi/"]
RUN dotnet restore "../ApiClean.WebApi/ApiClean.WebApi.csproj"
COPY . .
WORKDIR "/src/../ApiClean.WebApi"
RUN dotnet build "ApiClean.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ApiClean.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ApiClean.WebApi.dll"]