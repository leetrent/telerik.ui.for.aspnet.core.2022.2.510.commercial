using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class MultiColumnComboBoxController : BaseController
    {
        [Demo]
        public ActionResult Template()
        {
            return View();
        }
        public IEnumerable<CustomerViewModel> Template_GetCustomers()
        {
            using (var customers = GetContext())
            {
                return customers.Customers
                    .Select(customer => new CustomerViewModel
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