using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class GridController : BaseController
    {
        private IProductService productService;
        private CustomerEntitiesDataContext context;
        private IDetailProductService detailProductService;

        public GridController(
            IProductService service,
            CustomerEntitiesDataContext context, IDetailProductService detailService)
        {
			productService = service;
            this.context = context;
            detailProductService = detailService;
		}

        [Demo]
        public IActionResult Basic_Usage()
        {
            PopulateCategories();
            return View();
        }

        public IActionResult AllCustomers([DataSourceRequest] DataSourceRequest request)
        {
            return Json(context.Customers.ToDataSourceResult(request));
        }

        public IActionResult Customers_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request));
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs("Post")]
        public ActionResult Products_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            var results = new List<ProductViewModel>();

            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    productService.Create(product);
                    results.Add(product);
                }
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Products_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            if (products != null && ModelState.IsValid)
            {
                foreach (var product in products)
                {
                    productService.Update(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs("Post")]
        public ActionResult Products_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ProductViewModel> products)
        {
            if (products.Any())
            {
                foreach (var product in products)
                {
                    productService.Destroy(product);
                }
            }

            return Json(products.ToDataSourceResult(request, ModelState));
        }
        
		public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
		{
			return Json(GetOrders().ToDataSourceResult(request));
		}

		private static IEnumerable<OrderViewModel> GetOrders()
		{
            using (var northwind = new SampleEntitiesDataContext())
            {
                var customers = northwind.Customers.ToList();

                return northwind.Orders.ToList().Select(order => new OrderViewModel
                {
                    ContactName = customers.First(c => c.CustomerID == order.CustomerID).ContactName,
                    Freight = order.Freight,
                    OrderDate = order.OrderDate,
                    ShippedDate = order.ShippedDate,
                    OrderID = order.OrderID,
                    ShipAddress = order.ShipAddress,
                    ShipCountry = order.ShipCountry,
                    ShipName = order.ShipName,
                    ShipCity = order.ShipCity,
                    EmployeeID = order.EmployeeID,
                    CustomerID = order.CustomerID
                }).ToList();
            }
		}

    }
}
