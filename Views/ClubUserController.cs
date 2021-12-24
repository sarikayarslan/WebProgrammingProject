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
    public class ClubUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ClubUserController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ClubUser
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClubUser.Include(c => c.Club).Include(c => c.User);
            var user = new SelectList(_context.Users.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)), "Id", "Id").FirstOrDefault();
;
            return View(await applicationDbContext.Where(x=>x.User.Id ==user.Value).ToListAsync());
        }

        // GET: ClubUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubUser = await _context.ClubUser
                .Include(c => c.Club)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubUser == null)
            {
                return NotFound();
            }

            return View(clubUser);
        }

        // GET: ClubUser/Create
        public IActionResult Create()
        {
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName");
            //ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname");
            ViewData["UserId"] = new SelectList(_context.Users.Where(x => x.Id == _userManager.GetUserId(HttpContext.User)), "Id", "NameSurname");

            return View();
        }

        // POST: ClubUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ClubId,UserMission,JoinDate")] ClubUser clubUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", clubUser.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", clubUser.UserId);
            return View(clubUser);
        }

        // GET: ClubUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubUser = await _context.ClubUser.FindAsync(id);
            if (clubUser == null)
            {
                return NotFound();
            }
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", clubUser.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", clubUser.UserId);
            return View(clubUser);
        }

        // POST: ClubUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ClubId,UserMission,JoinDate")] ClubUser clubUser)
        {
            if (id != clubUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubUserExists(clubUser.Id))
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
            ViewData["ClubId"] = new SelectList(_context.Club, "Id", "ClubName", clubUser.ClubId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "NameSurname", clubUser.UserId);
            return View(clubUser);
        }

        // GET: ClubUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubUser = await _context.ClubUser
                .Include(c => c.Club)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clubUser == null)
            {
                return NotFound();
            }

            return View(clubUser);
        }

        // POST: ClubUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubUser = await _context.ClubUser.FindAsync(id);
            _context.ClubUser.Remove(clubUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubUserExists(int id)
        {
            return _context.ClubUser.Any(e => e.Id == id);
        }
    }
}
