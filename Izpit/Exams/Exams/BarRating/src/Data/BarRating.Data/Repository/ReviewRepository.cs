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
    public class ReviewRepository : CommonRepository<Review>, IReviewRepository
    {
        public ReviewRepository(BarRatingDbContext context) : base(context)
        {
        }
    }
}
