using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVC_UlkeVeBayraklar.Models;
using MVC_UlkeVeBayraklar.Models.Data;
using MVC_UlkeVeBayraklar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _db;

        public HomeController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index(int? renk, string q)
        {
            var vm = new HomeViewModel()
            {
                Renkler = _db.Renkler
                    .Select(x => new SelectListItem() { Text = x.RenkAdi, Value = x.Id.ToString() })
                    .ToList(),
                Ulkeler = _db.Ulkeler
                    .Include(x => x.BayrakRenkleri)
                    .Where(x => (!renk.HasValue || x.BayrakRenkleri.Any(g => g.Id == renk))
                        && (q == null || x.UlkeAd.Contains(q)))
                    .ToList(),
                SelectedRenkId = renk,
                SearchCriteria = q
            };
            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
