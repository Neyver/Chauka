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
        public IResult<EventGuests> Get(int userId)
        {
            IResult<EventGuests> resultEvent = new ResultEntity<EventGuests>();
            return resultEvent;
        }
    }
}
