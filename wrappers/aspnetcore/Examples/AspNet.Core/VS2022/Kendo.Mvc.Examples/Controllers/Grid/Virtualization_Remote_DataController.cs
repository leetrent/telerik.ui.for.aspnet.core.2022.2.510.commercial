using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
	public partial class GridController : BaseController
    {
        public static Random random = new Random();
        public static List<string> cities = new List<string> { "Seattle", "Praia", "George Town", "Copenhagen", "Berlin", "Munich", "Athens", "Milan", "Rome", "Kingston", "Tokyo", "Amsterdam", "Auckland", "St. Petersburg", "Moscow", "Durban", "Cape Town", "Daegu", "Madrid", "Barcelona", "Abu Dhabi", "Malmo", "Geneva", "Bangkok", "London", "Philadelphia", "New York", "Seattle", "Boston" };
        public static List<string> firstNames = new List<string> { "Nancy", "Andrew", "Janet", "Margaret", "Steven", "Michael", "Robert", "Laura", "Anne", "Nige" };
        public static List<string> titles = new List<string> {"Accountant", "Vice President, Sales", "Sales Representative", "Technical Support", "Sales Manager", "Web Designer", "Software Developer", "Inside Sales Coordinator", "Chief Techical Officer", "Chief Execute Officer" };
        public static List<string> lastNames = new List<string> { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan", "Suyama", "King", "Callahan", "Dodsworth", "White" };
        public static List<string> countriesList = new List<string>() { "Canada", "Cape Verde", "Cayman Islands", "Denmark", "Germany", "Greece", "Italy", "Jamaica", "Japan", "Netherlands", "New Zealand", "Russia", "South Africa", "South Korea", "Spain", "Sweden", "Switzerland", "Thailand", "United Arab Emirates", "United Kingdom", "United States" };
        public static List<EmployeeViewModel> employees = new List<EmployeeViewModel>();

        [Demo]
        public ActionResult Virtualization_Remote_Data()
        {
            return View();
        }

        public ActionResult Virtualization_Read([DataSourceRequest] DataSourceRequest request, int rows)
        { 
            return Json(GetEmployees(rows).ToDataSourceResult(request));
        }

        private IEnumerable<EmployeeViewModel> GetEmployees(int rows)
        {            
            if (employees.Count == 0)
            {
                employees = Enumerable.Range(1, 500001).Select(x => new EmployeeViewModel()
                {
                    EmployeeID = x,
                    City = cities[random.Next(0, cities.Count)],
                    Country = countriesList[random.Next(0, countriesList.Count)],
                    FirstName = firstNames[random.Next(0, firstNames.Count)],
                    LastName = lastNames[random.Next(0, lastNames.Count)],
                    Title = titles[random.Next(0, titles.Count)],
                }).ToList();
            }

            var resultSet = employees.Take(rows);
            return resultSet;
        }
    }
}