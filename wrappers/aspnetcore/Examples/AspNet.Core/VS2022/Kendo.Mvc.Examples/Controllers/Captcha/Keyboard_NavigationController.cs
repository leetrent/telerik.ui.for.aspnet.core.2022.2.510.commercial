using Kendo.Mvc.Examples.Models;
using Kendo.Mvc.Examples.Models.Form;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using Telerik.Web.Captcha;

namespace Kendo.Mvc.Examples.Controllers
{

    public partial class CaptchaController : Controller
    {
        [Demo]
        public ActionResult Keyboard_Navigation()
        {
            GenerateNewCaptcha();

            return View();
        }

        public ActionResult Reset_Keyboard_Navigation()
        {
            CaptchaImage newCaptcha = SetCaptchaImage();

            return Json(new CaptchaModel
            {
                Captcha = Url.Content("~/shared/UserFiles/captcha/" + newCaptcha.UniqueId + ".png"),
                CaptchaID = newCaptcha.UniqueId
            });
        }

        public ActionResult Validate_Keyboard_Navigation(CaptchaModel model)
        {
            string text = GetCaptchaText(model.CaptchaID);

            return Json(text ==  model.Captcha.ToUpperInvariant());
        }
    }
}