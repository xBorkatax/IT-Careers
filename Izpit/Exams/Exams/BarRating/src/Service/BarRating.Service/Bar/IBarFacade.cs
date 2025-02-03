using BarRating.Service.Models;
using BarRating.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarRating.Service.Bar
{
    public interface IBarFacade
    {
        List<BarViewModel> GetBarViewModels();

        Task<BarDto> CreateBar(BarCreationModel barCreationModel);

        BarUpdateModel GetBarUpdateModelById(string id);

        Task<BarDto> UpdateBar(BarUpdateModel barUpdateModel);
    }
}
