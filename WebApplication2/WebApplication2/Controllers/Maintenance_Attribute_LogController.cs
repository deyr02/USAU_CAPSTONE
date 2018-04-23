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
    public class Maintenance_Attribute_LogController : Controller
    {
        private readonly USAU_Context _context;

        public Maintenance_Attribute_LogController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Maintenance_Attribute_Log
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Maintenance_Attribute_Logs.Include(m => m.EnclosureRecord).Include(m => m.Maintenance_Attribute);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Maintenance_Attribute_Log/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance_Attribute_Log = await _context.Maintenance_Attribute_Logs
                .Include(m => m.EnclosureRecord)
                .Include(m => m.Maintenance_Attribute)
                .SingleOrDefaultAsync(m => m.Maintenance_Attribute_LogID == id);
            if (maintenance_Attribute_Log == null)
            {
                return NotFound();
            }

            return View(maintenance_Attribute_Log);
        }

        // GET: Maintenance_Attribute_Log/Create
        public IActionResult Create()
        {
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID");
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID");
            return View();
        }

        // POST: Maintenance_Attribute_Log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Maintenance_Attribute_LogID,Date,Time,Log_Details,Enclosure_Maintenance_AttributeID,EnclosureID")] Maintenance_Attribute_Log maintenance_Attribute_Log)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenance_Attribute_Log);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", maintenance_Attribute_Log.EnclosureID);
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", maintenance_Attribute_Log.Enclosure_Maintenance_AttributeID);
            return View(maintenance_Attribute_Log);
        }

        // GET: Maintenance_Attribute_Log/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance_Attribute_Log = await _context.Maintenance_Attribute_Logs.SingleOrDefaultAsync(m => m.Maintenance_Attribute_LogID == id);
            if (maintenance_Attribute_Log == null)
            {
                return NotFound();
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", maintenance_Attribute_Log.EnclosureID);
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", maintenance_Attribute_Log.Enclosure_Maintenance_AttributeID);
            return View(maintenance_Attribute_Log);
        }

        // POST: Maintenance_Attribute_Log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Maintenance_Attribute_LogID,Date,Time,Log_Details,Enclosure_Maintenance_AttributeID,EnclosureID")] Maintenance_Attribute_Log maintenance_Attribute_Log)
        {
            if (id != maintenance_Attribute_Log.Maintenance_Attribute_LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenance_Attribute_Log);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Maintenance_Attribute_LogExists(maintenance_Attribute_Log.Maintenance_Attribute_LogID))
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
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", maintenance_Attribute_Log.EnclosureID);
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", maintenance_Attribute_Log.Enclosure_Maintenance_AttributeID);
            return View(maintenance_Attribute_Log);
        }

        // GET: Maintenance_Attribute_Log/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance_Attribute_Log = await _context.Maintenance_Attribute_Logs
                .Include(m => m.EnclosureRecord)
                .Include(m => m.Maintenance_Attribute)
                .SingleOrDefaultAsync(m => m.Maintenance_Attribute_LogID == id);
            if (maintenance_Attribute_Log == null)
            {
                return NotFound();
            }

            return View(maintenance_Attribute_Log);
        }

        // POST: Maintenance_Attribute_Log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenance_Attribute_Log = await _context.Maintenance_Attribute_Logs.SingleOrDefaultAsync(m => m.Maintenance_Attribute_LogID == id);
            _context.Maintenance_Attribute_Logs.Remove(maintenance_Attribute_Log);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Maintenance_Attribute_LogExists(int id)
        {
            return _context.Maintenance_Attribute_Logs.Any(e => e.Maintenance_Attribute_LogID == id);
        }
    }
}
