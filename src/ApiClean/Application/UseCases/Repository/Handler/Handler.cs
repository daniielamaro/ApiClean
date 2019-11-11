namespace Application.UseCases.User.Save.Handlers
{
    public abstract class Handler<A>
    {
        protected Handler<A> Sucessor;

        public void SetSucessor(Handler<A> sucessor)
        {
            Sucessor = sucessor;
        }

        public abstract void ProcessRequest(A request);
    }
}
