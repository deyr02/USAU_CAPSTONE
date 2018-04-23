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
    public class EnclosureTypesController : Controller
    {
        private readonly USAU_Context _context;

        public EnclosureTypesController(USAU_Context context)
        {
            _context = context;
        }

        // GET: EnclosureTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnclosureTypes.ToListAsync());
        }

        // GET: EnclosureTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosureType = await _context.EnclosureTypes
                .SingleOrDefaultAsync(m => m.EnclosureTypeID == id);
            if (enclosureType == null)
            {
                return NotFound();
            }

            return View(enclosureType);
        }

        // GET: EnclosureTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EnclosureTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnclosureTypeID,Description")] EnclosureType enclosureType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosureType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enclosureType);
        }

        // GET: EnclosureTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosureType = await _context.EnclosureTypes.SingleOrDefaultAsync(m => m.EnclosureTypeID == id);
            if (enclosureType == null)
            {
                return NotFound();
            }
            return View(enclosureType);
        }

        // POST: EnclosureTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnclosureTypeID,Description")] EnclosureType enclosureType)
        {
            if (id != enclosureType.EnclosureTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosureType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnclosureTypeExists(enclosureType.EnclosureTypeID))
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
            return View(enclosureType);
        }

        // GET: EnclosureTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosureType = await _context.EnclosureTypes
                .SingleOrDefaultAsync(m => m.EnclosureTypeID == id);
            if (enclosureType == null)
            {
                return NotFound();
            }

            return View(enclosureType);
        }

        // POST: EnclosureTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosureType = await _context.EnclosureTypes.SingleOrDefaultAsync(m => m.EnclosureTypeID == id);
            _context.EnclosureTypes.Remove(enclosureType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnclosureTypeExists(int id)
        {
            return _context.EnclosureTypes.Any(e => e.EnclosureTypeID == id);
        }
    }
}
