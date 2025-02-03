using BarRating.Data.Models;
using BarRating.Data.Repository.Interfaces;
using BarRating.Service.Mappings;
using BarRating.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarRating.Service.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository reviewRepository;
        private readonly UserManager<BarRatingUser> userManager;

        public ReviewService(IReviewRepository reviewRepository, UserManager<BarRatingUser> userManager)
        {
            this.reviewRepository = reviewRepository;
            this.userManager = userManager;
        }

        public List<ReviewDto> GetAll()
        {
            return reviewRepository.GetAll().Include(r => r.CreatedBy).Select(r => r.ToDto()).ToList();
        }

        public IEnumerable<ReviewDto> GetAllByBarId(string id)
        {
            return reviewRepository.GetAll().Include(r => r.CreatedBy).Where(r => r.BarId == id).Select(r => r.ToDto());
        }

        public IEnumerable<ReviewDto> GetAllByUserId(string id)
        {
            return reviewRepository.GetAll().Include(r => r.CreatedBy).Where(r => r.CreatedById == id).Select(r => r.ToDto());
        }

        public async Task<ReviewDto> Create(ReviewDto reviewDto)
        {
            Data.Models.Review review = reviewDto.ToEntity();
            review.Id = Guid.NewGuid().ToString();
            return (await reviewRepository.Create(review)).ToDto();
        }

        public ReviewDto GetReviewById(string id)
        {
            Data.Models.Review review = reviewRepository.GetAll().Include(b => b.CreatedBy).SingleOrDefault(b => b.Id == id);

            if (review == null)
            {
                throw new ArgumentException($"Review with id {id} does not exist");
            }

            return review.ToDto();
        }

        public async Task<ReviewDto> Edit(ReviewDto reviewDto)
        {
            Data.Models.Review review = reviewDto.ToEntity();
            return (await reviewRepository.Edit(review)).ToDto();
        }

        public int DeleteById(string id)
        {
            return reviewRepository.DeleteById(id);
        }
    }
}
