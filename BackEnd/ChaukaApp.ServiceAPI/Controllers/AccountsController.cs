namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
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
        public IResult<Account> Get(string accountName)
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


        [HttpGet]
        [Route("api/v1/accounts/{userId}/events")]
        public IResult<UserEvent> GetEventsByUser(int userId)
        {
            IResult<UserEvent> resultEvent = new ResultEvents();
            IEventHost userVerifier = new EventHost();

            try
            {
                resultEvent = userVerifier.GetUserEvents(userId);
            }
            catch (Exception)
            {
                resultEvent.Success = false;
                resultEvent.Message = "The service could not respond to your request";
            }

            return resultEvent;
        }
    }
}
