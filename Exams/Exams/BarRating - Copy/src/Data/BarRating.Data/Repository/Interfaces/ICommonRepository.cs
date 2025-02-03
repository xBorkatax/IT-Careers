using BarRating.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Data.Repository.Interfaces
{
    public interface ICommonRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);

        Task<T> Edit(T entity);

        int DeleteById(string id);

        IQueryable<T> GetAll();

        IQueryable<T> GetAllAsNoTracking();
    }
}
