using BarRating.Data.Models;
using BarRating.Service.Models;

namespace BarRating.Service.Mappings
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
            review.Bar = reviewDto.BarDto?.ToEntity();
            review.BarId = reviewDto.BarId;

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
            reviewDto.BarDto = review.Bar?.ToDto();
            reviewDto.BarId = review.BarId;

            return reviewDto;
        }
    }
}
