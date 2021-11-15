using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_UlkeVeBayraklar.Models.Data;
using MVC_UlkeVeBayraklar.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_UlkeVeBayraklar.Admin.Controllers
{
    [Area("Admin")]
    public class UlkelerController : Controller
    {
        private readonly DatabaseContext _db;

        public UlkelerController(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Ulkeler.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulke = await _db.Ulkeler.FirstOrDefaultAsync(u => u.Id.Equals(id));

            if (ulke == null)
            {
                return NotFound();
            }

            return View(ulke);
        }

        public async Task<IActionResult> Create()
        {
            ViewData["Renk"] = await _db.Renkler.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, UlkeAd")] Ulke ulke, int[] selectedRenkler)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ulke);
                await _db.SaveChangesAsync();
                await AssignRenklerAsync(ulke.Id, selectedRenkler);
                return RedirectToAction(nameof(Index));
                
            }

            ViewData["SelectedRenkler"] = selectedRenkler;
            ViewData["Renkler"] = await _db.Renkler.ToListAsync();
            return View(ulke);
        }

        private async Task AssignRenklerAsync(int ulkeId, int[] selectedRenkler)
        {
            Ulke ulke = await _db.Ulkeler.FindAsync(ulkeId);
            await _db.Entry(ulke).Collection(m => m.BayrakRenkleri).LoadAsync(); // explicit loading
            ulke.BayrakRenkleri.Clear();
            foreach (int renkId in selectedRenkler)
            {
                ulke.BayrakRenkleri.Add(await _db.Renkler.FindAsync(renkId));
            }
            await _db.SaveChangesAsync();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulke = await _db.Ulkeler.FindAsync(id);
            if (ulke == null)
            {
                return NotFound();
            }

            await _db.Entry(ulke).Collection(u => u.BayrakRenkleri).LoadAsync();
            ViewData["Renkler"] = await _db.Renkler.ToListAsync();
            ViewData["SelectedRenkler"] = ulke.BayrakRenkleri.Select(r => r.Id).ToArray();
            return View(ulke);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UlkeAd")] Ulke ulke, int[] selectedRenkler)
        {
            if (id != ulke.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(ulke);
                    await _db.SaveChangesAsync();
                    await AssignRenklerAsync(ulke.Id, selectedRenkler);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UlkeExists(ulke.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["SelectedGenres"] = selectedRenkler;
            ViewData["Genres"] = await _db.Renkler.ToListAsync();
            return View(ulke);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ulke = await _db.Ulkeler
                .FirstOrDefaultAsync(u => u.Id.Equals(id));
            if (ulke == null)
            {
                return NotFound();
            }

            return View(ulke);
        }

        // POST: Admin/Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _db.Ulkeler.FindAsync(id);
            _db.Ulkeler.Remove(movie);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UlkeExists(int id)
        {
            return _db.Ulkeler.Any(u => u.Id.Equals(id));
        }
    }
}
