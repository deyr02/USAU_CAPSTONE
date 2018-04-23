using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class EnclosuresController : Controller
    {
        private readonly USAU_Context _context;

        public EnclosuresController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Enclosures
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Enclosures.Include(e => e.EnclosureType);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Enclosures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures
                .Include(e => e.EnclosureType)
                .SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // GET: Enclosures/Create
        public IActionResult Create()
        {
            ViewData["EnclosureTypeID"] = new SelectList(_context.EnclosureTypes, "EnclosureTypeID", "EnclosureTypeID");
            return View();
        }

        // POST: Enclosures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnclosureID,Enclosure_Description,Location,Size,Layout_Path,Material_Used,Physical_photo,Enclosure_Status,EnclosureTypeID")] Enclosure enclosure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureTypeID"] = new SelectList(_context.EnclosureTypes, "EnclosureTypeID", "EnclosureTypeID", enclosure.EnclosureTypeID);
            return View(enclosure);
        }

        // GET: Enclosures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures.SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (enclosure == null)
            {
                return NotFound();
            }
            ViewData["EnclosureTypeID"] = new SelectList(_context.EnclosureTypes, "EnclosureTypeID", "EnclosureTypeID", enclosure.EnclosureTypeID);
            return View(enclosure);
        }

        // POST: Enclosures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnclosureID,Enclosure_Description,Location,Size,Layout_Path,Material_Used,Physical_photo,Enclosure_Status,EnclosureTypeID")] Enclosure enclosure)
        {
            if (id != enclosure.EnclosureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnclosureExists(enclosure.EnclosureID))
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
            ViewData["EnclosureTypeID"] = new SelectList(_context.EnclosureTypes, "EnclosureTypeID", "EnclosureTypeID", enclosure.EnclosureTypeID);
            return View(enclosure);
        }

        // GET: Enclosures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure = await _context.Enclosures
                .Include(e => e.EnclosureType)
                .SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (enclosure == null)
            {
                return NotFound();
            }

            return View(enclosure);
        }

        // POST: Enclosures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosure = await _context.Enclosures.SingleOrDefaultAsync(m => m.EnclosureID == id);
            _context.Enclosures.Remove(enclosure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnclosureExists(int id)
        {
            return _context.Enclosures.Any(e => e.EnclosureID == id);
        }
    }
}
