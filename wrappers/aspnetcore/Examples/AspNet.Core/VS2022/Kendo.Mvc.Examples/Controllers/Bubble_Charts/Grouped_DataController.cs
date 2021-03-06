using System.Collections.Generic;
using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class Bubble_ChartsController : Controller
    {
        [Demo]
        public IActionResult Grouped_Data()
        {
            return View();
        }

        private Dictionary<int, string> medalColors = new Dictionary<int, string>() { 
            {1,"#f3ac32"},
            {2,"#b8b8b8"},
            {3,"#bb6e36"}
        };

        [HttpPost]
        public ActionResult _Medals()
        {
            var medals = ChartDataRepository.Medals();
            var viewModel = new List<BubbleChartsGroupedDataViewModel>();

            for (var i = 0; i < medals.Count; i++)
            {
                var data = medals[i];
                var model = new BubbleChartsGroupedDataViewModel(data);
                model.Color = medalColors[model.Standing];
                viewModel.Add(model);
            }

            return Json(viewModel);
        }
    }
}