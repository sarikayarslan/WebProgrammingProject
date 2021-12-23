using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Data;
using WebProgrammingProject.Models;

namespace WebProgrammingProject.Views
{
    public class UserAdvertisementController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserAdvertisementController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserAdvertisement
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.UserAdvertisement.Include(u => u.Advertisement).Include(u => u.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: UserAdvertisement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAdvertisement = await _context.UserAdvertisement
                .Include(u => u.Advertisement)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdvertisement == null)
            {
                return NotFound();
            }

            return View(userAdvertisement);
        }

        // GET: UserAdvertisement/Create
        public IActionResult Create()
        {
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Title");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname");
            return View();
        }

        // POST: UserAdvertisement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,AdvertisementId")] UserAdvertisement userAdvertisement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAdvertisement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Id", userAdvertisement.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdvertisement.UserId);
            return View(userAdvertisement);
        }

        // GET: UserAdvertisement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAdvertisement = await _context.UserAdvertisement.FindAsync(id);
            if (userAdvertisement == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Id", userAdvertisement.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdvertisement.UserId);
            return View(userAdvertisement);
        }

        // POST: UserAdvertisement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,AdvertisementId")] UserAdvertisement userAdvertisement)
        {
            if (id != userAdvertisement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAdvertisement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAdvertisementExists(userAdvertisement.Id))
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
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Id", userAdvertisement.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAdvertisement.UserId);
            return View(userAdvertisement);
        }

        // GET: UserAdvertisement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAdvertisement = await _context.UserAdvertisement
                .Include(u => u.Advertisement)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userAdvertisement == null)
            {
                return NotFound();
            }

            return View(userAdvertisement);
        }

        // POST: UserAdvertisement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAdvertisement = await _context.UserAdvertisement.FindAsync(id);
            _context.UserAdvertisement.Remove(userAdvertisement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAdvertisementExists(int id)
        {
            return _context.UserAdvertisement.Any(e => e.Id == id);
        }
    }
}
