namespace Model.Core
{
    using System.Linq;

    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> GetAll();
    }
}
