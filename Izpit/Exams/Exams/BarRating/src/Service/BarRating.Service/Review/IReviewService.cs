using BarRating.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Review
{
    public interface IReviewService
    {
        List<ReviewDto> GetAll();
        IEnumerable<ReviewDto> GetAllByBarId(string id);
        IEnumerable<ReviewDto> GetAllByUserId(string id);
        Task<ReviewDto> Create(ReviewDto reviewDto);
        ReviewDto GetReviewById(string id);
        Task<ReviewDto> Edit(ReviewDto reviewDto);
        int DeleteById(string id);
    }
}
