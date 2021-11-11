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

        public InvoiceArchive ConvertFromInvoice(Invoice invoice)
        {
            InvoiceArchive invoiceArchive = new InvoiceArchive();
            invoiceArchive.StudentFName = invoice.Student.FName;
            // =========== Insert Here ==========

            return invoiceArchive;
        }


        public bool CreateNewEntery(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                InvoiceArchive invoiceArchive = ConvertFromInvoice(invoice);












                _context.Add(invoiceArchive);
                _context.SaveChanges();
                return true;
            }
            return false;
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
