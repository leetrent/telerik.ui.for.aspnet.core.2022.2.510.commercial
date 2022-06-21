
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class FinancialController : BaseController
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _BoeingStockData()
        {
            using (var db = GetContext())
            {
                return Json(
                    (from s in db.Stocks
                    where s.Symbol == "BA"
                    select new StockDataPoint
                    {
                        Date = s.Date,
                        Open = s.Open,
                        High = s.High,
                        Low = s.Low,
                        Close = s.Close,
                        Volume = s.Volume
                    }).ToList()
                );
            }
        }
    }
}