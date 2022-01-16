using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcCar.Data;
using System;
using System.Linq;
namespace MvcCar.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcCarContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcCarContext>>()))
            {
                // Look for any cars.
                if (context.Car.Any())
                {
                    return;   // DB has been seeded
                }
                context.Car.AddRange(
                    new Car
                    {
                        Brand = "Audi",
                        Model = "A4",
                        YearOfManufacture = DateTime.Parse("2020-2-10"),
                        FuelType = "Petrol",
                        Price = 122000M
                    },
                    new Car
                    {
                        Brand = "Volkswagen",
                        Model = "Golf VII",
                        YearOfManufacture = DateTime.Parse("2014-1-11"),
                        FuelType = "Diesel",
                        Price = 100000M
                    },
                    new Car
                    {
                        Brand = "Ferrari",
                        Model = "488",
                        YearOfManufacture = DateTime.Parse("2018-5-6"),
                        FuelType = "Petrol",
                        Price = 2950000M
                    },
                    new Car
                    {
                        Brand = "Renault",
                        Model = "Laguna",
                        YearOfManufacture = DateTime.Parse("2001-7-4"),
                        FuelType = "Diesel",
                        Price = 4950M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}