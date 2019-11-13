namespace ApiClean.Application.UseCases.User.Get
{
    public interface IUserGetUseCase
    {
        void Execute(UserGetRequest request);
    }
}
