namespace ChaukaApp.ServiceAPI.Controllers
{
    using System.Web.Http;
    using BusinessLogic;
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class AccountsController : ApiController
    {
        // GET api/accounts
        public IResult<Account> Get(string username)
        {
            IUserVerifier userVerifier = new UserVerifier();
            IUserRepository<User> userRepository = new UserRepository();
            userVerifier.Repository = userRepository;
            return userVerifier.Authentication(username);
        }
    }
}
