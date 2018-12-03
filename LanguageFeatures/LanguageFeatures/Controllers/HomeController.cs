using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LanguageFeatures.Models;
namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        //public ViewResult Index()
        //{
        //    //List<string> results = new List<string>();
        //    //foreach (Product p in Product.GetProducts())
        //    //{
        //    //    //string name = p?.Name??"No Name";
        //    //    //decimal? price = p?.Price??0;
        //    //    //string relatedName = p?.Related?.Name??"<None>";
        //    //    //results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");

        //    //}
        //    //return View(results);
        //    Dictionary<string, Product> products = new Dictionary<string, Product>
        //    {

        //        ["Kayak"] = new Product { Name = "Kayak", Price = 275M },
        //        ["Lifejacket"]=new Product { Name = "Lifejacket", Price = 48.95M},

        //    };
        //    return View("Index", products.Keys);
        //}

        //public ViewResult Index()
        //{
        //    object[] data = new object[] { 275M, 29.95M, "apple", "orange", 100, 10 };
        //    decimal total = 0;
        //    for (int i = 0; i < data.Length; i++)
        //    {

        //        switch (data[i])
        //        {
        //            case decimal decimalValue:
        //                total += decimalValue;
        //                break;
        //            case int intValue when intValue > 50:
        //                total += intValue;
        //                break;
        //        }
        //    }

        //    return View("Index", new string[] { $"Total:{total:C2}" });
        //}

        public ViewResult Index()
        {
            ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product{Name="Kayak",Price=275M},
                new Product{Name="Lifejacket",Price=48.95M}
            };

            decimal cartTotal = cart.TotalPrice();
            decimal arrayTotal = productArray.TotalPrice();
            return View("Index", new string[] { $"Cart Total: {cartTotal:C2}",$"Array Total: {arrayTotal:C2}" });

        }
    }
}
