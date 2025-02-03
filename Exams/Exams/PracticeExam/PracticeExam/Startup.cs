using Microsoft.AspNetCore.Builder;

namespace PracticeExam
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            SeedData.Initialize(app.ApplicationServices).Wait();
        }
    }
}
