using BloodBankApp.EF;
using BloodBankApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodBankApp.Controllers
{
    public class DonorQueryController : Controller
    {
        BloodBankDbContext db;
        public DonorQueryController(BloodBankDbContext db)
        {
            this.db = db;
        }

        public IActionResult ByBloodGroup(string? bloodGroup)
        {
            ViewBag.BloodGroups = db.Donors
                .Select(d => d.BloodGroup)
                .Distinct()
                .OrderBy(g => g)
                .ToList();
            ViewBag.Selected = bloodGroup;

            var data = string.IsNullOrEmpty(bloodGroup)
                ? new List<EF.Tables.Donor>()
                : (from d in db.Donors
                   where d.BloodGroup == bloodGroup
                   select d).ToList();

            return View(data);
        }

        public IActionResult ByLastDonation()
        {
            var data = (from d in db.Donors
                        orderby d.LastDonationDate descending
                        select d).ToList();
            return View(data);
        }

        public IActionResult DonationCounts()
        {
            var data = (from d in db.Donors
                        select new DonorDonationCount
                        {
                            DonorId = d.DonorId,
                            FullName = d.FullName,
                            BloodGroup = d.BloodGroup,
                            DonationCount = d.Donations.Count()
                        }).ToList();
            return View(data);
        }

        public IActionResult TotalVolume()
        {
            var total = db.Donations.Sum(d => (int?)d.VolumeMl) ?? 0;
            ViewBag.TotalVolume = total;
            return View();
        }
    }
}
