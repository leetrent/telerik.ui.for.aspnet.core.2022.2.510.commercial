using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Examples.Models;
using System.Linq;
using Kendo.Mvc.UI;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DropDownListController : BaseController
    {
        [Demo]
        public ActionResult Grouping()
        {
            return View();
        }

        public ActionResult Grouping_GetCustomers()
        {
            return Json(GetCustomers());
        }

        private IEnumerable<CustomerViewModel> GetCustomers()
        {
            using (var northwind = GetContext())
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