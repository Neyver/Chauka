namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class EventsController : ApiController
    {
        // GET api/events?eventId=1
        [HttpGet]
        [Route("api/v1/events/{eventId}")]
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
