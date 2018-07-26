namespace BusinessLogic
{
    using DataAccess;
    using Model.Core;
    using Model.Object;

    public class MapPositioner : IMapPositioner
    {
        private IUserRepository<User> users;

        public MapPositioner() : this(new UserRepository())
        {
        }

        public MapPositioner(IUserRepository<User> repository)
        {
            this.users = repository;
        }

        public bool UpdateUserPosition(User update)
        {
            var user = this.users.GetById(update.Id);

            if (user != null)
            {
                user.Latitude = update.Latitude;
                user.Longitude = update.Longitude;
                this.users.Update(user);
                return true;
            }

            return false;
        }
    }
}
