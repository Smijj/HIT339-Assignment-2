using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HIT339_Assignment1.Data;
using HIT339_Assignment1.Models;

namespace HIT339_Assignment1.Controllers
{
    public class LettersController : Controller
    {
        private readonly HIT339_Assignment1Context _context;

        public LettersController(HIT339_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Letters
        public async Task<IActionResult> Index()
        {
            var hIT339_Assignment1Context = _context.Letter.Include(l => l.student);
            return View(await hIT339_Assignment1Context.ToListAsync());
        }

        // GET: Letters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .Include(l => l.student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        public async Task<IActionResult> SetPaid(int? id) {

            // id is the StudentId
            if (id == null) {
                return NotFound();
            }

            // Set isPaid to false in each lesson where the studentId matches the id and isPaid is false
            foreach (Lesson lesson in _context.Lesson.Where(l => l.studentID == id).Where(l => l.isPaid == false)) {
                lesson.isPaid = true;
            }
            // Saving the changes to the database
            await _context.SaveChangesAsync();

            // Redirecting to the Index
            return RedirectToAction(nameof(Index));
        }

        // The final letter: Letters/FinalLetter 
        public async Task<IActionResult> FinalLetter(int? id) {

            // id is the letter ID
            if (id == null) {
                return NotFound();
            }

            // Get the letter with the inputted ID
            var letter = await _context.Letter
                .Include(l => l.student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null) {
                return NotFound();
            }

            var lessonQuery = _context.Lesson
                     .Include(l => l.duration)
                     .Where(l => l.studentID == letter.StudentId)
                     .Where(l => l.isPaid == false);

            float totalCost = 0; // Initialized to 0 in case there are no lessons
            // For through each lesson and add the lessonCost to the TotalCost.
            foreach (Lesson lesson in lessonQuery) {
                totalCost += lesson.duration.lessonCost;
            }

            // Add variables into the ViewData
            ViewData["letter"] = letter;
            ViewData["totalCost"] = totalCost.ToString("0.00");
            ViewData["lessonQuery"] = lessonQuery;
            return View();
        }

        // GET: Letters/Create
        public IActionResult Create(int? id) // id is student ID
        {
            if (id == null) {
                return NotFound();
            }


            // LINQ Method
            // Get all the lessons where studentID == id and isPaid is false, and joining the durations table to it.
            var lessonQuery = _context.Lesson
                     .Include(l => l.duration)
                     .Where(l => l.studentID == id)
                     .Where(l => l.isPaid == false);

            // If there are lessons that are unpaid then set usUnpaidLessons to true, else it is false.
            bool isUnpaidLessons = lessonQuery.Count() > 0 ? true : false;

            // If there is a invoice created already with a certain student ID then this value is set to false.
            bool canCreateInvoice = true;
            foreach (Letter letter in _context.Letter.Where(l => l.StudentId == id)) {
                canCreateInvoice = false;
            }

            // Calculates total Cost
            float totalCost = 0;
            if (isUnpaidLessons == true) {
                foreach (Lesson lesson in lessonQuery) {
                    totalCost += lesson.duration.lessonCost;
                }
            }

            // Add variables into the ViewData
            ViewData["lessonQuery"] = lessonQuery;
            ViewData["isUnpaidLessons"] = isUnpaidLessons;
            ViewData["canCreateInvoice"] = canCreateInvoice;
            ViewData["totalCost"] = totalCost.ToString("0.00");
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", id == null ? null : id);
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));

            return View();
        }

        // POST: Letters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,comment,email,bankName,accountName,bsb,accountNumber,currentTerm,currentYear,termStartDate")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(letter);
                await _context.SaveChangesAsync();

                return RedirectToAction("FinalLetter", new { id = letter.Id });
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "FullName", letter.StudentId);
            return View(letter);
        }

        // GET: Letters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter.FindAsync(id);
            if (letter == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", letter.StudentId);
            return View(letter);
        }

        // POST: Letters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,comment,email,bankName,accountName,bsb,accountNumber,currentTerm,currentYear,termStartDate")] Letter letter)
        {
            if (id != letter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(letter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LetterExists(letter.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Student, "Id", "Email", letter.StudentId);
            return View(letter);
        }

        // GET: Letters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var letter = await _context.Letter
                .Include(l => l.student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var letter = await _context.Letter.FindAsync(id);
            _context.Letter.Remove(letter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
            return _context.Letter.Any(e => e.Id == id);
        }
    }
}
