using BarRating.Data.Models;
using BarRating.Data.Repository.Interfaces;
using BarRating.Service.Mappings;
using BarRating.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarRating.Service.Bar
{
    public class BarService : IBarService
    {
        private readonly IBarRepository barRepository;
        private readonly UserManager<BarRatingUser> userManager;

        public BarService(IBarRepository barRepository, UserManager<BarRatingUser> userManager)
        {
            this.barRepository = barRepository;
            this.userManager = userManager;
        }

        public List<BarDto> GetAll()
        {
            return barRepository.GetAll().Include(r => r.CreatedBy).Select(b => b.ToDto()).ToList();
        }

        public async Task<BarDto> Create(BarDto barDto)
        {
            Data.Models.Bar bar = barDto.ToEntity();
            return (await barRepository.Create(bar)).ToDto();
        }

        public BarDto GetBarById(string id)
        {
            Data.Models.Bar bar = barRepository.GetAll().Include(b => b.CreatedBy).SingleOrDefault(b => b.Id == id);

            if (bar == null)
            {
                throw new ArgumentException($"Bar with id {id} does not exist");
            }

            return bar.ToDto();
        }

        public async Task<BarDto> Edit(BarDto barDto)
        {
            Data.Models.Bar bar = barDto.ToEntity();
            return (await barRepository.Edit(bar)).ToDto();
        }

        public int DeleteById(string id)
        {
            return barRepository.DeleteById(id);
        }
    }
}
