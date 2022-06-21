using System.Linq;
using Kendo.Mvc.Examples.Models.Chart;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class ChartsController : BaseController
    {
        [Demo]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SalesByProductCategory()
        {
            return Json(ChartOverviewDataRepository.ProductCategoriesData());
        }

        [HttpPost]
        public ActionResult FunnelSales()
        {
            return Json(ChartOverviewDataRepository.FunnelSalesData());
        }

        [HttpPost]
        public ActionResult SalesByRegion()
        {
            return Json(ChartOverviewDataRepository.RegionSalesData());
        }
        [HttpPost]
        public ActionResult SalesPerformers()
        {
            return Json(ChartOverviewDataRepository.SalesPerformers());
        }

        [HttpPost]
        public ActionResult BoeingStockDataRead()
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