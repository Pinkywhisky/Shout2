using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shout.DAL;
using Shout.Models;

namespace Shout.Controllers
{
    public class ShoutsController : Controller
    {
        private readonly ShoutContext _context;

        public ShoutsController()
        {
            _context = new ShoutContext();
        }

        // GET: Shouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shouts.ToListAsync());
        }

        // GET: Shouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shouts = await _context.Shouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shouts == null)
            {
                return NotFound();
            }

            return View(shouts);
        }

        // GET: Shouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Publication,DatePublication")] Shouts shouts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shouts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shouts);
        }

        // GET: Shouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shouts = await _context.Shouts.FindAsync(id);
            if (shouts == null)
            {
                return NotFound();
            }
            return View(shouts);
        }

        // POST: Shouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Publication,DatePublication")] Shouts shouts)
        {
            if (id != shouts.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shouts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoutsExists(shouts.Id))
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
            return View(shouts);
        }

        // GET: Shouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shouts = await _context.Shouts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shouts == null)
            {
                return NotFound();
            }

            return View(shouts);
        }

        // POST: Shouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shouts = await _context.Shouts.FindAsync(id);
            _context.Shouts.Remove(shouts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoutsExists(int id)
        {
            return _context.Shouts.Any(e => e.Id == id);
        }
    }
}
