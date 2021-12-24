using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingProject.Data;
using WebProgrammingProject.Models;

namespace WebProgrammingProject.Views
{
    public class JobsUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public JobsUserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // GET: JobsUser
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobsUser.Include(j => j.Advertisement).Include(j => j.UserName);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobsUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsUser = await _context.JobsUser
                .Include(j => j.Advertisement)
                .Include(j => j.UserName)
                .FirstOrDefaultAsync(m => m.JobsUserId == id);
            if (jobsUser == null)
            {
                return NotFound();
            }

            return View(jobsUser);
        }

        // GET: JobsUser/Create
        public IActionResult Create(int id)
        {

            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement.Where(y => y.Id == id), "Id", "Title");
            //ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Title");

            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)), "Id", "NameSurname");
            return View();
        }

        // POST: JobsUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,AdvertisementId,IsAccepted")] JobsUser jobsUser )
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobsUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Title", jobsUser.AdvertisementId);

            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", jobsUser.UserId);
            return View(jobsUser);
        }

        // GET: JobsUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsUser = await _context.JobsUser.FindAsync(id);
            if (jobsUser == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Title", jobsUser.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", jobsUser.UserId);
            return View(jobsUser);
        }

        // POST: JobsUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,AdvertisementId,IsAccepted")] JobsUser jobsUser)
        {
            if (id != jobsUser.JobsUserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobsUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsUserExists(jobsUser.JobsUserId))
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
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement, "Id", "Title", jobsUser.AdvertisementId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", jobsUser.UserId);
            return View(jobsUser);
        }

        // GET: JobsUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobsUser = await _context.JobsUser
                .Include(j => j.Advertisement)
                .Include(j => j.UserName)
                .FirstOrDefaultAsync(m => m.JobsUserId == id);
            if (jobsUser == null)
            {
                return NotFound();
            }

            return View(jobsUser);
        }

        // POST: JobsUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobsUser = await _context.JobsUser.FindAsync(id);
            _context.JobsUser.Remove(jobsUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobsUserExists(int id)
        {
            return _context.JobsUser.Any(e => e.JobsUserId == id);
        }
    }
}
