namespace BusinessLogic
{
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class EventHost : IEventHost
    {
        public IUserRepository<User> Repository { get; set; }

        public IEventsRepository<Event> EventRepository { get; set; }

        public IResult<Account> Authentication(string accountName)
        {
            IResult<Account> result = new ResultEntity<Account>();
            result.Success = false;
            if (this.Repository != null)
            {
                if (!string.IsNullOrEmpty(accountName))
                {
                    var user = this.Repository.GetUserByAccountName(accountName);

                    if (user != null)
                    {
                        result.Success = true;
                        result.Data = new Account() { Id = user.Id, Name = user.Name };
                        result.Message = "Successful sign in";
                    }
                    else
                    {
                        result.Message = "User not found";
                    }
                }
                else
                {
                    result.Message = "The account name must not be empty";
                }
            }
            else
            {
                result.Message = "It is not possible to access the data service";
            }

            return result;
        }

        public IResult<UserEvent> GetUserEvents(int userId)
        {
            IResult<UserEvent> eventsResult = new ResultEntity<UserEvent>();
            UserEvent userResponse = new UserEvent();
            if (userId <= 0)
            {
                eventsResult.Message = "The user ID is not valid";
                eventsResult.Success = false;
                return eventsResult;
            }

            if (this.EventRepository == null)
            {
                this.EventRepository = new EventsRepository();
            }

            if (this.Repository == null)
            {
                this.Repository = new UserRepository();
            }

            if (this.Repository.GetById(userId) == null)
            {
                eventsResult.Message = "User not found";
                eventsResult.Success = false;
                return eventsResult;
            }

            userResponse.Events = this.EventRepository.GetEventsByUserId(userId);
            userResponse.UserId = userId;
            eventsResult.Data = userResponse;
            eventsResult.Message = "Successful Data";
            eventsResult.Success = true;

            return eventsResult;
        }
    }
}
