using Microsoft.AspNetCore.Mvc;

namespace BloodBankApp.Controllers
{
    public class DonorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
