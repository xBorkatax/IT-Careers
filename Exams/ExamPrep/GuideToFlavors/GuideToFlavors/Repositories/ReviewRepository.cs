using GuideToFlavors.Data;
using GuideToFlavors.Repositories.Interfaces;

namespace GuideToFlavors.Repositories
{
    public class ReviewRepository : CommonRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
