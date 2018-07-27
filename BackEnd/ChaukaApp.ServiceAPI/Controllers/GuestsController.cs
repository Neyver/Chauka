namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class GuestsController : ApiController
    {
        // GET api/events
        public IResult<EventGuests> Get(int eventId)
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            IEventHost eventHost = new EventHost();
            try
            {
                //resultEvent = eventHost.GetGuests(eventId);
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
