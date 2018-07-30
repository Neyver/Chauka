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

        public IResult<Event> GetInvitations(int userId)
        {
            IResult<Event> eventsResult = new ResultEntity<Event>();
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
            ////eventsResult.Data = this.GuestRepository.GetEventsByUserId(userId);
            eventsResult.Message = "Successful Data.";
            eventsResult.Success = true;

            return eventsResult;
        }
    }
}
