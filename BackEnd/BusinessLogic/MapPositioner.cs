using DataAccess;
using Model.Core;
using Model.Object;

namespace BusinessLogic
{
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
            System.Console.WriteLine($"Udates is: {update.Latitude}");
            var user = users.GetUserById(update.Id);

            if (user != null)
            {
                user.Latitude = update.Latitude;
                user.Longitude = update.Longitude;
                System.Console.WriteLine($"User latitude is: {user.Latitude}");
                users.Update(user);
                return true;
            }

            return false;
        }
    }
}
