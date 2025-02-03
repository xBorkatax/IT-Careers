using BarRating.Data.Models;
using BarRating.Service.Models;
using BarRating.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Bar
{
    public class BarFacade : IBarFacade
    {
        private readonly IBarService barService;

        public BarFacade(IBarService barService)
        {
            this.barService = barService;
        }

        public List<BarViewModel> GetBarViewModels()
        {
            return barService.GetAll().Select(b => new BarViewModel()
            {
                Id = b.Id,
                Name = b.Name,
                Description = b.Description,
                CreatedByUserName = b.CreatedByDto.UserName,
                CreatedOn = b.CreatedOn
            }).ToList();
        }

        public async Task<BarDto> CreateBar(BarCreationModel barCreationModel)
        {
            byte[] imageContents;
            using (var memoryStream = new MemoryStream())
            {
                await barCreationModel.Image.CopyToAsync(memoryStream);
                imageContents = memoryStream.ToArray();
            }

            BarDto barDto = new BarDto()
            {
                Name = barCreationModel.Name,
                Description = barCreationModel.Description,
                CreatedById = barCreationModel.CreatedById,
                Image = imageContents
            };

            return await barService.Create(barDto);
        }

        public BarUpdateModel GetBarUpdateModelById(string id)
        {
            BarDto barDto = barService.GetBarById(id);

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

            return await barService.Edit(barDto);
        }
    }
}
