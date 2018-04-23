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
    public class Assign_MaintenanceController : Controller
    {
        private readonly USAU_Context _context;

        public Assign_MaintenanceController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Assign_Maintenance
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Assign_Maintenances.Include(a => a.Enclosure).Include(a => a.Enclosure_Maintenance_Type);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Assign_Maintenance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign_Maintenance = await _context.Assign_Maintenances
                .Include(a => a.Enclosure)
                .Include(a => a.Enclosure_Maintenance_Type)
                .SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (assign_Maintenance == null)
            {
                return NotFound();
            }

            return View(assign_Maintenance);
        }

        // GET: Assign_Maintenance/Create
        public IActionResult Create()
        {
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID");
            ViewData["EnclosureID"] = new SelectList(_context.Enclosure_Maintenance_Types, "Enclosure_Maintenance_TypeID", "Enclosure_Maintenance_TypeID");
            return View();
        }

        // POST: Assign_Maintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnclosureID,Enclosure_Maintenance_TypeID")] Assign_Maintenance assign_Maintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assign_Maintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", assign_Maintenance.EnclosureID);
            ViewData["EnclosureID"] = new SelectList(_context.Enclosure_Maintenance_Types, "Enclosure_Maintenance_TypeID", "Enclosure_Maintenance_TypeID", assign_Maintenance.EnclosureID);
            return View(assign_Maintenance);
        }

        // GET: Assign_Maintenance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign_Maintenance = await _context.Assign_Maintenances.SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (assign_Maintenance == null)
            {
                return NotFound();
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", assign_Maintenance.EnclosureID);
            ViewData["EnclosureID"] = new SelectList(_context.Enclosure_Maintenance_Types, "Enclosure_Maintenance_TypeID", "Enclosure_Maintenance_TypeID", assign_Maintenance.EnclosureID);
            return View(assign_Maintenance);
        }

        // POST: Assign_Maintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnclosureID,Enclosure_Maintenance_TypeID")] Assign_Maintenance assign_Maintenance)
        {
            if (id != assign_Maintenance.EnclosureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assign_Maintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Assign_MaintenanceExists(assign_Maintenance.EnclosureID))
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
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", assign_Maintenance.EnclosureID);
            ViewData["EnclosureID"] = new SelectList(_context.Enclosure_Maintenance_Types, "Enclosure_Maintenance_TypeID", "Enclosure_Maintenance_TypeID", assign_Maintenance.EnclosureID);
            return View(assign_Maintenance);
        }

        // GET: Assign_Maintenance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assign_Maintenance = await _context.Assign_Maintenances
                .Include(a => a.Enclosure)
                .Include(a => a.Enclosure_Maintenance_Type)
                .SingleOrDefaultAsync(m => m.EnclosureID == id);
            if (assign_Maintenance == null)
            {
                return NotFound();
            }

            return View(assign_Maintenance);
        }

        // POST: Assign_Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assign_Maintenance = await _context.Assign_Maintenances.SingleOrDefaultAsync(m => m.EnclosureID == id);
            _context.Assign_Maintenances.Remove(assign_Maintenance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Assign_MaintenanceExists(int id)
        {
            return _context.Assign_Maintenances.Any(e => e.EnclosureID == id);
        }
    }
}
