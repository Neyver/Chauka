namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class EventsController : ApiController
    {
        // GET api/events
        public IResult<UserEvent> Get(int userId)
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
