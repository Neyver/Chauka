namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class GuestsController : ApiController
    {
        // POST api/guests
        [HttpPost]
        [Route("api/v1/guests")]
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
