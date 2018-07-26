namespace BusinessLogic
{
    using System;
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class EventHost : IEventHost
    {
        public IUserRepository<User> Repository { get; set; } = new UserRepository();

        public IEventsRepository<Event> EventRepository { get; set; } = new EventsRepository();

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

        public ResultSimplified RegisterEvent(Event newEvent)
        {
            ResultSimplified result = new ResultSimplified();
            result.Success = false;
            try
            {
                if (this.Repository != null || this.EventRepository != null)
                {
                    if (newEvent != null)
                    {
                        if (newEvent.UserId > 0)
                        {
                            var user = this.Repository.GetById(newEvent.UserId);
                            if (user != null)
                            {
                                if (!string.IsNullOrEmpty(newEvent.NameEvent))
                                {
                                    newEvent.StartDatetime = DateTime.Parse(newEvent.StartDatetime.ToString("yyyy-MM-dd h:mm"));
                                    if (newEvent.EndDatetime != null)
                                    {
                                        newEvent.EndDatetime = DateTime.Parse(newEvent.StartDatetime.ToString("yyyy-MM-dd h:mm"));
                                    }

                                    if (this.EventRepository.Add(newEvent))
                                    {
                                        this.EventRepository.SaveChanges();
                                        result.Message = "The Event was successfully registered.";
                                        result.Success = true;
                                    }
                                }
                                else
                                {
                                    result.Message = "The Event name must not be empty.";
                                }
                            }
                            else
                            {
                                result.Message = "The User can not to be found.";
                            }
                        }
                        else
                        {
                            if (newEvent.UserId < 0)
                            {
                                result.Message = "The User Id can not to be negative.";
                            }
                            else
                            {
                                result.Message = "The User Id can not to be empty.";
                            }
                        }
                    }
                    else
                    {
                        result.Message = "The register of the Event can not be created.";
                    }
                }
                else
                {
                    result.Success = false;
                    result.Message = "It is not possible to access the data service.";
                }
            }
            catch (Exception ex)
            {
                result.Message = "Interal Exception: " + ex.Message;
            }

            return result;
        }
    }
}
