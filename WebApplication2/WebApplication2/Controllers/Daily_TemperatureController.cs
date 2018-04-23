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
    public class Daily_TemperatureController : Controller
    {
        private readonly USAU_Context _context;

        public Daily_TemperatureController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Daily_Temperature
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Daily_Temperatures.Include(d => d.Teperature_Time);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Daily_Temperature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily_Temperature = await _context.Daily_Temperatures
                .Include(d => d.Teperature_Time)
                .SingleOrDefaultAsync(m => m.Daily_TemperatureID == id);
            if (daily_Temperature == null)
            {
                return NotFound();
            }

            return View(daily_Temperature);
        }

        // GET: Daily_Temperature/Create
        public IActionResult Create()
        {
            ViewData["Temperature_TimeID"] = new SelectList(_context.Temperature_Times, "Temperature_TimeID", "Temperature_TimeID");
            return View();
        }

        // POST: Daily_Temperature/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Daily_TemperatureID,Reproting_Date,Temperature,Temperature_TimeID")] Daily_Temperature daily_Temperature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daily_Temperature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Temperature_TimeID"] = new SelectList(_context.Temperature_Times, "Temperature_TimeID", "Temperature_TimeID", daily_Temperature.Temperature_TimeID);
            return View(daily_Temperature);
        }

        // GET: Daily_Temperature/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily_Temperature = await _context.Daily_Temperatures.SingleOrDefaultAsync(m => m.Daily_TemperatureID == id);
            if (daily_Temperature == null)
            {
                return NotFound();
            }
            ViewData["Temperature_TimeID"] = new SelectList(_context.Temperature_Times, "Temperature_TimeID", "Temperature_TimeID", daily_Temperature.Temperature_TimeID);
            return View(daily_Temperature);
        }

        // POST: Daily_Temperature/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Daily_TemperatureID,Reproting_Date,Temperature,Temperature_TimeID")] Daily_Temperature daily_Temperature)
        {
            if (id != daily_Temperature.Daily_TemperatureID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daily_Temperature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Daily_TemperatureExists(daily_Temperature.Daily_TemperatureID))
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
            ViewData["Temperature_TimeID"] = new SelectList(_context.Temperature_Times, "Temperature_TimeID", "Temperature_TimeID", daily_Temperature.Temperature_TimeID);
            return View(daily_Temperature);
        }

        // GET: Daily_Temperature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var daily_Temperature = await _context.Daily_Temperatures
                .Include(d => d.Teperature_Time)
                .SingleOrDefaultAsync(m => m.Daily_TemperatureID == id);
            if (daily_Temperature == null)
            {
                return NotFound();
            }

            return View(daily_Temperature);
        }

        // POST: Daily_Temperature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daily_Temperature = await _context.Daily_Temperatures.SingleOrDefaultAsync(m => m.Daily_TemperatureID == id);
            _context.Daily_Temperatures.Remove(daily_Temperature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Daily_TemperatureExists(int id)
        {
            return _context.Daily_Temperatures.Any(e => e.Daily_TemperatureID == id);
        }
    }
}
