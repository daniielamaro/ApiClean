namespace Application.UseCases.User.Get
{
    public interface IUserGetUseCase
    {
        void Execute(UserGetRequest request);
        Domain.User.User GetObject(UserGetRequest request);
    }
}
