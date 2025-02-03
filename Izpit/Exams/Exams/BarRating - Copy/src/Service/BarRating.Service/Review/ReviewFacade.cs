using BarRating.Data.Models;
using BarRating.Service.Models;
using BarRating.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Review
{
    public class ReviewFacade : IReviewFacade
    {
        private readonly IReviewService reviewService;

        public ReviewFacade(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        /*public List<BarViewModel> GetBarViewModels()
        {
            return reviewService.GetAll().Select(b => new BarViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                CreatedByUserName = b.CreatedByDto.UserName,
                CreatedOn = b.CreatedOn
            }).ToList();
        }*/

        public async Task<ReviewDto> CreateReview(ReviewCreationModel reviewCreationModel)
        {
            ReviewDto reviewDto = new ReviewDto()
            {
                Text = reviewCreationModel.Text,
                BarId = reviewCreationModel.BarId,
                CreatedById = reviewCreationModel.CreatedById
            };

            return await reviewService.Create(reviewDto);
        }

        /*public BarUpdateModel GetBarUpdateModelById(string id)
        {
            BarDto barDto = reviewService.GetBarById(id);

            BarUpdateModel barUpdateModel = new BarUpdateModel()
            {
                Id = id,
                Name = barDto.Name,
                Description = barDto.Description
            };

            return barUpdateModel;
        }

        public async Task<BarDto> UpdateBar(BarUpdateModel barUpdateModel)
        {
            byte[] imageContents;
            using (var memoryStream = new MemoryStream())
            {
                await barUpdateModel.Image.CopyToAsync(memoryStream);
                imageContents = memoryStream.ToArray();
            }

            BarDto barDto = new BarDto()
            {
                Id = barUpdateModel.Id,
                Name = barUpdateModel.Name,
                Description = barUpdateModel.Description,
                CreatedById = barUpdateModel.CreatedById,
                Image = imageContents
            };

            return await reviewService.Edit(barDto);
        }*/
    }
}
