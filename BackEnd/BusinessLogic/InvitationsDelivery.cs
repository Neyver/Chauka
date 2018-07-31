namespace BusinessLogic
{
    using System.Collections.Generic;
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

        public IResult<EventsInvitation> GetInvitations(int userId)
        {
            IResult<EventsInvitation> eventsResult = new ResultEntity<EventsInvitation>();
            EventsInvitation responseEvents = new EventsInvitation();
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

            List<InvitationData> events = new List<InvitationData>();
            var eventList = this.GuestRepository.GetGuestsByUserId(userId);
            foreach (var item in eventList)
            {
                Event theEvent = this.EventRepository.GetById(item.EventId);
                InvitationData invitation = new InvitationData()
                {
                    EventId = item.EventId,
                    GuestId = item.Id,
                    NameEvent = theEvent.NameEvent,
                    StartDatetime = theEvent.StartDatetime
                };
                events.Add(invitation);
            }
            ////DATA 
            responseEvents.UserId = userId;
            responseEvents.Events = events;
            eventsResult.Data = responseEvents;
            eventsResult.Message = "Successful Data.";
            eventsResult.Success = true;

            return eventsResult;
        }
    }
}
