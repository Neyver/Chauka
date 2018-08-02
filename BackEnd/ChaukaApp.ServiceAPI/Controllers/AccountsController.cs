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
        [HttpGet]
        [Route("api/v1/accounts/{accountName}")]
        // GET api/accounts
        public IResult<Account> Get(string accountName)
        {
            IUserAuthenticator userVerifier = new UserAuthenticator();
            IUserRepository<User> userRepository = new UserRepository();
            userVerifier.Repository = userRepository;
            return userVerifier.Authentication(accountName);
        }

        //[HttpPut]
        //[Route("api/v1/accounts/user")]        
        // PATCH: api/accounts/
        [HttpPatch]
        public void UpdateGoogleMapPosition([FromBody] User user)
        {
            IMapPositioner positioner = new MapPositioner();
            var result = positioner.UpdateUserPosition(user);
        }
    }
}
