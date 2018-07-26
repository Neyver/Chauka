namespace Model.Core
{
    public interface IUserRepository<T> : IRepository<T> where T : IEntity
    {
        T GetUserByAccountName(string username);
        T GetUserById(int userId);
        void Update(T IEntity);
    }
}