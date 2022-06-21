using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class AutoCompleteController : BaseController
    {
        [Demo]
        public IActionResult Grouping()
        {
            return View();
        }

        public ActionResult Grouping_Customers_Read(string text)
        {
            var result = Grouping_GetCustomers();

            if (text != null)
            {
                result = result.Where(c => c.ContactName.Contains(text)).ToList();
            }

            return Json(result);            
        }

        private IEnumerable<CustomerViewModel> Grouping_GetCustomers()
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