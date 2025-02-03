using GuideToFlavors.Data;
using GuideToFlavors.Repositories.Interfaces;

namespace GuideToFlavors.Repositories
{
    public class RestaurantRepository : CommonRepository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
