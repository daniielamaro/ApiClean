namespace ApiClean.Application.UseCases.User.Delete
{
    public interface IUserDeleteUseCase
    {
        void Execute(UserDeleteRequest request);
    }
}
