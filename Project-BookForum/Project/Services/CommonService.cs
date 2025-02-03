using Project.Data;
using Project.Data.Entities.Account;
using System.Security.Claims;

namespace Project.Services
{
    public class CommonService
    {
        private readonly ApplicationDbContext context;
        public CommonService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public ApplicationUser FindUser(ClaimsPrincipal user)
        {
            string userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return context.Users.FirstOrDefault(x => x.Id == userId);
        }
        public string OwnerName(ApplicationUser user)
        {
            return user.FirstName + " " + user.LastName;
        }

    }
}
