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
        protected readonly IWebHostEnvironment HostingEnvironment;
        protected readonly string CaptchaPath;

        public CaptchaController(IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            CaptchaPath = Path.Combine(hostingEnvironment.WebRootPath, "shared", "UserFiles", "Captcha");

            if (!Directory.Exists(CaptchaPath))
            {
                Directory.CreateDirectory(CaptchaPath);
            }
        }

        [Demo]
        public ActionResult Index()
        {
            GenerateNewCaptcha();

            return View(new UserViewModel()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                UserName = "johny",
                Password = "123456"
            });
        }

        [Demo]
        [HttpPost]
        public ActionResult Index(UserViewModel user, CaptchaModel captchaModel)
        {
            if (string.IsNullOrEmpty(captchaModel.CaptchaID))
            {
                GenerateNewCaptcha();
                return View();
            }
            else
            {
                string text = GetCaptchaText(captchaModel.CaptchaID);

                if (text == captchaModel.Captcha.ToUpperInvariant())
                {
                    ModelState.Clear();
                    GenerateNewCaptcha();
                }
            }

            return View(user);
        }

        private void GenerateNewCaptcha()
        {
            CaptchaImage captchaImage = SetCaptchaImage();

            ViewData["Captcha"] = Url.Content("~/shared/UserFiles/captcha/" + captchaImage.UniqueId + ".png");
            ViewData["CaptchaID"] = captchaImage.UniqueId;
        }

        public ActionResult Reset()
        {
            CaptchaImage newCaptcha = SetCaptchaImage();

            return Json(new CaptchaModel
            {
                Captcha = "./shared/UserFiles/captcha/" + newCaptcha.UniqueId + ".png",
                CaptchaID = newCaptcha.UniqueId
            });
        }

        public ActionResult Validate(CaptchaModel model)
        {
            string text = GetCaptchaText(model.CaptchaID);

            return Json(text ==  model.Captcha.ToUpperInvariant());
        }

        private string GetCaptchaText(string captchaId)
        {
            string text = HttpContext.Session.GetString("captcha_" + captchaId);

            return text;
        }

        private CaptchaImage SetCaptchaImage()
        {
            CaptchaImage newCaptcha = CaptchaHelper.GetNewCaptcha();

            MemoryStream audio = CaptchaHelper.SpeakText(newCaptcha);
            using (FileStream file = new FileStream(Path.Combine(CaptchaPath, newCaptcha.UniqueId + ".wav"), FileMode.Create, FileAccess.Write))
            {
                audio.WriteTo(file);
            }
            

            var image = CaptchaHelper.RenderCaptcha(newCaptcha);
            image.Save(Path.Combine(CaptchaPath, newCaptcha.UniqueId + ".png"), ImageFormat.Png);

            HttpContext.Session.SetString("captcha_" + newCaptcha.UniqueId, newCaptcha.Text);

            return newCaptcha;
        }
    }
}