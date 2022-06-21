using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiSelectController : BaseController
    {
        [Demo]
        public IActionResult Tag_Helper()
        {
            return View();
        }

        public ActionResult Tag_Helper_Virtualization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetOrders_().ToDataSourceResult(request));
        }

        public ActionResult Tag_Helper_Orders_ValueMapper(int[] values)
        {
            var indices = new List<int>();

            if (values != null && values.Any())
            {
                var index = 0;

                foreach (var order in GetOrders_())
                {
                    if (values.Contains(order.OrderID))
                    {
                        indices.Add(index);
                    }

                    index += 1;
                }
            }

            return Json(indices);
        }

        private IEnumerable<OrderViewModel> GetOrders_()
        {
            using (var northwind = GetContext())
            {
                return northwind.Orders.Select(order => new OrderViewModel
                {
                    ContactName = order.Customer.ContactName,
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
