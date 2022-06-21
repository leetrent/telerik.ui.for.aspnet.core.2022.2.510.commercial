using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        private static List<DetailProductViewModel> productsDB = new List<DetailProductViewModel>();
        [Demo]
        public IActionResult Index()
        {
            var rand = new Random();
            if (productsDB.Count == 0)
            {
                productsDB.AddRange(productService.Read()
                    // For demo purposes - get only 4 items with Category: Seafood
                    .Where(product => !(product.Category.CategoryName == "Seafood" && product.ProductID > 30))
                    .Select(product => new DetailProductViewModel()
                    {
                        ProductID = product.ProductID,
                        ProductName = product.ProductName,
                        UnitPrice = product.UnitPrice,
                        UnitsInStock = product.UnitsInStock,
                        QuantityPerUnit = product.QuantityPerUnit,
                        Discontinued = rand.Next(1, 3) % 2 == 0 ? true : false,
                        UnitsOnOrder = product.UnitsOnOrder,
                        CategoryID = product.CategoryID,
                        Country = countries[rand.Next(0, 7)],
                        CustomerRating = rand.Next(0, 6),
                        TargetSales = rand.Next(7, 101),
                        Category = new CategoryViewModel()
                        {
                            CategoryID = product.Category.CategoryID,
                            CategoryName = product.Category.CategoryName
                        },
                        LastSupply = DateTime.Today
                    })
                );
            }

            ViewData["countries"] = countries;
            PopulateCategories();
            return View();
        }

        public IActionResult DetailProducts_Read([DataSourceRequest]DataSourceRequest request)
        {
            return Json(detailProductService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    productsDB.Where(x => x.ProductID == product.ProductID).Select(x => product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            var results = new List<DetailProductViewModel>();

            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    product.ProductID = productsDB.Count + 1;
                    productsDB.Add(product);
                    results.Add(product);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult DetailProducts_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<DetailProductViewModel> products)
        {
            if (products.Any())
            {
                foreach (var product in products)
                {
                    productsDB.Remove(productsDB.First(x => x.ProductID == product.ProductID));
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        public static CountryViewModel[] countries = new CountryViewModel[]
        {
            new CountryViewModel(){CountryNameShort="bg", CountryNameLong="Bulgaria"},
            new CountryViewModel(){CountryNameShort="br", CountryNameLong="Brazil" },
            new CountryViewModel(){CountryNameShort="fr", CountryNameLong= "France"},
            new CountryViewModel(){CountryNameShort="gb", CountryNameLong="Great Britain"},
            new CountryViewModel(){CountryNameShort="in", CountryNameLong="India" },
            new CountryViewModel(){CountryNameShort="it", CountryNameLong="Italy" },
            new CountryViewModel(){CountryNameShort="us", CountryNameLong="USA" }
        };
    }
}
