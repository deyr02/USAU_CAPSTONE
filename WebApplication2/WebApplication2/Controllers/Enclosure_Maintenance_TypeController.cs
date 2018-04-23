using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Enclosure_Maintenance_TypeController : Controller
    {
        private readonly USAU_Context _context;

        public Enclosure_Maintenance_TypeController(USAU_Context context)
        {
            _context = context;
        }

        // GET: Enclosure_Maintenance_Type
        public async Task<IActionResult> Index()
        {
            return View(await _context.Enclosure_Maintenance_Types.ToListAsync());
        }

        // GET: Enclosure_Maintenance_Type/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types
            //  .SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);
            var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types
                .Include(EMT => EMT.Enclosure_Maintenance_Attributes)
                .ThenInclude(C =>C.ControlType)
                .Include(EMT => EMT.Enclosure_Maintenance_Attributes)
                .ThenInclude(E => E.Data_Type)
            
                .AsNoTracking().SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);

            if (enclosure_Maintenance_Type == null)
            {
                return NotFound();
            }

            return View(enclosure_Maintenance_Type);
        }

        /// <summary>
        /// Generate_Form
        /// This method will help to to retrieve the date form the database to generate dynamic web form in the view
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> Generate_Form(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types
            //  .SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);
            var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types
                .Include(EMT => EMT.Enclosure_Maintenance_Attributes)
                .ThenInclude(C => C.ControlType)
                .Include(EMT => EMT.Enclosure_Maintenance_Attributes)
                .ThenInclude(E => E.Data_Type)
                .Include (CV => CV.Enclosure_Maintenance_Attributes)
                .ThenInclude(CVS =>CVS.Control_Values)

                .AsNoTracking().SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);

            if (enclosure_Maintenance_Type == null)
            {
                return NotFound();
            }

            return View(enclosure_Maintenance_Type);
        }

        // GET: Enclosure_Maintenance_Type/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enclosure_Maintenance_Type/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Enclosure_Maintenance_TypeID,Maintenacne_Description,Days")] Enclosure_Maintenance_Type enclosure_Maintenance_Type)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enclosure_Maintenance_Type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(enclosure_Maintenance_Type);
        }

        // GET: Enclosure_Maintenance_Type/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types.SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);
            if (enclosure_Maintenance_Type == null)
            {
                return NotFound();
            }
            return View(enclosure_Maintenance_Type);
        }

        // POST: Enclosure_Maintenance_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Enclosure_Maintenance_TypeID,Maintenacne_Description,Days")] Enclosure_Maintenance_Type enclosure_Maintenance_Type)
        {
            if (id != enclosure_Maintenance_Type.Enclosure_Maintenance_TypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enclosure_Maintenance_Type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Enclosure_Maintenance_TypeExists(enclosure_Maintenance_Type.Enclosure_Maintenance_TypeID))
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
            return View(enclosure_Maintenance_Type);
        }

        // GET: Enclosure_Maintenance_Type/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types
                .SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);
            if (enclosure_Maintenance_Type == null)
            {
                return NotFound();
            }

            return View(enclosure_Maintenance_Type);
        }

        // POST: Enclosure_Maintenance_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enclosure_Maintenance_Type = await _context.Enclosure_Maintenance_Types.SingleOrDefaultAsync(m => m.Enclosure_Maintenance_TypeID == id);
            _context.Enclosure_Maintenance_Types.Remove(enclosure_Maintenance_Type);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Enclosure_Maintenance_TypeExists(int id)
        {
            return _context.Enclosure_Maintenance_Types.Any(e => e.Enclosure_Maintenance_TypeID == id);
        }
    }
}
