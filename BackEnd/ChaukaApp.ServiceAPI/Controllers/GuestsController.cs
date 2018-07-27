namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class GuestsController : ApiController
    {
        // GET api/guests?eventId=1
        public IResult<EventGuests> Get(int eventId)
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            IEventHost eventHost = new EventHost();
            try
            {
                resultEvent = eventHost.GetGuestList(eventId);
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
