using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentOne_CYCC.Data;
using AssignmentOne_CYCC.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace AssignmentOne_CYCC.Controllers
{
    public class InvoiceArchivesController : Controller
    {
        private readonly AssignmentOne_CYCCContext _context;

        public InvoiceArchivesController(AssignmentOne_CYCCContext context)
        {
            _context = context;
        }

        // GET: InvoiceArchives
        public async Task<IActionResult> Index()
        {
            IncludeInvoiceAndCostData();
            var invoice = _context.Invoice.Include(m => m.Student).ToList<Invoice>().Where(m => m.InvoicePaid == true);
            return View(invoice);
        }

        // GET: InvoiceArchives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }
            IncludeInvoiceAndCostData();
            return View(invoice);
        }
        

        // GET: InvoiceArchives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = await _context.Invoice
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: InvoiceArchives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.FindAsync(id);
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceArchiveExists(int id)
        {
            return _context.InvoiceArchive.Any(e => e.Id == id);
        }

        private IIncludableQueryable<Invoice, ICollection<Lesson>> IncludeInvoiceAndCostData(int? Id = null)
        {
            var modelValue = _context.Invoice.Include(m => m.Student).Include(m => m.Lesson);
            // Only set values used (if Id is supplied).
            if (Id != null) modelValue.Where(m => m.Id == Id);

            foreach (var m in modelValue)
            {
                foreach (var l in m.Lesson)
                {
                    l.Duration = _context.Duration.Where(d => d.Id == l.DurationId).FirstOrDefault();
                }
            }
            return modelValue;
        }
    }
}
