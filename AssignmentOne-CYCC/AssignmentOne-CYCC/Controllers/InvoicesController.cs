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
using System.Net;

// Custom Email Generator Classes
using RazorHtmlEmails.RazorClassLib.Services;
using RazorHtmlEmails.RazorClassLib.Views.Emails.InvoiceEmail;
using System.Text.RegularExpressions;

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
        public async Task<IActionResult> Index(string name)
        {

            ViewBag.success = Request.Query["success"].ToString();
            ViewBag.error = Request.Query["error"].ToString();

            IncludeInvoiceAndCostData();

            // Using a LINQ Query, select the lessons
            var invoices = from l in _context.Invoice
                          .Include(m => m.Student)
                          .Include(m => m.Lesson)
                          select l;

            // If the search filter is not empty then alter the LINQ Query to only show the results containing the filter
            if (!String.IsNullOrEmpty(name)) {
                invoices = invoices.Where(l => (l.Student.FName + " " + l.Student.LName).Contains(name));
            }


            return View(await invoices.ToListAsync());
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

            // Adding the Terms enum to the viewdata for the Terms dropdown menu
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));

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
        public async Task<IActionResult> Create([Bind("StudentId,Comment,Signature,Bank,AccountName,AccountNo,BSB,Term,Year,TermStartDate,PaymentFinalDate")] Invoice invoice)
        {
            if (ModelState.IsValid) {

                ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));

                // Check if any data is provided, else redirect back to form page.
                if (invoice == null) return RedirectToAction(nameof(Create));

                // Check if Student.Id exists, else return an error message.
                if (_context.Students.Any(ag => ag.Id == invoice.StudentId)) {

                    // Get all lessons linked to this Student that: Have NOT been paid AND are NOT already associated with another Invoice.
                    IEnumerable<Lesson> lessonQuery =
                        from lesson in _context.Lesson
                        where lesson.StudentId == invoice.StudentId && lesson.Paid == false
                        select lesson;

                    // Check if there is no lessons unpaid, not already linked, if there is none return error.
                    if (!lessonQuery.Any()) {
                        ModelState.AddModelError("CustomError", "There are currently no outstanding lessons not already invoiced for this student.");
                        ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
                        return View(invoice);
                    }
                    // Covert to array.
                    invoice.Lesson = lessonQuery.ToArray();
                } else {
                    ModelState.AddModelError("CustomError", "The Student provided does not exist. Please select a valid option.");
                    ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
                    ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));          // Adding the Terms enum to the viewdata for the Terms dropdown menu
                    return View(invoice);
                }

                // Check is an Invoice for this student already exists.
                if (_context.Invoice.Where(m => m.StudentId == invoice.StudentId).Any()) {
                    // Check if the Validation message has already been displayed before deleting the old Invoice record.
                    if (Request.Form["ValidationCheckShown"] == "") {
                        ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");
                        ModelState.AddModelError("CustomError", "An Invoice for this Student already exists. Either overwrite the old Invoice (by clicking the Create button below) or edit the existing Invoice.");
                        ViewBag.InvoiceForStudentExists = true;
                        return View(invoice);
                    } else {
                        try
                        {
                            Invoice oldInvoice = _context.Invoice.Where(m => m.StudentId == invoice.StudentId).First();
                            // Sever all references manually EF makes it difficult to ask SQL to do it.
                            IncludeInvoiceAndCostData();
                            foreach (var lesson in oldInvoice.Lesson)
                            {
                                lesson.InvoiceId = null;
                            }
                            _context.Invoice.Remove(oldInvoice);
                        }
                        catch (Exception)
                        {
                            // Catch an exception where the old invoice could not be deleted for some magical reason.
                            ModelState.AddModelError("CustomError", "An Internal error occurred and the old Invoice could not be deleted. Please try again and contact your administrator if this error keep occurring.");
                        }
                    }
                }


                IncludeInvoiceAndCostData(invoice.Id);
                _context.Add(invoice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SendEmailConfirm), new { id = invoice.Id });  // Redirect to SendEmailConfirm page of same Invoice.
            }
            ViewBag.StudentIds = new SelectList(_context.Students, "Id", "FullName");       // Get data for drop-down
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));              // Adding the Terms enum to the viewdata for the Terms dropdown menu
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
            // Adding the Terms enum to the viewdata for the Terms dropdown menu
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));      // Adding dropdown info
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
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));      // Adding dropdown info
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

            return View(invoice);
        }

        /// <summary>
        /// Sends an email to the students guardian noted in the attached student record. Returns a Json response with 'status' ('success' or 'error') and 'msg' fields.
        /// </summary>
        /// <param name="sid">string of Invoice Id to send</param>
        /// <returns>Json - status, msg</returns>
        [HttpPost]
        public async Task<IActionResult> SendEmail(int id)
        {
            // Get relevant data.
            var modeldata = IncludeInvoiceAndCostData(id);

            var invoice = await _context.Invoice.FirstOrDefaultAsync(m => m.Id == id);
            if (invoice == null) {
                return Json(new {
                    status = "error",
                    msg = "SEaj002: Invalid Invoice. Either the Invoice was deleted while confirming, it is corrupted, or it never existed. Please contact the system administrator if the error continues to occur."
                });
            }

            string eSenderHost = _config["smtp:host"];
            string eSenderPwd = _config["smtp:pwd"];
            string eSenderUsername = _config["smtp:username"];
            int eSenderPort = int.Parse(_config["smtp:port"]);
            bool eSenderIsSSL = _config["smtp:isSSL"] == "true" ? true : false;

            string eRecipient = invoice.Student.Email;

            // Generate Email Content
            string content = "";
            try
            {
                // Transform invoice model into a invliceEmailModel which the invoiceEmail view can understand.
                InvoiceEmailViewModel invoiceEmailViewModel = new InvoiceEmailViewModel(
                    invoice.Student.FullName, 
                    invoice.Student.LName, 
                    invoice.Student.FName, 
                    invoice.Comment, 
                    invoice.displayTerm, 
                    invoice.TermStartDate, 
                    invoice.PaymentFinalDate, 
                    invoice.ReferenceNo, 
                    invoice.TotalCost, 
                    invoice.Semester, 
                    invoice.Student.GuardianName, 
                    invoice.Bank, 
                    invoice.AccountName, 
                    invoice.BSB, 
                    invoice.AccountNo, 
                    invoice.Signature
                    );
                content = await _razorViewToStringRenderer.RenderViewToStringAsync("InvoiceEmail.cshtml", invoiceEmailViewModel);
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = "error",
                    msg = "SEaj 003: An Internal Error Occurred and the email was not sent. Please contact your administrator if the error continues to occur."
                });
            }

            // Ensure email is not a random persons email.
            if (Regex.IsMatch(eRecipient, "@cdu.edu.au$|@students.cdu.edu.au$"))
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
                            // Successfully sent Email.

                            // Add Invoice Data to Archive
                            if (!CreateNewArchiveEntery(invoice)) {
                                return Json( new {
                                    status = "error",
                                    msg = "The Email was successfully sent to " + eRecipient + ", but could not be added to the archive. Please contact your administrator to rectify this issue."
                                });
                            }

                            return Json( new {
                                status = "success",
                                msg = "The Email was successfully sent to " + eRecipient + "."
                            });
                        }
                        catch (Exception)
                        {
                            return Json( new {
                                status = "error",
                                msg = "SEaj 004: An Internal Error Occurred and the email was not sent. Please contact your administrator if the error continues to occur."
                            });
                        }
                    }
                }
            } else {
                // Add Invoice Data to Archive
                if (!CreateNewArchiveEntery(invoice))
                    return Json(new
                    {
                        status = "error",
                        msg = "The could not be added to the archive. Please contact your administrator to rectify this issue. SAFTEY FIRST: Please note that for TESTING reasons the email will only be sent to an address on the 'cdu.edu.au' domain. The email address provided is not to this domain and hence was not sent."
                    });

                return Json(new
                {
                    status = "error",
                    msg = "SAFTEY FIRST: Please note that for TESTING reasons the email will only be sent to an address on the 'cdu.edu.au' domain. The email address provided is not to this domain and hence was not sent."
                });
            }
        }

        /// <summary>
        /// Modifies the Lesson.Paid variable for an entire Invoice then returns json.
        /// </summary>
        /// <param name="id">Invoice Id to edit</param>
        /// <returns>ViewResult - Invoice->Details | Invoice->Index</returns>
        [HttpPost]
        public async Task<IActionResult> PayInvoice(int id)
        {

            // Get Invoice model instance of id.
            Invoice invoice;
            try
            {
                invoice = await _context.Invoice.Include(m => m.Lesson).FirstAsync(m => m.Id == id);
            }
            catch (Exception)
            {
                return Json(new
                {
                    status = "error",
                    msg = "PIaj 001: An Internal Error Occurred and your request could not be completed. Please contact your administrator if the error continues to occur."
                });
            }

            bool pay = !invoice.InvoicePaid;
            // Set each lesson.Paid to true.
            foreach (var item in invoice.Lesson)
            {
                item.Paid = pay;
            }
            _context.SaveChanges();
            // Redirect back to last page, with success message.
            return Json(new
            {
                status = "success",
                paid = (pay ? "true" : "false")
            });
        }

        /*       
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
        */

        /// <summary>
        /// Converts a given Invoice model to a InvoiceArchive model.
        /// </summary>
        /// <param name="invoiceArchive"></param>
        /// <param name="invoice"></param>
        /// <returns></returns>
        public InvoiceArchive ConvertFromInvoice(Invoice invoice)
        {
            InvoiceArchive invoiceArchive = new InvoiceArchive();
            //Invoice content
            invoiceArchive.ReferenceNo = invoice.ReferenceNo;
            invoiceArchive.Comment = invoice.Comment;
            invoiceArchive.Signature = invoice.Signature;
            invoiceArchive.Bank = invoice.Bank;
            invoiceArchive.AccountName = invoice.AccountName;
            invoiceArchive.AccountNo = invoice.AccountNo;
            invoiceArchive.BSB = invoice.BSB;
            invoiceArchive.Term = (int)invoice.Term;
            invoiceArchive.Year = invoice.Year;
            invoiceArchive.TermStartDate = invoice.TermStartDate;
            invoiceArchive.PaymentFinalDate = invoice.PaymentFinalDate;
            invoiceArchive.TotalCost = invoice.TotalCost;
            invoiceArchive.InvoicePaid = invoice.InvoicePaid;

            //Student Data
            invoiceArchive.StudentFName = invoice.Student.FName;
            invoiceArchive.StudentLName = invoice.Student.LName;
            invoiceArchive.DateOfBirth = invoice.Student.DateOfBirth;
            invoiceArchive.Age = invoice.Student.Age;
            invoiceArchive.Gender = invoice.Student.Gender.ToString();
            invoiceArchive.GuardianName = invoice.Student.GuardianName;
            invoiceArchive.GuardianEmail = invoice.Student.Email;
            invoiceArchive.GuardianPhoneNumber = invoice.Student.PhoneNumber;

            return invoiceArchive;
        }
        /// <summary>
        /// Converts an Invoice model to an InvoiceArchive model.
        /// </summary>
        /// <param name="invoice">Invoice to convert</param>
        /// <returns></returns>
        public bool CreateNewArchiveEntery(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                InvoiceArchive invoiceArchive = ConvertFromInvoice(invoice);
                _context.InvoiceArchive.Add(invoiceArchive);
                // Check if anything is actually added to the database.
                if (_context.SaveChanges() > 0)
                    return true;
            }
            return false;
        }
    }
}
