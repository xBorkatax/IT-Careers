using GuideToFlavors.Areas.Identity.Data;
using GuideToFlavors.ServiceModels;

namespace GuideToFlavors.Services.Restaurant
{
    public interface IRestaurantService
    {
        List<RestaurantDto> GetAll();
        Task<RestaurantDto> Create(RestaurantDto restaurantDto, GuideToFlavorsUser createdBy);
    }
}
