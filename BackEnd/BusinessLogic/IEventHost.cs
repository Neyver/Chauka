namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public interface IEventHost
    {
        IUserRepository<User> Repository { get; set; }

        IEventsRepository<Event> EventRepository { get; set; }

        IResult<Event> GetEvent(int eventId);

        IResult<UserEvent> GetUserEvents(int userId);

        ResultSimplified RegisterEvent(Event newEvent);

        IResult<EventGuests> GetGuestList(int eventId);

        ResultSimplified InviteGuest(Guest guest);
    }
}
