using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contract;

namespace MusArticle.Controllers
{
    public class MuseumsController : Controller
    {
        private readonly RepositoryContext _context;
        private ILoggerManager _logger;

        public MuseumsController(RepositoryContext context, ILoggerManager logger)
        {
            _context = context;
            _logger = logger;

        }

        // GET: Museums
        public async Task<IActionResult> Index(string? theme)
        {
            if(theme == null)
            {
                
                return View(await _context.Museums.ToListAsync());
            }
            return View(await _context.Museums.Where(x=>x.Theme==theme).ToListAsync());
        }

        // GET: Museums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (museum == null)
            {
                return NotFound();
            }

            return View(museum);
        }

        // GET: Museums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Museums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Theme")] Museum museum)
        {
            if (ModelState.IsValid)
            {
                    museum.Id = Guid.NewGuid();
                    _context.Add(museum);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
            }
            return View(museum);
        }

        // GET: Museums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museums.FindAsync(id);
            if (museum == null)
            {
                return NotFound();
            }
            return View(museum);
        }

        // POST: Museums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Theme")] Museum museum)
        {
            if (id != museum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(museum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuseumExists(museum.Id))
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
            return View(museum);
        }

        // GET: Museums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var museum = await _context.Museums
                .FirstOrDefaultAsync(m => m.Id == id);
            if (museum == null)
            {
                return NotFound();
            }

            return View(museum);
        }

        // POST: Museums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var museum = await _context.Museums.FindAsync(id);
            _context.Museums.Remove(museum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuseumExists(Guid id)
        {
            return _context.Museums.Any(e => e.Id == id);
        }
    }
}
