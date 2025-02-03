using BarRating.Data.Models;
using BarRating.Data.Repository.Interfaces;
using BarRating.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Data.Repository
{
    public class BarRepository : CommonRepository<Bar>, IBarRepository
    {
        public BarRepository(BarRatingDbContext context) : base(context)
        {
        }
    }
}
