namespace Application.UseCases.Repository.Handler
{
    public abstract class Handler<T>
    {
        protected Handler<T> Sucessor;

        public void SetSucessor(Handler<T> sucessor)
        {
            Sucessor = sucessor;
        }

        public abstract void ProcessRequest(T request);
    }
}
