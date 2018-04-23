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
    public class Enclosure_Maintenance_AttributeController : Controller
    {
        private readonly USAU_Context _context;

        public Enclosure_Maintenance_AttributeController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Enclosure_Maintenance_Attribute
        public async Task<IActionResult> Index()
        {
            var uSAU_Context = _context.Enclosure_Maintenance_Attributes.Include(e => e.ControlType)
                .Include(D => D.Data_Type)
                .Include(M => M.Enclosure_Maintenance_Type);
            return View(await uSAU_Context.ToListAsync());
        }

        // GET: Enclosure_Maintenance_Attribute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure_Maintenance_Attribute = await _context.Enclosure_Maintenance_Attributes
                .Include(e => e.ControlType)
                .SingleOrDefaultAsync(m => m.Enclosure_Maintenance_AttributeID == id);
            if (enclosure_Maintenance_Attribute == null)
            {
                return NotFound();
            }

            return View(enclosure_Maintenance_Attribute);
        }

        // GET: Enclosure_Maintenance_Attribute/Create
        public IActionResult Create()
        {
            ViewData["Control_Description"] = new SelectList(_context.ControlTypes, "Control_TypeID", "Control_Description");
            ViewData["Data_Type_Descripton"] = new SelectList(_context.DataTypes, "Data_TypeID", "Data_Type_Descripton");
            ViewData["Maintenacne_Description"] = new SelectList(_context.Enclosure_Maintenance_Types, "Enclosure_Maintenance_TypeID", "Maintenacne_Description");
            return View();
        }

        // POST: Enclosure_Maintenance_Attribute/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enclosure_Maintenance_AttributeID,Attribute_Name,Unit,Max_value,Mind_value,Error_Message,ControlTypeID,Data_TypeID,Enclosure_Maintenance_TypeID")] Enclosure_Maintenance_Attribute enclosure_Maintenance_Attribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosure_Maintenance_Attribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Control_TypeID", "Control_TypeID", enclosure_Maintenance_Attribute.ControlTypeID);
            return View(enclosure_Maintenance_Attribute);
        }

        // GET: Enclosure_Maintenance_Attribute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure_Maintenance_Attribute = await _context.Enclosure_Maintenance_Attributes.SingleOrDefaultAsync(m => m.Enclosure_Maintenance_AttributeID == id);
            if (enclosure_Maintenance_Attribute == null)
            {
                return NotFound();
            }
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Control_TypeID", "Control_TypeID", enclosure_Maintenance_Attribute.ControlTypeID);
            return View(enclosure_Maintenance_Attribute);
        }

        // POST: Enclosure_Maintenance_Attribute/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Enclosure_Maintenance_AttributeID,Attribute_Name,Unit,Max_value,Mind_value,Error_Message,ControlTypeID,Data_TypeID,Enclosure_Maintenance_TypeID")] Enclosure_Maintenance_Attribute enclosure_Maintenance_Attribute)
        {
            if (id != enclosure_Maintenance_Attribute.Enclosure_Maintenance_AttributeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure_Maintenance_Attribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enclosure_Maintenance_AttributeExists(enclosure_Maintenance_Attribute.Enclosure_Maintenance_AttributeID))
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
            ViewData["ControlTypeID"] = new SelectList(_context.ControlTypes, "Control_TypeID", "Control_TypeID", enclosure_Maintenance_Attribute.ControlTypeID);
            return View(enclosure_Maintenance_Attribute);
        }

        // GET: Enclosure_Maintenance_Attribute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure_Maintenance_Attribute = await _context.Enclosure_Maintenance_Attributes
                .Include(e => e.ControlType)
                .SingleOrDefaultAsync(m => m.Enclosure_Maintenance_AttributeID == id);
            if (enclosure_Maintenance_Attribute == null)
            {
                return NotFound();
            }

            return View(enclosure_Maintenance_Attribute);
        }

        // POST: Enclosure_Maintenance_Attribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosure_Maintenance_Attribute = await _context.Enclosure_Maintenance_Attributes.SingleOrDefaultAsync(m => m.Enclosure_Maintenance_AttributeID == id);
            _context.Enclosure_Maintenance_Attributes.Remove(enclosure_Maintenance_Attribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Enclosure_Maintenance_AttributeExists(int id)
        {
            return _context.Enclosure_Maintenance_Attributes.Any(e => e.Enclosure_Maintenance_AttributeID == id);
        }
    }
}
