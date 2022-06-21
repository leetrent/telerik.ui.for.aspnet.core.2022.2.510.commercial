using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiColumnComboBoxController : BaseController
    {
        [Demo]
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult BasicUsage_Customers_Read()
        {
            return Json(BasicUsage_GetCustomers());
        }

        private IEnumerable<CustomerViewModel> BasicUsage_GetCustomers()
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