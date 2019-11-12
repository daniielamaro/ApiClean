using System;
using Application.UseCases.Repository.Handler;
using System.Text;
using ApiClean.Application.Repositories;

namespace ApiClean.Application.UseCases.Comment.Save.Handlers
{
    public class SaveHandler : Handler<CommentSaveRequest>
    {
        private readonly ICommentWriteOnlyRepository commentWriteOnlyRepository;

        public SaveHandler(ICommentWriteOnlyRepository commentWriteOnlyRepository)
        {
            this.commentWriteOnlyRepository = commentWriteOnlyRepository;
        }

        public override void ProcessRequest(CommentSaveRequest request)
        {
            var ret = commentWriteOnlyRepository.Save(request.Comment);
            if (ret == 0)
                throw new ArgumentException("Problem to save model");

            if (sucessor != null)
                sucessor.ProcessRequest(request);
        }
    }
}
