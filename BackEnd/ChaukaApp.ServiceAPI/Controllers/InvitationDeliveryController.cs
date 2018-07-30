
namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using Model.Object;
    using Model.Result;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Http;
    using BusinessLogic;

    public class InvitationDeliveryController : ApiController
    {
        public IResult<Event> GetInvitations(int userId)
        {
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            IResult<Event> resultEvent = new ResultEntity<Event>();
            try
            {
                resultEvent = invitationsDelivery.GetInvitations(userId);
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
