using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Control_valueController : Controller
    {
        private readonly USAU_Context _context;

        public Control_valueController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Control_value
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Control_Values.Include(c => c.Enclosure_Maintenance_Attribute);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Control_value/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_value = await _context.Control_Values
                .Include(c => c.Enclosure_Maintenance_Attribute)
                .SingleOrDefaultAsync(m => m.Control_ValueID == id);
            if (control_value == null)
            {
                return NotFound();
            }

            return View(control_value);
        }

        // GET: Control_value/Create
        public IActionResult Create()
        {
            ViewData["Attribute_Name"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Attribute_Name");
            return View();
        }

        // POST: Control_value/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Control_ValueID,Control_Value_Description,Enclosure_Maintenance_AttributeID")] Control_value control_value)
        {
            if (ModelState.IsValid)
            {
                _context.Add(control_value);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", control_value.Enclosure_Maintenance_AttributeID);
            return View(control_value);
        }

        // GET: Control_value/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_value = await _context.Control_Values.SingleOrDefaultAsync(m => m.Control_ValueID == id);
            if (control_value == null)
            {
                return NotFound();
            }
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", control_value.Enclosure_Maintenance_AttributeID);
            return View(control_value);
        }

        // POST: Control_value/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Control_ValueID,Control_Value_Description,Enclosure_Maintenance_AttributeID")] Control_value control_value)
        {
            if (id != control_value.Control_ValueID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(control_value);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Control_valueExists(control_value.Control_ValueID))
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
            ViewData["Enclosure_Maintenance_AttributeID"] = new SelectList(_context.Enclosure_Maintenance_Attributes, "Enclosure_Maintenance_AttributeID", "Enclosure_Maintenance_AttributeID", control_value.Enclosure_Maintenance_AttributeID);
            return View(control_value);
        }

        // GET: Control_value/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_value = await _context.Control_Values
                .Include(c => c.Enclosure_Maintenance_Attribute)
                .SingleOrDefaultAsync(m => m.Control_ValueID == id);
            if (control_value == null)
            {
                return NotFound();
            }

            return View(control_value);
        }

        // POST: Control_value/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var control_value = await _context.Control_Values.SingleOrDefaultAsync(m => m.Control_ValueID == id);
            _context.Control_Values.Remove(control_value);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Control_valueExists(int id)
        {
            return _context.Control_Values.Any(e => e.Control_ValueID == id);
        }
    }
}
