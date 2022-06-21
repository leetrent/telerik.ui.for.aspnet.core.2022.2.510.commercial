using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Kendo.Mvc.Examples.Controllers
{
    public class HomeController : BaseController
    {
        private IWebHostEnvironment _hostingEnvironment;

        public HomeController(IWebHostEnvironment environment)
        {
            this._hostingEnvironment = environment;
        }

        [Home]
        public ActionResult Index()
        {
            ViewBag.SearchAction = Url.Action("HubSearch", "Home");
            ViewBag.ComponentIcons = GetComponentIcons();
            ViewBag.SearchIcon = Path.Combine(_hostingEnvironment.WebRootPath, "shared/images/site/zoom.svg");

            return View();
        }

        [Home]
        [Route("search")]
        public ActionResult Search()
        {
            ViewBag.ComponentIcons = GetComponentIcons();
            ViewBag.SearchIcon = Path.Combine(_hostingEnvironment.WebRootPath, "shared/images/site/zoom.svg");
            ViewBag.GoogleApiKey = "AIzaSyAoMzKVlaLGxBlzHnHXYUekeDC1Sg0UMzY";
            ViewBag.GoogleCustomSearchInstance = "017812832676623302965:syqm_fb1wym";

            return View();
        }

        [Home]
        [Route("hubsearch")]
        public ActionResult HubSearch()
        {
            ViewBag.SearchAction = Url.Action("HubSearch", "Home");
            ViewBag.ComponentIcons = GetComponentIcons();
            ViewBag.SearchIcon = Path.Combine(_hostingEnvironment.WebRootPath, "shared/images/site/zoom.svg");
            ViewBag.GoogleApiKey = "AIzaSyAoMzKVlaLGxBlzHnHXYUekeDC1Sg0UMzY";
            ViewBag.GoogleCustomSearchInstance = "017812832676623302965:syqm_fb1wym";

            return View();
        }

        [HttpGet]
        public IDictionary<string, string> GetComponentIcons()
        {
            var icons = new Dictionary<string, string>();

            icons.Add("grid", GetComponentIconPath("shared/images/components/grid.svg"));
            icons.Add("barcharts", GetComponentIconPath("shared/images/components/barcharts.svg"));
            icons.Add("scheduler", GetComponentIconPath("shared/images/components/scheduler.svg"));
            icons.Add("dropdownlist", GetComponentIconPath("shared/images/components/dropdownlist.svg"));
            icons.Add("daterangepicker", GetComponentIconPath("shared/images/components/daterangepicker.svg"));
            icons.Add("editor", GetComponentIconPath("shared/images/components/editor.svg"));

            return icons;
        }

        private string GetComponentIconPath(string path)
        {
            return Path.Combine(_hostingEnvironment.WebRootPath, path);         
        }

        public JsonResult GetProducts(string text)
        {
            using (var northwind = GetContext())
            {
                var products = northwind.Products.Select(product => new ProductViewModel
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    UnitPrice = product.UnitPrice.Value,
                    UnitsInStock = product.UnitsInStock.Value,
                    UnitsOnOrder = product.UnitsOnOrder.Value,
                    Discontinued = product.Discontinued
                });

                if (!string.IsNullOrEmpty(text))
                {
                    products = products.Where(p => p.ProductName.Contains(text));
                }

                return Json(products.ToList());
            }
        }

        public IEnumerable<CustomerViewModel> GetCustomers()
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