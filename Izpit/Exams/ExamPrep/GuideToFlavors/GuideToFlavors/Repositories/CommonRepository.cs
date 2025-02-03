using GuideToFlavors.Data;
using GuideToFlavors.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuideToFlavors.Repositories
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext context;

        public CommonRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<T> Create(T entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Edit(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().AsQueryable();
        }

        public IQueryable<T> GetAllAsNoTracking()
        {
            return context.Set<T>().AsNoTracking().AsQueryable();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
