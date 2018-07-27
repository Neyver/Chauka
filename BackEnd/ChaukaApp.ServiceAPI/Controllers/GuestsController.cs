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

        // POST api/guests
        public ResultSimplified Post(Guest guest)
        {
            ResultSimplified result = new ResultSimplified();
            
            try
            {
                IEventHost eventHost = new EventHost();
                result = eventHost.InviteGuest(guest);
            }
            catch (Exception)
            {
                result.Success = false;
                result.Message = "The service could not respond to your request";
            }

            return result;
        }
    }
}
