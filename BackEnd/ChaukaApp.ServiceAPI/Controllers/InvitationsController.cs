namespace ChaukaApp.ServiceAPI.Controllers
{
    using System;
    using System.Web.Http;
    using BusinessLogic;
    using Model.Object;
    using Model.Result;

    public class InvitationsController : ApiController
    {
        // GET api/invitations?userId=1
        public IResult<UserEvent> Get(int userId)
        {
            IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
            IResult<UserEvent> resultEvent = new ResultEntity<UserEvent>();
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
