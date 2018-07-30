namespace BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class EventHost : IEventHost
    {
        public EventHost()
        {
            if (this.EventRepository == null)
            {
                this.EventRepository = new EventsRepository();
            }
        }

        public IUserRepository<User> Repository { get; set; } = new UserRepository();

        public IEventsRepository<Event> EventRepository { get; set; } = new EventsRepository();

        public IGuestRepository<Guest> GuestRepository { get; set; } = new GuestRepository();

        public IResult<Event> GetEvent(int eventId)
        {
            IResult<Event> eventsResult = new ResultEntity<Event>();
            if (eventId <= 0)
            {
                eventsResult.Message = "The event ID is not valid";
                eventsResult.Success = false;
                return eventsResult;
            }

            if (this.EventRepository == null)
            {
                this.EventRepository = new EventsRepository();
            }

            if (this.EventRepository.GetById(eventId) == null)
            {
                eventsResult.Message = "Event not found";
                eventsResult.Success = false;
                return eventsResult;
            }

            Event eventResponse = new Event();
            eventResponse = this.EventRepository.GetById(eventId);
            eventsResult.Data = eventResponse;
            eventsResult.Message = "Successful Data";
            eventsResult.Success = true;

            return eventsResult;
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
                                result.Message = "The User can not be found.";
                            }
                        }
                        else
                        {
                            if (newEvent.UserId < 0)
                            {
                                result.Message = "The User Id can not be negative.";
                            }
                            else
                            {
                                result.Message = "The User Id can not be empty.";
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

        public IResult<EventGuests> GetGuestList(int eventId)
        {
            IResult<EventGuests> resultGuestList = new ResultEntity<EventGuests>();

            if (eventId <= 0)
            {
                resultGuestList.Message = "Event ID is not valid.";
                resultGuestList.Success = false;
                return resultGuestList;
            }

            if (this.EventRepository.GetById(eventId) == null)
            {
                resultGuestList.Message = "Event not found.";
                resultGuestList.Success = false;
                return resultGuestList;
            }

            List<GuestInformation> userGuestList = new List<GuestInformation>();
            var guestList = this.GuestRepository.GetGuestsByEventId(eventId);

            foreach (var item in guestList)
            {
                User userGuest = this.Repository.GetById(item.UserId);
                GuestInformation eventGuest = new GuestInformation();
                eventGuest.Id = userGuest.Id;
                eventGuest.Name = userGuest.Name;
                eventGuest.AcountName = userGuest.AccountName;
                userGuestList.Add(eventGuest);
            }

            EventGuests guestListEvent = new EventGuests();
            guestListEvent.EventId = eventId;
            guestListEvent.Guests = userGuestList;
            resultGuestList.Data = guestListEvent;
            resultGuestList.Message = "Successful Data.";
            resultGuestList.Success = true;

            return resultGuestList;
        }

        public ResultSimplified InviteGuest(Guest newGuest)
        {
            ResultSimplified result = new ResultSimplified();

            result.Success = false;
            try
            {
                if (this.GuestRepository != null)
                {
                    if (newGuest != null)
                    {
                        if (newGuest.UserId > 0)
                        {
                            if (newGuest.EventId > 0)
                            {
                                if (!this.GuestRepository.Exist(newGuest))
                                {
                                    newGuest.Status = "PENDING";
                                    if (this.GuestRepository.Create(newGuest))
                                    {
                                        result.Success = true;
                                        result.Message = "Invitation sent.";
                                    }
                                    else
                                    {
                                        result.Message = "The register of the Guest can not be created.";
                                    }
                                }
                                else
                                {
                                    result.Message = "The invitation really exist.";
                                }
                            }
                            else
                            {
                                result.Message = "The Event is not valid.";
                            }
                        }
                        else
                        {
                            result.Message = "The User is not valid.";
                        }
                    }
                    else
                    {
                        result.Message = "The Guest can not be null.";
                    }
                }
                else
                {
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
