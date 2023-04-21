using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuffyHealthNew.Data;
using TuffyHealthNew.Models;

namespace TuffyHealthNew.Controllers
{
    public class PatientLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PatientLogs
        public async Task<IActionResult> Medications()
        {
            var model = await _context.PatientLogs.Include("Treatments")
                             .Where(a => a.ApplicationUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                                && a.Treatments.TreatmentType == "Medication")
                             .ToListAsync();
            return View(model);
            
        }

        public async Task<IActionResult> Tests()
        {
            var model = await _context.PatientLogs.Include("Treatments")
                             .Where(a => a.ApplicationUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                                && a.Treatments.TreatmentType == "Test")
                             .ToListAsync();
            return View(model);

        }

        public async Task<IActionResult> Vaccines()
        {
            var model = await _context.PatientLogs.Include("Treatments")
                             .Where(a => a.ApplicationUser.Id == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value
                                && a.Treatments.TreatmentType == "Vaccine")
                             .ToListAsync();
            return View(model);

        }
        // GET: PatientLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PatientLogs == null)
            {
                return NotFound();
            }

            var patientLogs = await _context.PatientLogs
                .FirstOrDefaultAsync(m => m.TreatmentID == id);
            if (patientLogs == null)
            {
                return NotFound();
            }

            return View(patientLogs);
        }

        // GET: PatientLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TreatmentID,Patient_log_date,Dosage,Result")] PatientLogs patientLogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientLogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientLogs);
        }

        // GET: PatientLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PatientLogs == null)
            {
                return NotFound();
            }

            var patientLogs = await _context.PatientLogs.FindAsync(id);
            if (patientLogs == null)
            {
                return NotFound();
            }
            return View(patientLogs);
        }

        // POST: PatientLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TreatmentID,Patient_log_date,Dosage,Result")] PatientLogs patientLogs)
        {
            if (id != patientLogs.TreatmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientLogsExists(patientLogs.TreatmentID))
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
            return View(patientLogs);
        }

        // GET: PatientLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PatientLogs == null)
            {
                return NotFound();
            }

            var patientLogs = await _context.PatientLogs
                .FirstOrDefaultAsync(m => m.TreatmentID == id);
            if (patientLogs == null)
            {
                return NotFound();
            }

            return View(patientLogs);
        }

        // POST: PatientLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PatientLogs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PatientLogs'  is null.");
            }
            var patientLogs = await _context.PatientLogs.FindAsync(id);
            if (patientLogs != null)
            {
                _context.PatientLogs.Remove(patientLogs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientLogsExists(int id)
        {
          return (_context.PatientLogs?.Any(e => e.TreatmentID == id)).GetValueOrDefault();
        }
    }
}
