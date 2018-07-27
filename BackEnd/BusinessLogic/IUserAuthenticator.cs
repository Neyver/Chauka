namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public interface IUserAuthenticator
    {
        IUserRepository<User> Repository { get; set; }

        IResult<Account> Authentication(string accountName);
    }
}
