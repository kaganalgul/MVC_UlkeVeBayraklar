using Microsoft.AspNetCore.Mvc;
using MVC_UlkeVeBayraklar.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Admin.Controllers
{
    [Area("Admin")]
    public class RenklerController : Controller
    {
        private readonly DatabaseContext _db;

        public RenklerController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
