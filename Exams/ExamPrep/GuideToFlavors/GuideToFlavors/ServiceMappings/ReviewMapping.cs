using GuideToFlavors.Data;
using GuideToFlavors.ServiceModels;

namespace GuideToFlavors.ServiceMappings
{
    public static class ReviewMapping
    {
        public static Review ToEntity(this ReviewDto reviewDto)
        {
            Review review = new Review();

            review.Id = reviewDto.Id;
            review.CreatedBy = reviewDto.CreatedByDto?.ToEntity();
            review.CreatedById = reviewDto.CreatedById;
            review.CreatedOn = reviewDto.CreatedOn;
            review.Text = reviewDto.Text;
            review.Restaurant = reviewDto.RestaurantDto?.ToEntity();
            review.RestaurantId = reviewDto.RestaurantId;

            return review;
        }

        public static ReviewDto ToDto(this Review review)
        {
            ReviewDto reviewDto = new ReviewDto();

            reviewDto.Id = review.Id;
            reviewDto.CreatedByDto = review.CreatedBy?.ToDto();
            reviewDto.CreatedById = review.CreatedById;
            reviewDto.CreatedOn = review.CreatedOn;
            reviewDto.Text = review.Text;
            reviewDto.RestaurantDto = review.Restaurant?.ToDto();
            reviewDto.RestaurantId = review.RestaurantId;

            return reviewDto;
        }
    }
}
