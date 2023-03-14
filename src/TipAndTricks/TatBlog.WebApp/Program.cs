using Microsoft.EntityFrameworkCore;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Extensions;
using TatBlog.WebApp.Mapster;

var builder = WebApplication.CreateBuilder(args);
{
    builder.ConfigureMvc().ConfigureServices();
}
var app = builder.Build();
{
    app.UseRequestPipeline();
    app.UseBlogRoutes();
    app.UseDataSeeder();
}
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<IDataSeeder>();
    seeder.Initialize();
}

var builder = WebApplication.CreateBuilder(args);
{
    builder.ConfigureMvc().ConfigureServices().ConfigureMapster();
}

app.Run();
