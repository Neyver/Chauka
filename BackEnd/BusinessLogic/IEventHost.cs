namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;
    using System.Collections.Generic;

    public interface IEventHost
    {
        IUserRepository<User> Repository { get; set; }

        IEventsRepository<Event> EventRepository { get; set; }

        IResult<Event> GetEvent(int eventId);

        IResult<UserEvent> GetUserEvents(int userId);

        ResultSimplified RegisterEvent(Event newEvent);

        IResult<EventGuests> GetGuestList(int eventId);
    }
}
