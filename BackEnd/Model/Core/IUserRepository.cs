namespace Model.Core
{
    public interface IUserRepository<T> : IRepository<T> where T : IEntity
    {
        T GetUserByAccountName(string accountName);

        void Update(T userObject);
    }
}