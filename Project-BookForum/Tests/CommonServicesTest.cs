using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Project.Data;
using Project.Data.Entities.Account;
using Project.Services;
using System.Security.Claims;

namespace Project.Test.CommonServicesTest
{
    [TestFixture]
    public class CommonServiceTests
    {
        private ApplicationDbContext context;
        private CommonService commonService;

        [SetUp]
        public void SetUp()
        {
            
            context = new ApplicationDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options);
            commonService = new CommonService(context);
        }

        [Test]
        public void FindUser_ReturnsNull_WhenUserNotFound()
        {
           
            var user = new ClaimsPrincipal();

          
            var result = commonService.FindUser(user);

            
            Assert.IsNull(result);
        }

        [Test]
        public void FindUser_ReturnsUser_WhenUserFound()
        {
           
            var user = new ApplicationUser { Id = "1" };
            context.Users.Add(user);
            context.SaveChanges();

            var claims = new[] { new Claim(ClaimTypes.NameIdentifier, user.Id) };
            var identity = new ClaimsIdentity(claims);
            var principal = new ClaimsPrincipal(identity);

          
            var result = commonService.FindUser(principal);

           
            Assert.IsNotNull(result);
            Assert.AreEqual(user.Id, result.Id);
        }

        [Test]
        public void OwnerName_ReturnsCorrectName()
        {
           
            var user = new ApplicationUser { FirstName = "John", LastName = "Doe" };

          
            var result = commonService.OwnerName(user);

            Assert.AreEqual("John Doe", result);
        }
    }
}