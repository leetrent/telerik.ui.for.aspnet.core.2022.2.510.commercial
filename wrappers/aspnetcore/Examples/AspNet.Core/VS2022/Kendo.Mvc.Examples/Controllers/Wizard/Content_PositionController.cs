using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;


namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WizardController : Controller
    {
        [Demo]
        public ActionResult Content_Position(string position)
        {
            WizardContentPosition positionValue = WizardContentPosition.Bottom;

            if (position == "right")
            {
                positionValue = WizardContentPosition.Right;
            }
            else if (position == "left")
            {
                positionValue = WizardContentPosition.Left;
            }
            else
            {
                positionValue = WizardContentPosition.Bottom;
            }

            var model = new CompositeContentPositionModel()
            {
                First = new FirstInnerContentPositionModel() { FirstName = "John", LastName = "Doe" },
                Second = new SecondInnerContentPositionModel() { Username = "johny", Email = "john.doe@email.com", Password = "pass123" },
                Position = new ContentPositionModel() { Position = positionValue }
            };
            return View(model);
        }
    }

    public class FirstInnerContentPositionModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }

    public class SecondInnerContentPositionModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }

    public class ContentPositionModel
    {
        public WizardContentPosition Position { get; set; }
    }

    public class CompositeContentPositionModel
    {
        public FirstInnerContentPositionModel First { get; set; }

        public SecondInnerContentPositionModel Second { get; set; }

        public ContentPositionModel Position { get; set; }
    }
}