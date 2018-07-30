namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public interface IInvitationsDelivery
    {
        IUserRepository<User> UserRepository { get; set; }

        IGuestRepository<Guest> GuestRepository { get; set; }

        IResult<Event> GetInvitations(int userId);
    }
}
