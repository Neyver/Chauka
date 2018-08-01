namespace ChaukaApp.ServiceAPI.Controllers
{
    using BusinessLogic;
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;
    using System.Web.Http;

    public class AccountsController : ApiController
    {
        [HttpGet]
        [Route("api/v1/accounts/{accountName}")]
        public IResult<Account> GetAccounts(string accountName)
        {
            IUserAuthenticator userVerifier = new UserAuthenticator();
            IUserRepository<User> userRepository = new UserRepository();
            userVerifier.Repository = userRepository;
            return userVerifier.Authentication(accountName);
        }

        [HttpPut]
        [Route("api/v1/accounts/user")]
        public void UpdateGoogleMapPosition([FromBody] User user)
        {
            IMapPositioner positioner = new MapPositioner();
            var result = positioner.UpdateUserPosition(user);
        }
    }
}
