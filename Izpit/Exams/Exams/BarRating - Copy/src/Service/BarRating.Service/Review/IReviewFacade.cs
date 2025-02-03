using BarRating.Service.Models;
using BarRating.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Review
{
    public interface IReviewFacade
    {
        // List<BarViewModel> GetBarViewModels();

        Task<ReviewDto> CreateReview(ReviewCreationModel reviewCreationModel);

        // BarUpdateModel GetBarUpdateModelById(string id);

        // Task<BarDto> UpdateBar(BarUpdateModel barUpdateModel);
    }
}
