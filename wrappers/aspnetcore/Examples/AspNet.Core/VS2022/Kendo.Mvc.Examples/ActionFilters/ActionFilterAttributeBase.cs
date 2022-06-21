using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Themes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using IOFile = System.IO.File;
using Microsoft.Extensions.Configuration;

namespace Kendo.Mvc.Examples.Controllers
{
    public abstract class ActionFilterAttributeBase : ActionFilterAttribute
    {
        protected static string Header = "";
        protected static string Footer = "";
        protected static string Banner = "";
        protected static bool ResetHeader = true;
        protected static bool ResetFooter = true;
        protected static string TelerikNavigationVersion = "stable";

        private IHostingEnvironment _hostingEnvironment;
        private IEnumerable<LessTheme> LessThemes;
        private IEnumerable<SassTheme> SassThemes;

        protected List<string> examplesUrl = new List<string>();

        public dynamic ViewBag
        {
            get
            {
                return Controller.ViewBag;
            }
        }

        public Controller Controller { get; set; }

        public string ContentRootPath { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var configuration = filterContext.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var assetsCDN = configuration["ApplicationSettings:AssetsCDN"];

            _hostingEnvironment = filterContext.HttpContext.RequestServices.GetRequiredService<IHostingEnvironment>();

            ContentRootPath = _hostingEnvironment.ContentRootPath;

            Controller = filterContext.Controller as Controller;
            string Url = filterContext.HttpContext.Request.Host.Value + filterContext.HttpContext.Request.Path.Value;

            if (ResetHeader)
            {
                UpdateHeader(Url);
                UpdateBanner(Url);
            }
            if (ResetFooter)
            {
                UpdateFooter(Url);
            }

            ViewBag.PathBase = filterContext.HttpContext.Request.PathBase.Value;
            ViewBag.ShowCodeStrip = true;
            ViewBag.Product = MvcFlavor.AspNetCore;
            ViewBag.TelerikNavigationHeader = Header;
            ViewBag.TelerikNavigationFooter = Footer;
            ViewBag.TelerikBannerHeader = Banner;
            ViewBag.NavProduct = "mvc-core";
            ViewBag.ContentRootPath = ContentRootPath;
            ViewBag.CommonFile = "common-empty";
            ViewBag.AssetsCDN = assetsCDN;

            SetFeedbackId();
            LoadThemes();
            SetTheme();
            LoadNavigation();
            LoadCategories();

            if (Url.IndexOf("updateteleriknavigation") != -1)
            {
                ResetHeader = true;
                ResetFooter = true;
            }
        }

        protected IEnumerable<LessTheme> LoadLessThemes()
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var lessThemesJson = IOFile.ReadAllText(rootPath + "/shared/themes/less-themes.json");

            return JsonConvert.DeserializeObject<LessTheme[]>(lessThemesJson);
        }

        protected IEnumerable<SassTheme> LoadSassThemes()
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var sassThemesConfigJson = IOFile.ReadAllText(rootPath + "/shared/themes/sass-themes-config.json");
            var sassThemesJson = IOFile.ReadAllText(rootPath + "/shared/themes/sass-themes.json");
            var sassThemesConfig = JsonConvert.DeserializeObject<SassTheme[]>(sassThemesConfigJson);
            var sassThemes = JsonConvert.DeserializeObject<SassTheme[]>(sassThemesJson);

            return sassThemes.Select(theme => new SassTheme
            {
                Name = theme.Name,
                Title = theme.Title,
                Palette = theme.Palette,
                Primary = theme.Primary,
                Swatches = theme.Swatches
                    .Where(swatch => sassThemesConfig.SingleOrDefault(c => c.Name.Equals(theme.Name)).Swatches
                    .Any(configSwatch => configSwatch.Name == swatch.Name))
                    .OrderByDescending(od => od.Title == "Main")
                    .ThenBy(on => on.Title)
                    .ToArray()
            });
        }
        protected void LoadThemes()
        {
            LessThemes = LoadLessThemes();
            SassThemes = LoadSassThemes();

            ViewBag.LessThemes = LessThemes;
            ViewBag.SassThemes = SassThemes;
        }

        protected void SetTheme()
        {
            var theme = "default-ocean-blue";
            var themeParam = Controller.HttpContext.Request.Query["theme"].FirstOrDefault();
            var storedTheme = Controller.HttpContext.Session.GetString("theme");

            if (themeParam != null && Regex.IsMatch(themeParam, "[a-z0-9\\-]+", RegexOptions.IgnoreCase))
            {
                theme = themeParam;

                // update theme
                Controller.HttpContext.Session.SetString("theme", theme);
            }
            else if (!string.IsNullOrEmpty(storedTheme))
            {
                theme = storedTheme;
            }

            ViewBag.Theme = GetThemeModel(theme);
            ViewBag.IsSassTheme = IsSassTheme(theme);
            ViewBag.CommonFile = GetCommonFile(theme);
        }

        private Theme GetThemeModel(string name)
        {
            var model = this.SassThemes
                .SelectMany(t => t.Swatches)
                .Concat(this.LessThemes)
                .FirstOrDefault(t => t.Name.Equals(name));

            if (model == null)
            {
                model = this.SassThemes.SelectMany(t => t.Swatches)
                    .First(s => s.Name.Equals("default-ocean-blue"));
            }

            return model;
        }

        private bool IsSassTheme(string name)
        {
            return this.SassThemes
               .SelectMany(t => t.Swatches)
               .Any(t => t.Name.Equals(name));
        }

        private string GetCommonFile(string theme)
        {
            var lessModel = this.LessThemes.FirstOrDefault(t => t.Name == theme);

            return lessModel != null ? lessModel.Common : "common-empty";
        }

        protected void LoadNavigation()
        {
            ViewBag.Navigation = LoadWidgets();
        }

        protected void LoadCategories()
        {
            ViewBag.WidgetCategories = LoadWidgets().GroupBy(w => w.Category).ToList();
        }

        protected IEnumerable<NavigationWidget> LoadWidgets()
        {
            var rootPath = _hostingEnvironment.WebRootPath;
            var navJson = IOFile.ReadAllText(rootPath + "/shared/nav.json");

            return JsonConvert.DeserializeObject<NavigationWidget[]>(navJson.Replace("$FRAMEWORK", "ASP.NET Core"));
        }

        protected void UpdateHeader(string Url)
        {
            ResetHeader = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string ProductName = "asp-net-core";
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/nav-" + ProductName + "-csa-abs-component.html";

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Header = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        public void UpdateBanner(string Url)
        {
            if (Url.IndexOf("localhost") == -1)
            {
                string ProductName = "aspnet-core";
                string urlAddress = "https://www.telerik.com/webapi/announcements/getMarkup?url=https://demos.telerik.com/" + ProductName;

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Banner = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }
        protected void UpdateFooter(string Url)
        {
            ResetFooter = false;

            if (Url.IndexOf("localhost") == -1)
            {
                string cdnEnvironment = "";

                if (Url.IndexOf("kendobuild") != -1)
                {
                    cdnEnvironment = "uat";
                }

                string urlAddress = "https://" + cdnEnvironment + "cdn.telerik-web-assets.com/telerik-navigation/" + TelerikNavigationVersion + "/footer-big-abs-markup.html";

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                    request.Timeout = 4000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            Stream receiveStream = response.GetResponseStream();
                            StreamReader readStream = null;

                            if (response.CharacterSet == null)
                            {
                                readStream = new StreamReader(receiveStream);
                            }
                            else
                            {
                                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                            }

                            string data = readStream.ReadToEnd();

                            Footer = data;

                            readStream.Close();
                            receiveStream.Close();
                            response.Close();
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void SetFeedbackId()
        {
            ViewBag.FeedbackId = "5a28baf3-3575-41ae-bd26-93196c2afbca";
        }
    }
}
