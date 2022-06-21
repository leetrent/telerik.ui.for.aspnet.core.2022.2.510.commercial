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

        [Demo]
        public IActionResult Responsive_Columns()
        {
            return View();
        }

        public IActionResult Responsive_Columns_Customers_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetCustomers().ToDataSourceResult(request));
        }

        private static IEnumerable<CustomerViewModel> GetCustomers()
        {
            using (var northwind = new SampleEntitiesDataContext())
            {
                return northwind.Customers.Select(customer => new CustomerViewModel
                {
                    CustomerID = customer.CustomerID,
                    CompanyName = customer.CompanyName,
                    ContactName = customer.ContactName,
                    ContactTitle = customer.ContactTitle,
                    Address = customer.Address,
                    City = customer.City,
                    Region = customer.Region,
                    PostalCode = customer.PostalCode,
                    Country = customer.Country,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    Bool = customer.Bool
                }).ToList();
            }
        }

    }
}
