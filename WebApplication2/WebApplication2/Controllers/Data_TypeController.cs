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
    public class Data_TypeController : Controller
    {
        private readonly USAU_Context _context;

        public Data_TypeController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Data_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataTypes.ToListAsync());
        }

        // GET: Data_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data_Type = await _context.DataTypes
                .SingleOrDefaultAsync(m => m.Data_TypeID == id);
            if (data_Type == null)
            {
                return NotFound();
            }

            return View(data_Type);
        }

        // GET: Data_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Data_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Data_TypeID,Data_Type_Descripton")] Data_Type data_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(data_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(data_Type);
        }

        // GET: Data_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data_Type = await _context.DataTypes.SingleOrDefaultAsync(m => m.Data_TypeID == id);
            if (data_Type == null)
            {
                return NotFound();
            }
            return View(data_Type);
        }

        // POST: Data_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Data_TypeID,Data_Type_Descripton")] Data_Type data_Type)
        {
            if (id != data_Type.Data_TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(data_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Data_TypeExists(data_Type.Data_TypeID))
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
            return View(data_Type);
        }

        // GET: Data_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data_Type = await _context.DataTypes
                .SingleOrDefaultAsync(m => m.Data_TypeID == id);
            if (data_Type == null)
            {
                return NotFound();
            }

            return View(data_Type);
        }

        // POST: Data_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var data_Type = await _context.DataTypes.SingleOrDefaultAsync(m => m.Data_TypeID == id);
            _context.DataTypes.Remove(data_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Data_TypeExists(int id)
        {
            return _context.DataTypes.Any(e => e.Data_TypeID == id);
        }
    }
}
