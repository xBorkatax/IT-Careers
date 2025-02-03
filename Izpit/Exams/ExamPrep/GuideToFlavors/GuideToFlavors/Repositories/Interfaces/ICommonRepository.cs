using GuideToFlavors.Data;

namespace GuideToFlavors.Repositories.Interfaces
{
    public interface ICommonRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);

        Task<T> Edit(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllAsNoTracking();

        int Save();
    }
}
