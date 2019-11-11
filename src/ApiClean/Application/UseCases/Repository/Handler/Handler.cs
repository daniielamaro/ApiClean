namespace Application.UseCases.Repository.Handler
{
    public abstract class Handler<A>
    {
        protected Handler<A> sucessor;

        public void SetSucessor(Handler<A> sucessor)
        {
            this.sucessor = sucessor;
        }

        public abstract void ProcessRequest(A request);
    }
}
