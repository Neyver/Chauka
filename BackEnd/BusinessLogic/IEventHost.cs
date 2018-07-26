namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public interface IEventHost
    {
        IUserRepository<User> Repository { get; set; }

        IEventsRepository<Event> EventRepository { get; set; }

        IResult<Account> Authentication(string accountName);

        IResult<UserEvent> GetUserEvents(int userId);        
    }
}
