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

        public ResultSimplified Patch(Guest guest)
        {
            ResultSimplified result = new ResultSimplified();

            try
            {
                IInvitationsDelivery invitationsDelivery = new InvitationsDelivery();
                //result = invitationsDelivery.Change(guest);
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
