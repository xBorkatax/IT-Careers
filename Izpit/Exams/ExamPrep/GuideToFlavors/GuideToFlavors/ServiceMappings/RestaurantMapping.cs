using GuideToFlavors.Data;
using GuideToFlavors.ServiceModels;

namespace GuideToFlavors.ServiceMappings
{
    public static class RestaurantMapping
    {
        public static Restaurant ToEntity(this RestaurantDto restaurantDto)
        {
            Restaurant restaurant = new Restaurant();

            restaurant.Id = restaurantDto.Id;
            restaurant.CreatedBy = restaurantDto.CreatedByDto?.ToEntity();
            restaurant.CreatedById = restaurantDto.CreatedById;
            restaurant.CreatedOn = restaurantDto.CreatedOn;
            restaurant.Name = restaurantDto.Name;
            restaurant.Description = restaurantDto.Description;
            restaurant.Image = restaurantDto.Image;
            restaurant.Reviews = restaurantDto.ReviewDtos?.Select(r => r.ToEntity()).ToList();
            return restaurant;
        }

        public static RestaurantDto ToDto(this Restaurant restaurant)
        {
            RestaurantDto restaurantDto = new RestaurantDto();

            restaurantDto.Id = restaurant.Id;
            restaurantDto.CreatedByDto = restaurant.CreatedBy?.ToDto();
            restaurantDto.CreatedById = restaurant.CreatedById;
            restaurantDto.CreatedOn = restaurant.CreatedOn;
            restaurantDto.Name = restaurant.Name;
            restaurantDto.Description = restaurant.Description;
            restaurantDto.Image = restaurant.Image;
            restaurantDto.ReviewDtos = restaurant.Reviews?.Select(r => r.ToDto()).ToList();

            return restaurantDto;
        }
    }
}
