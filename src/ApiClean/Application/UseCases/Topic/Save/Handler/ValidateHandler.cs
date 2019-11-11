﻿using Application.UseCases.Repository.Handler;
using System;

namespace Application.UseCases.Topic.Save.Handler
{
    public class ValidateHandler : Handler<TopicSaveRequest>
    {
        public override void ProcessRequest(TopicSaveRequest request)
        {
            if (!request.Topic.IsValid)
                throw new ArgumentException("Model invalid");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}