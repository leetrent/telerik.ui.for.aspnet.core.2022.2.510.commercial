using Kendo.Mvc.Examples.Models.Themes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class GridController : BaseController
    {
        [Demo]
        public ActionResult SignalR()
        {
            PopulateCategories();
            return View();
        }

        public ActionResult SignalR_Chart()
        {
            SetTheme();
            return View();
        }

        public void SetTheme()
        {
            var theme = "default-v2";
            var themeParam = HttpContext.Request.Query["theme"].FirstOrDefault();
            var storedTheme = HttpContext.Session.GetString("theme");

            if (themeParam != null && Regex.IsMatch(themeParam, "[a-z0-9\\-]+", RegexOptions.IgnoreCase))
            {
                theme = themeParam;

                // update theme
                HttpContext.Session.SetString("theme", theme);
            }
            else if (!string.IsNullOrEmpty(storedTheme))
            {
                theme = storedTheme;
            }

            ViewBag.Theme = theme;
            ViewBag.CommonFile = GetCommonFile(theme);
        }

        private string GetCommonFile(string theme)
        {
            switch (theme)
            {
                case "default-v2":
                case "bootstrap-v4":
                case "material-v2":
                    return "common-empty";
                case "material":
                    return "common-material";
                case "bootstrap":
                    return "common-bootstrap";
                case "fiori":
                    return "common-fiori";
                case "office365":
                    return "common-office365";
                case "nova":
                    return "common-nova";
                default:
                    return "common";
            }
        }
    }
}
