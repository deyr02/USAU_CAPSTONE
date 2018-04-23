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
    public class Temperature_TimeController : Controller
    {
        private readonly USAU_Context _context;

        public Temperature_TimeController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Temperature_Time
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Temperature_Times.Include(t => t.Enclsoure).Include(t => t.Time);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Temperature_Time/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature_Time = await _context.Temperature_Times
                .Include(t => t.Enclsoure)
                .Include(t => t.Time)
                .SingleOrDefaultAsync(m => m.Temperature_TimeID == id);
            if (temperature_Time == null)
            {
                return NotFound();
            }

            return View(temperature_Time);
        }

        // GET: Temperature_Time/Create
        public IActionResult Create()
        {
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID");
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "TimeID");
            return View();
        }

        // POST: Temperature_Time/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Temperature_TimeID,EnclosureID,TimeID")] Temperature_Time temperature_Time)
        {
            if (ModelState.IsValid)
            {
                _context.Add(temperature_Time);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", temperature_Time.EnclosureID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "TimeID", temperature_Time.TimeID);
            return View(temperature_Time);
        }

        // GET: Temperature_Time/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature_Time = await _context.Temperature_Times.SingleOrDefaultAsync(m => m.Temperature_TimeID == id);
            if (temperature_Time == null)
            {
                return NotFound();
            }
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", temperature_Time.EnclosureID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "TimeID", temperature_Time.TimeID);
            return View(temperature_Time);
        }

        // POST: Temperature_Time/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Temperature_TimeID,EnclosureID,TimeID")] Temperature_Time temperature_Time)
        {
            if (id != temperature_Time.Temperature_TimeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(temperature_Time);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Temperature_TimeExists(temperature_Time.Temperature_TimeID))
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
            ViewData["EnclosureID"] = new SelectList(_context.Enclosures, "EnclosureID", "EnclosureID", temperature_Time.EnclosureID);
            ViewData["TimeID"] = new SelectList(_context.Times, "TimeID", "TimeID", temperature_Time.TimeID);
            return View(temperature_Time);
        }

        // GET: Temperature_Time/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var temperature_Time = await _context.Temperature_Times
                .Include(t => t.Enclsoure)
                .Include(t => t.Time)
                .SingleOrDefaultAsync(m => m.Temperature_TimeID == id);
            if (temperature_Time == null)
            {
                return NotFound();
            }

            return View(temperature_Time);
        }

        // POST: Temperature_Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var temperature_Time = await _context.Temperature_Times.SingleOrDefaultAsync(m => m.Temperature_TimeID == id);
            _context.Temperature_Times.Remove(temperature_Time);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Temperature_TimeExists(int id)
        {
            return _context.Temperature_Times.Any(e => e.Temperature_TimeID == id);
        }
    }
}
