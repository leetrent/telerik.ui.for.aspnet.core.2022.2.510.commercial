using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Examples.Controllers
{
    public partial class WizardController : Controller
    {
        [Demo]
        public ActionResult Index()
        {
            var model = new UserDetailsModel()
            {
                AccountDetails = new AccountDetailsModel() { Username = "johny", Email = "john.doe@email.com", Password = "pass123" },
                PersonalDetails = new PersonalDetailsModel() { FullName = "", Country = "", Gender = "", About = "" },
                PaymentDetails = new PaymentDetailsModel() { PaymentType = "", CardNumber = "", CSVNumber = "", ExpirationDate = "", CardHolderName = "" }
            };
            return View(model);
        }
    }
    public class AccountDetailsModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class PersonalDetailsModel
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Gender { get; set; }

        public string About { get; set; }
    }

    public class PaymentDetailsModel
    {
        [Required]
        public string PaymentType { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string CSVNumber { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string CardHolderName { get; set; }
    }

    public class UserDetailsModel
    {
        public AccountDetailsModel AccountDetails { get; set; }

        public PersonalDetailsModel PersonalDetails { get; set; }

        public PaymentDetailsModel PaymentDetails { get; set; }
    }
}