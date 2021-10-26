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

using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Net;
using System.IO;
using System.Web;

// Custom Email Generator Classes
using RazorHtmlEmails.RazorClassLib.Services;
using RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;

namespace AssignmentOne_CYCC.Controllers
{
    public enum StatusEnum { success, invalidInvoice, invalidStudent, viewError };
    public class InvoicesController : Controller
    {
        private readonly AssignmentOne_CYCCContext _context;
        private readonly IConfiguration _config;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public InvoicesController(AssignmentOne_CYCCContext context, IConfiguration configuration, IRazorViewToStringRenderer razorViewToStringRenderer)
        {
            _context = context;
            _config = configuration;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }
        // Custom Function.
        /// <summary>
        /// Populates 'Invoice->Lesson()->Duration' references.
        /// Also returns the Invoice model entity for optional use.
        /// </summary>
        /// <param name="Id">(optional) Id of Invoice to populate/return. Populates/Returns all when omitted.</param>
        /// <returns>IIncludableQueryable<Invoice, ICollection<Lesson>> - Invoice model with lesson and duration included.</returns>
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

        // GET: Invoices
        /// <summary>
        /// Renders the Index page.
        /// (optional) Takes either a 'success' or 'error' message from GET to be displayed.
        /// </summary>
        /// <returns>ViewResult - Invoice.Index</returns>
        public async Task<IActionResult> Index()
        {

            ViewBag.success = Request.Query["success"].ToString();
            ViewBag.error = Request.Query["error"].ToString();

            IncludeInvoiceAndCostData();

            return View(await _context.Invoice.Include(m => m.Student).Include(m => m.Lesson).ToListAsync());
        }


        // GET: Invoices/Details/5
        /// <summary>
        /// Returns the Details page.
        /// (optional) Takes either a 'success' or 'error' message from GET to be displayed.
        /// </summary>
        /// <param name="id">Id of Invoice to display.</param>
        /// <returns>ViewResult - Invoice.Details | NotFoundResult</returns>
        public async Task<IActionResult> Details(int? id)
        {
            // Checks if Id is set.
            if (id == null)
            {
                return NotFound();
            }
            // Gets success/error message if exists.
            ViewBag.success = Request.Query["success"].ToString();
            ViewBag.error = Request.Query["error"].ToString();

            // Try to get Invoice of Id == id.
            IncludeInvoiceAndCostData(id);
            /*var modelValue = _context.Invoice.Include(m => m.Student).Include(m => m.Lesson).Where(m => m.Id == id);

			foreach (var m in modelValue) {
				foreach (var l in m.Lesson) {
					l.Duration = _context.Duration.Where(d => d.Id == l.DurationId).FirstOrDefault();
				}
			}*/

            // Include Students into invoice model instance.
            var invoice = await _context.Invoice
                .Include(m => m.Student)
                //.Include(m => m.Lesson)
                .FirstOrDefaultAsync(m => m.Id == id);
            // If model returns NULL, no Invoice of Id == id exists, return NotFoundResult.
            if (invoice == null)
            {
                return NotFound();
            }
            // Return the Details page, passing the invoice model data.
            return View(invoice);
        }

        // GET: Invoices/Create
        /// <summary>
        /// Returns the Create page.
        /// (optional GET) Takes Id of student to 'lock-in', preselecting and setting the field to 'readonly'.
        /// </summary>
        /// <param name="id">(optional GET parameter) Id of student to 'Lock-in'.</param>
        /// <returns>ViewResult - Invoice.Details</returns>
        public async Task<IActionResult> Create(int? id = null)
        {
            // If a valid student Id is passed to the create page, tell view to lock that student in.
            // Else render the page as normal.
            if (id != null && id >= 0 && _context.Students.Any(ag => ag.Id == id))
            {
                ViewBag.LockStudent = id;
                ViewBag.LockStudentName = _context.Students.Find(id).FullName;
            }
            else
            {
                ViewBag.LockStudent = -1;
                ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
            }
            // Get default Information from last record.
            ViewBag.Comment = "";
            ViewBag.Signature = "";
            ViewBag.Bank = "";
            ViewBag.AccountName = "";
            ViewBag.AccountNo = "";
            ViewBag.BSB = "";
            ViewBag.Term = "";
            ViewBag.Year = "";
            ViewBag.TermStartDate = "";
            ViewBag.PaymentFinalDate = "";

            if (_context.Invoice.Count() > 0)
            {
                ViewBag.Comment = _context.Invoice.OrderBy(ag => ag.Id).Last().Comment;
                ViewBag.Signature = _context.Invoice.OrderBy(ag => ag.Id).Last().Signature;
                ViewBag.Bank = _context.Invoice.OrderBy(ag => ag.Id).Last().Bank;
                ViewBag.AccountName = _context.Invoice.OrderBy(ag => ag.Id).Last().AccountName;
                ViewBag.AccountNo = _context.Invoice.OrderBy(ag => ag.Id).Last().AccountNo;
                ViewBag.BSB = _context.Invoice.OrderBy(ag => ag.Id).Last().BSB;
                ViewBag.Term = _context.Invoice.OrderBy(ag => ag.Id).Last().Term;
                ViewBag.Year = _context.Invoice.OrderBy(ag => ag.Id).Last().Year;
                ViewBag.TermStartDate = _context.Invoice.OrderBy(ag => ag.Id).Last().TermStartDate.ToString("yyyy-MM-dd");
                ViewBag.PaymentFinalDate = _context.Invoice.OrderBy(ag => ag.Id).Last().PaymentFinalDate.ToString("yyyy-MM-dd");
            }



            // Provide data on lessons for View.
            ViewBag.Lessons = new SelectList(_context.Lesson, "id", "LessonTime", _context.Invoice);
            // If id is set, get student information, and check if the student id is valid (returning NotFoundResult if invalid).
            if (id != null) {
                var Student = await _context.Students
                    .FirstOrDefaultAsync(m => m.Id == id);

                if (Student == null) {
                    return NotFound();
                }
            }
            return View();

        }

        // POST: Invoices/Create
        /// <summary>
        /// POST Handler for the Create page.
        /// Handles Form data, validation and saving to the database.
        /// </summary>
        /// <param name="invoice">Form Data to be bound to model.</param>
        /// <returns>ViewResult - Invoice->Create (fail) | ViewResult - Invoice->GenerateInvoice (success)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,Comment,Signature,Bank,AccountName,AccountNo,BSB,Term,Year,Semester,TermStartDate,PaymentFinalDate")] Invoice invoice)
        {
            // Check if any data is provided, else redirect back to form page.
            if (invoice == null) return RedirectToAction(nameof(Create));
            // Check if Student.Id exists, else return an error message.
            if (_context.Students.Any(ag => ag.Id == invoice.StudentId)) {

                // Get all lessons linked to this Student that: Have NOT been paid AND are NOT already associated with another Invoice.
                IEnumerable<Lesson> lessonQuery =
                    from lesson in _context.Lesson
                    where lesson.StudentId == invoice.StudentId && lesson.Paid == false && lesson.InvoiceId == null
                    select lesson;

                // Check if there is no lessons unpaid, not already linked, if there is none return error.
                if (!lessonQuery.Any()) {
                    ModelState.AddModelError("EmptyLessonError", "There are currently no outstanding lessons not already invoiced for this student.");
                    ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
                    return View(invoice);
                }
                // Covert to array.
                invoice.Lesson = lessonQuery.ToArray();

            } else {
                ModelState.AddModelError("StudentId", "The Student provided does not exist. Please select a valid option.");
                ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
                return View(invoice);
            }

            if (ModelState.IsValid)
            {
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SendEmailConfirm), new { id = invoice.Id });  // Redirect to SendEmailConfirm page of same Invoice.
            }
            ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");       // Get data for drop-down.
            return View(invoice);
        }

        // GET: Invoices/Edit/5
        /// <summary>
        /// Returns Invoice->Edit page.
        /// (Required) Takes Id of Invoice.
        /// </summary>
        /// <param name="id">(Required) id of Invoice to edit.</param>
        /// <returns>ViewResult - Invoice->Edit</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            IncludeInvoiceAndCostData(id);
            var invoice = await _context.Invoice.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["StudentNames"] = new SelectList(_context.Students, "Id", "FullName", invoice.StudentId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        /// <summary>
        /// POST Handler for the Edit page.
        /// Handles Form data, validation and updating the database.
        /// </summary>
        /// <param name="id">Id of the Invoice to edit.</param>
        /// <param name="invoice">Form Data to be bound to model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Comment,Signature,Bank,AccountName,AccountNo,BSB,Term,Year,Semester,TermStartDate,PaymentFinalDate")] Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));     // Redirect to Invoice->Index on success.
            }
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        /// <summary>
        /// Returns  Invoice->Delete page.
        /// </summary>
        /// <param name="id">(required) Id of Invoice to delete</param>
        /// <returns>ViewResult - Invoice->Delete</returns>
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

        // POST: Invoices/Delete/5
        /// <summary>
        /// POST Handler for Invoice-Delete.
        /// Handles Form data, validation and deleting from the database.
        /// </summary>
        /// <param name="id">(Required) Invoice Id to delete.</param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoice = await _context.Invoice.Include(m => m.Lesson).FirstOrDefaultAsync(m => m.Id == id);
            // Clear reference in lesson model, severing the relationship so that the invoice can be deleted. 
            // Lesson.Paid is set to false, as a lesson cannot be paid if there is no invoice associated with it.
            foreach (Lesson lesson in invoice.Lesson) {
                lesson.InvoiceId = null;
                lesson.Paid = false;
            }
            _context.Invoice.Remove(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoice.Any(e => e.Id == id);
        }

        public async Task<IActionResult> SendEmailConfirm(int id)
        {
            var modelValue = IncludeInvoiceAndCostData(id);
            // Get relevant data.
            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null)
                return View("404");
            Students student = _context.Students.Find(invoice.StudentId);

            // Get a sample of email template.
            ViewBag.content = GetInvoiceAsString((int)id);
            return View(invoice);
        }

        public async Task<IActionResult> SendEmail(int id)
        {
            // Get relevant data.
            var modeldata = IncludeInvoiceAndCostData(id);

            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null) {
                ViewBag.error = "Invalid Invoice";
                return View();
            }

            
            string eSenderHost = _config["smtp:host"];
            string eSenderPwd = _config["smtp:pwd"];
            string eSenderUsername = _config["smtp:username"];
            int eSenderPort = int.Parse(_config["smtp:port"]);
            bool eSenderIsSSL = _config["smtp:isSSL"] == "true" ? true : false;

            string eRecipient = invoice.Student.Email;

            // Generate Email Content
            string content = "Error Generating Invoice"; // Fill default message in case of error.
            try
            {
                InvoiceEmailViewModel invoiceEmailViewModel = new InvoiceEmailViewModel(invoice.Student.FullName, invoice.Student.LName, invoice.Student.FName, invoice.Comment, invoice.Term, invoice.TermStartDate, invoice.PaymentFinalDate, invoice.ReferenceNo, invoice.TotalCost, invoice.Semester, invoice.Student.GuardianName, invoice.Bank, invoice.AccountName, invoice.BSB, invoice.AccountNo, invoice.Signature);
                content = await _razorViewToStringRenderer.RenderViewToStringAsync("InvoiceEmail.cshtml", invoiceEmailViewModel);

            }
            catch (Exception e)
            {
                ViewBag.error = "An <b>Internal Error Occurred</b> and the email was not sent. Please contact your administrator with the below error. <br>" + e.Message;
                return View();
            }



            //======================
            // Ensure email is not a random persons email.
            if (eRecipient.Contains("@cdu.edu.au") || eRecipient.Contains("@students.cdu.edu.au"))
            {
                using (var message = new MailMessage(eSenderUsername, eRecipient))
                {
                    message.To.Add(new MailAddress(eRecipient));
                    message.From = new MailAddress(eSenderUsername, "CYCM No-Reply");
                    message.Subject = "CYCM - Invoice for " + invoice.Student.FullName;
                    message.Body = content;
                    message.IsBodyHtml = true;

                    using (var smtpClient = new SmtpClient(eSenderHost, eSenderPort))
                    {
                        smtpClient.Host = eSenderHost;
                        smtpClient.EnableSsl = eSenderIsSSL;
                        smtpClient.Credentials = new NetworkCredential(eSenderUsername, eSenderPwd);
                        try
                        {
                            smtpClient.Send(message);
                            ViewBag.success = "Successfully Sent Email to: " + eRecipient;
                        }
                        catch (Exception)
                        {
                            ViewBag.error = "Internal Error: Could not send the email.";
                            return View();
                        }
                    }
                }
            } else {
                ViewBag.error = "Please Note that for safety reasons the email will only be sent to an address on the 'cdu.edu.au'. <br> The email address provided is not to this domain and was not sent.";
                return View();
            }
            ViewBag.error = "An unknown <b>Internal Error Occurred</b> and the email was not sent. Please contact your administrator.";
            return View();
        }

        private ViewData GetInvoiceAsString(int id)
        {
            var modelValue = IncludeInvoiceAndCostData(id);
            // Get relevant data.
            var invoice = _context.Invoice.FirstOrDefault(m => m.Id == id);
            if (invoice == null)
                return new ViewData(StatusEnum.invalidInvoice); // Invalid Invoice Id.
            Students student = _context.Students.Find(invoice.StudentId);

            return new ViewData(StatusEnum.viewError, "NO, Use other thing!!");

           /* try
            {
                InvoiceEmailViewModel invoiceEmailViewModel = new InvoiceEmailViewModel(invoice.Student.FullName, invoice.Student.LName, invoice.Student.FName, invoice.Comment, invoice.Term, invoice.TermStartDate, invoice.PaymentFinalDate, invoice.ReferenceNo, invoice.TotalCost, invoice.Semester, invoice.Student.GuardianName, invoice.Bank, invoice.AccountName, invoice.BSB, invoice.AccountNo, invoice.Signature);
                string ouput = await _razorViewToStringRenderer.RenderViewToStringAsync("InvoiceEmail", invoiceEmailViewModel);

                return new ViewData(StatusEnum.success, output);
            }
            catch (Exception)
            {
                return new ViewData(StatusEnum.viewError);
            }*/
        }


        /// <summary>
        /// Modifies the Lesson.Paid variable for an entire Invoice then returns the user back to the page they were on.
        /// </summary>
        /// <returns>ViewResult - Invoice->Details | Invoice->Index</returns>
        [HttpPost]
        public async Task<IActionResult> PayInvoice() {
            // Get variables from hidden form elements.
            int id;
            bool pay = Request.Form["pay"] == "un-pay" ? false : true;
            bool ToDetails = Request.Form["Details"] == "Details" ? true : false;
            // Check if Id is valid.
            if (int.TryParse(Request.Form["Id"], out id)) {
                // Get Invoice model instance of id.
                Invoice invoice = await _context.Invoice.Include(m => m.Lesson).FirstOrDefaultAsync(m => m.Id == id);
                // Set each lesson.Paid to true.
                foreach (var item in invoice.Lesson) {
                    item.Paid = pay;
                }
                _context.SaveChanges();
                // Redirect back to last page, with success message.
                if (ToDetails)
                    return Redirect(nameof(Details) + "/" + id + "?Success=Invoice " + (pay ? "" : "un-") + "Paid successfully.");
                return RedirectToAction(nameof(Index), new { Success = "Invoice Paid successfully." });
            } else {
                // Redirect back to last page, with error message.
                if (ToDetails)
                    return Redirect(nameof(Details) + "/" + id + "?error=Invalid Invoice Id.");
                return RedirectToAction(nameof(Index), new { error = "Invalid Invoice Id." });
            }
        }
        /// <summary>
        /// Modifies the Lesson.Paid variable for a single Lesson then returns the user back to the page they were on.
        /// </summary>
        /// <returns>ViewResult - Invoice->Details | Invoice->Index</returns>
        public async Task<IActionResult> PayLesson() {
            // Get variables from hidden form elements.
            int id;
            int invId;
            bool pay = Request.Form["pay"] == "un-pay" ? false : true;
            // Check if Id is valid.
            if (int.TryParse(Request.Form["InvoiceId"], out invId)) {
                // Get Invoice model instance of id.
                if (int.TryParse(Request.Form["Id"], out id)) {
                    // Get Invoice model instance of id.
                    Lesson lesson = await _context.Lesson.FirstOrDefaultAsync(m => m.Id == id);
                    // Set lesson.Paid to true.
                    lesson.Paid = pay;
                    _context.SaveChanges();
                    // Redirect back to last page, with success message.
                    return Redirect(nameof(Details) + "/" + invId + "?Success=Lesson Un-Paid successfully.");
                } else {
                    // Redirect back to last page, with error message.
                    return Redirect(nameof(Details) + "/" + invId + "?error=Invalid Lesson Id.");
                }
            } else {
                // Redirect back to last page, with error message.
                return RedirectToAction(nameof(Index), new { error = "Invalid Invoice Id." });
            }

        }
    }
    public class ViewData {
        public string view;
        public StatusEnum status;

        public ViewData(StatusEnum status, string view = "")
        {
            this.view = view;
            this.status = status;
        }
    }
}
