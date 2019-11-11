using ApiClean.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Topic.Save.Handler
{
    class SaveHandler : Handler<TopicSaveRequest>
    {
        private readonly ITopicWriteOnlyRepository topicWriteOnlyRepository;

        public SaveHandler(ITopicWriteOnlyRepository topicWriteOnlyRepository)
        {
            this.topicWriteOnlyRepository = topicWriteOnlyRepository;
        }

        public override void ProcessRequest(TopicSaveRequest request)
        {
            var ret = topicWriteOnlyRepository.Save(request.Topic);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
