using System;
using System.Collections.Generic;
using System.Linq;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ListBoxController : BaseController
    {
        private IProductService productService;

        public ListBoxController(
            IProductService service)
        {
            productService = service;
        }


        [Demo]
        public IActionResult Index()
        {
            ViewBag.Attendees = new List<SelectListItem>
            {
                new SelectListItem(){ Value = "1", Text = "Steven White" },
                new SelectListItem(){ Value = "2", Text = "Nancy King" },
                new SelectListItem(){ Value = "3", Text = "Nancy Davolio" },
                new SelectListItem(){ Value = "4", Text = "Michael Leverling" },
                new SelectListItem(){ Value = "5", Text = "Andrew Callahan" },
                new SelectListItem(){ Value = "6", Text = "Michael Suyama" },
            };

            return View();
        }

        public IActionResult GetCustomers()
        {
            var customers = Enumerable.Empty<CustomerViewModel>();

            using (var northwind = GetContext())
            {
                customers = northwind.Customers.Select(customer => new CustomerViewModel
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

            return Json(customers);
        }

        public ActionResult GetProducts()
        {
            var products = Enumerable.Empty<ProductViewModel>();

            using (var northwind = GetContext())
            {
                products = northwind.Products.Select(product => new ProductViewModel
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

            return Json(products);
        }
    }
}
