using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class SparklinesController : BaseController
    {
        [Demo]
        public IActionResult Remote_Data_Binding()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _Weather(string station, int year, int month)
        {
            using (var db = new SampleEntitiesDataContext())
            {
                var weatherData = db.Weather
                    .Where(x => x.Station == station && x.Date.Year == year && x.Date.Month == month)
                    .Select(x => new
                    {
                        ID = x.ID,
                        Rain = x.Rain,
                        TMax = x.TMax,
                        Wind = x.Wind
                    });

                return Json(weatherData.ToList());
            }
        }
    }
}