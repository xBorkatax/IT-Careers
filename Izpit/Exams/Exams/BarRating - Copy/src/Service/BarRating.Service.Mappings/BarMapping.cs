using BarRating.Data.Models;
using BarRating.Service.Models;

namespace BarRating.Service.Mappings
{
    public static class BarMapping
    {
        public static Bar ToEntity(this BarDto barDto)
        {
            Bar bar = new Bar();

            bar.Id = barDto.Id;
            bar.CreatedBy = barDto.CreatedByDto?.ToEntity();
            bar.CreatedById = barDto.CreatedById;
            bar.CreatedOn = barDto.CreatedOn;
            bar.Name = barDto.Name;
            bar.Description = barDto.Description;
            bar.Image = barDto.Image;
            bar.Reviews = barDto.ReviewDtos?.Select(r => r.ToEntity()).ToList();
            return bar;
        }

        public static BarDto ToDto(this Bar bar)
        {
            BarDto barDto = new BarDto();

            barDto.Id = bar.Id;
            barDto.CreatedByDto = bar.CreatedBy?.ToDto();
            barDto.CreatedById = bar.CreatedById;
            barDto.CreatedOn = bar.CreatedOn;
            barDto.Name = bar.Name;
            barDto.Description = bar.Description;
            barDto.Image = bar.Image;
            barDto.ReviewDtos = bar.Reviews?.Select(r => r.ToDto()).ToList();

            return barDto;
        }
    }
}
