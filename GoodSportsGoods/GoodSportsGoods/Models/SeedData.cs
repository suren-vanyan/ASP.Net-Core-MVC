using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodSportsGoods.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {

            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "А boat for one person",
                        Category = "Watersports ",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket ",
                        Description = "Protective and fashionaЫe",
                        Category = "Watersports ",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball ",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corne r Flags ",
                        Description = "Give yo u r p l a ying f ield а p ro f e s s ional t ouch",
                        Category = " Socce r",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = " Fl at- pac ked 35 , 000 - seat stadi um ",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking ар ",
                        Description = "Imp rove brai n e f fi cien c y Ьу 7 5%",
                        Category = "Che ss",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Uns t eady Chair ",
                        Description = "Sec r etly give yo u r oppone nt а d is a dvantage",
                        Category = "Che ss",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = " Human Chess Board ",
                        Description = "Аfungameforthefamily",
                        Category = "Che s s ",
                        Price = 75
                    },
                    new Product
                    {
                    
                        Name = "Bling- Bl ing Ki ng ",
                        Description = "Gold-plated, diamond-st udded King",
                        Category = "Chess",
                        Price = 1200
                    });
                context.SaveChanges();
            }

        }
    }
}
