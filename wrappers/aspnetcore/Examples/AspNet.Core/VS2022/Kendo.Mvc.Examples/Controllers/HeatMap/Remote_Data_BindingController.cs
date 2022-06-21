using Kendo.Mvc.Examples.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class HeatMapController : BaseController
    {
        [Demo]
        public IActionResult Remote_Data_Binding()
        {
            return View();
        }

        public IActionResult RemoteData()
        {
            ICollection<HeatMapModel> data = GetData(10, 10);
            return Json(data);
        }

        public ICollection<HeatMapModel> GetData(int rows, int cols)
        {
            ICollection<HeatMapModel> list = new List<HeatMapModel>();

            for (int row = 1; row <= rows; row++)
            {
                for (int col = 1; col <= cols; col ++)
                {
                    HeatMapModel model = new HeatMapModel() {
                        Column = "A" + col,
                        Row = "B" + row,
                        Value = cols + (row * col)
                    };

                    list.Add(model);
                }
            }

            return list;
        }
    }
}
