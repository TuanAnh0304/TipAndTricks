﻿using Microsoft.EntityFrameworkCore;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;

namespace TatBlog.WebApp.Extensions
{
    public static class WebApplicationExtensions
    {
        static WebApplicationBuilder ConfigureMvc(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddResponseCompression();

            return builder;
        }
        static WebApplicationBuilder ConfigureServices(
            WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BlogDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration
                    .GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IDataSeeder, DataSeeder>();

            return builder;
        }
        static WebApplication UseRequestPipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Blog/Error");

                app.UseHsts();
            }

            app.UseResponseCompression();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            return app;

        }
        static IApplicationBuilder UseDataSeeder(
            this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            try
            {
                scope.ServiceProvider
                .GetRequiredService<IDataSeeder>()
                .Initialize();
            }
            catch (Exception ex)
            {
                scope.ServiceProvider
                .GetRequiredService<ILogger<Program>>()
                .LogError(ex, "Could not insert data into database");
            }
            return app;
        }
    }
}