using MilitaryProductsFlaggingSystem.Application.Services;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Infrastructure.Converters;
using MilitaryProductsFlaggingSystem.Infrastructure.Repositories;

namespace MilitaryProductsFlagggingSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddTransient<IProductsConverter, ProductsConverter>();
            builder.Services.AddTransient<IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1.Offer>, Supplier1Repository>();
            builder.Services.AddTransient<IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2.Product>, Supplier2Repository>();
            builder.Services.AddTransient<IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier3.Produkt>, Supplier3Repository>();
            builder.Services.AddTransient<IFlaggedItemsRepository, FlaggedItemsRepository>();
            builder.Services.AddTransient<ISupplierServiceFactory, SupplierServiceFactory>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
