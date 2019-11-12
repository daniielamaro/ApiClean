﻿namespace ApiClean.Application.UseCases.Repository.Handler
{
    public abstract class Handler<T>
    {
        protected Handler<T> sucessor;

        public void SetSucessor(Handler<T> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(T request);
    }
}
