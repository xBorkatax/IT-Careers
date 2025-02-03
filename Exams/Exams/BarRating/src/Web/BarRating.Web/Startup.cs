using Microsoft.AspNetCore.Builder;

namespace BarRating.Web
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            SeedData.Initialize(app.ApplicationServices).Wait();
        }
    }
}
