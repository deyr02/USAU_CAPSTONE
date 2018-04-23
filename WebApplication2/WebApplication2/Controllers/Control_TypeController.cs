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
    public class Control_TypeController : Controller
    {
        private readonly USAU_Context _context;

        public Control_TypeController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Control_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.ControlTypes.ToListAsync());
        }

        // GET: Control_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_Type = await _context.ControlTypes
                .SingleOrDefaultAsync(m => m.Control_TypeID == id);
            if (control_Type == null)
            {
                return NotFound();
            }

            return View(control_Type);
        }

        // GET: Control_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Control_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Control_TypeID,Control_Description")] Control_Type control_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(control_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(control_Type);
        }

        // GET: Control_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_Type = await _context.ControlTypes.SingleOrDefaultAsync(m => m.Control_TypeID == id);
            if (control_Type == null)
            {
                return NotFound();
            }
            return View(control_Type);
        }

        // POST: Control_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Control_TypeID,Control_Description")] Control_Type control_Type)
        {
            if (id != control_Type.Control_TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(control_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Control_TypeExists(control_Type.Control_TypeID))
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
            return View(control_Type);
        }

        // GET: Control_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var control_Type = await _context.ControlTypes
                .SingleOrDefaultAsync(m => m.Control_TypeID == id);
            if (control_Type == null)
            {
                return NotFound();
            }

            return View(control_Type);
        }

        // POST: Control_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var control_Type = await _context.ControlTypes.SingleOrDefaultAsync(m => m.Control_TypeID == id);
            _context.ControlTypes.Remove(control_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Control_TypeExists(int id)
        {
            return _context.ControlTypes.Any(e => e.Control_TypeID == id);
        }
    }
}
