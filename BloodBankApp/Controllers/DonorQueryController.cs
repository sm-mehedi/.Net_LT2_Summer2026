using Microsoft.AspNetCore.Mvc;

namespace BloodBankApp.Controllers
{
    public class DonorQueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
