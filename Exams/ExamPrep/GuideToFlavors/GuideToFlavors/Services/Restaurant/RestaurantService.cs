using GuideToFlavors.Areas.Identity.Data;
using GuideToFlavors.Repositories.Interfaces;
using GuideToFlavors.ServiceMappings;
using GuideToFlavors.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace GuideToFlavors.Services.Restaurant
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public List<RestaurantDto> GetAll()
        {
            return restaurantRepository.GetAll().Include(r => r.CreatedBy).Select(r => r.ToDto()).ToList();
        }

        public async Task<RestaurantDto> Create(RestaurantDto restaurantDto, GuideToFlavorsUser createdBy)
        {
            Data.Restaurant restaurant = restaurantDto.ToEntity();
            restaurant.Id = Guid.NewGuid().ToString();
            restaurant.CreatedBy = createdBy;
            return (await restaurantRepository.Create(restaurant)).ToDto();
        }
    }
}
