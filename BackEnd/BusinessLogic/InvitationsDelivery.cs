namespace BusinessLogic
{
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class InvitationsDelivery : IInvitationsDelivery
    {
        public InvitationsDelivery()
        {
            this.UserRepository = new UserRepository();
            this.EventRepository = new EventsRepository();
            this.GuestRepository = new GuestRepository();
        }

        public IGuestRepository<Guest> GuestRepository { get; set; }

        public IUserRepository<User> UserRepository { get; set; }

        public IEventsRepository<Event> EventRepository { get; set; }

        public IResult<UserEvent> GetInvitations(int userId)
        {
            IResult<UserEvent> eventsResult = new ResultEntity<UserEvent>();
            UserEvent userResponse = new UserEvent();
            if (userId <= 0)
            {
                eventsResult.Message = "The user ID is not valid.";
                eventsResult.Success = false;
                return eventsResult;
            }

            if (this.UserRepository.GetById(userId) == null)
            {
                eventsResult.Message = "User not found.";
                eventsResult.Success = false;
                return eventsResult;
            }
            ////DATA 
            ////userResponse.Events = this.GuestRepository.GetEventsByUserId(userId);
            userResponse.UserId = userId;
            eventsResult.Data = userResponse;
            eventsResult.Message = "Successful Data.";
            eventsResult.Success = true;

            return eventsResult;
        }
    }
}
