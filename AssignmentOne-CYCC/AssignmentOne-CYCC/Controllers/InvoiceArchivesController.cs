using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentOne_CYCC.Data;
using AssignmentOne_CYCC.Models;

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
            return View(await _context.InvoiceArchive.ToListAsync());
        }

        // GET: InvoiceArchives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceArchive = await _context.InvoiceArchive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceArchive == null)
            {
                return NotFound();
            }

            return View(invoiceArchive);
        }
        

        // GET: InvoiceArchives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceArchive = await _context.InvoiceArchive
                .FirstOrDefaultAsync(m => m.Id == id);
            if (invoiceArchive == null)
            {
                return NotFound();
            }

            return View(invoiceArchive);
        }

        // POST: InvoiceArchives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceArchive = await _context.InvoiceArchive.FindAsync(id);
            _context.InvoiceArchive.Remove(invoiceArchive);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceArchiveExists(int id)
        {
            return _context.InvoiceArchive.Any(e => e.Id == id);
        }
    }
}
