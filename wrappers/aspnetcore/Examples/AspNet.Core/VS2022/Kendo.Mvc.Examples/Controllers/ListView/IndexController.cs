using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListViewController : BaseController
    {
        private IProductService productService;

        public ListViewController(
            IProductService service)
        {
            productService = service;
        }

        [Demo]
        public ActionResult Index()
        {
            return View(GetProducts());
        }
                                      
        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetProducts().ToDataSourceResult(request));
        }

        private IEnumerable<ProductViewModel> GetProducts()
        {
            using (var northwind = GetContext())
            {
                return northwind.Products.Select(product => new ProductViewModel
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice.HasValue ? product.UnitPrice.Value : default(decimal),
                    UnitsInStock = product.UnitsInStock.HasValue ? product.UnitsInStock.Value : default(int),
                    UnitsOnOrder = product.UnitsOnOrder.HasValue ? product.UnitsOnOrder.Value : default(int),
                    Discontinued = product.Discontinued,
                    LastSupply = DateTime.Today
                }).ToList();
            }
        }
    }
}