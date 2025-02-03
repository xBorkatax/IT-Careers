using BarRating.Data.Models;
using BarRating.Data.Repository.Interfaces;
using BarRating.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace BarRating.Data.Repository
{
    public class CommonRepository<T> : ICommonRepository<T> where T : BaseEntity
    {
        protected readonly BarRatingDbContext context;

        public CommonRepository(BarRatingDbContext context)
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

        public int DeleteById(string id)
        {
            return context.Set<T>()
                .Where(e => e.Id == id)
                .ExecuteUpdate(setters => setters.SetProperty(b => b.IsDeleted, true));
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().Where(e => e.IsDeleted == false).AsQueryable();
        }

        public IQueryable<T> GetAllAsNoTracking()
        {
            return context.Set<T>().Where(e => e.IsDeleted == false).AsNoTracking().AsQueryable();
        }
    }
}
