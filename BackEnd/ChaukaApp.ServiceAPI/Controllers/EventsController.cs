namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class EventsController : ApiController
    {
        [HttpGet]
        [Route("api/v1/accounts/{userId}/events")]
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

        //[Route("api/v1/events/{eventId}/guests")]
        // GET api/events?eventId=1
        [HttpGet]
        public IResult<Event> GetEvent(int eventId)
        {
            IResult<Event> resultEvent = new ResultEntity<Event>();
            try
            {
                IEventHost eventHost = new EventHost();

                resultEvent = eventHost.GetEvent(eventId);
            }
            catch (Exception)
            {
                resultEvent.Success = false;
                resultEvent.Message = "The service could not respond to your request";
            }

            return resultEvent;
        }

        public ResultSimplified Post(Event newEvent)
        {
            ResultSimplified resultRegister;
            try
            {
                IEventHost eventHost = new EventHost();
                resultRegister = eventHost.RegisterEvent(newEvent);
            }
            catch (Exception)
            {
                resultRegister = new ResultSimplified();
                resultRegister.Success = false;
                resultRegister.Message = "The service could not respond to your request";
            }

            return resultRegister;
        }
    }
}
