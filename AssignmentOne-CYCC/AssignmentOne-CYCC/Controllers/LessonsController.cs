using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssignmentOne_CYCC.Data;
using AssignmentOne_CYCC.Models;
using AssignmentOne_CYCC.ViewModels;

namespace AssignmentOne_CYCC.Controllers
{
    public class LessonsController : Controller
    {
        private readonly AssignmentOne_CYCCContext _context;

        public LessonsController(AssignmentOne_CYCCContext context)
        {
            _context = context;
        }

        // GET: Lessons
        /// <summary>
        /// Returns the Lesson->Index page.
        /// </summary>
        /// <returns>ViewResult - Lesson->Index</returns>
        public async Task<IActionResult> Index()
        {
            var assignmentOne_CYCCContext = _context.Lesson.Include(l => l.Duration).Include(l => l.Instrument).Include(l => l.Students).Include(l => l.Tutor);
            return View(await assignmentOne_CYCCContext.ToListAsync());
        }

        // GET: Lessons/Details/5
        /// <summary>
        /// Returns the Lesson->Details page.
        /// </summary>
        /// <returns>ViewResult - Lesson->Details | NotFoundResult</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Students)
                .Include(l => l.Tutor)
                .Include(l => l.Invoice)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        /// <summary>
        /// Returns the Lesson->Create page.
        /// </summary>
        /// <returns>ViewResult - Lesson->Create</returns>
        public IActionResult Create()
        {
            ViewData["DurationId"] = new SelectList(_context.Duration, "Id", "DurationCost");
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName");
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "fullName");

            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));
            return View();
        }

        // POST: Lessons/Create
        /// <summary>
        /// POST handler for Lesson->Create.
        /// Accepts, validates, and saves Lesson Data.
        /// </summary>
        /// <returns>ViewResult - Lesson->Index (success) | Lesson->Create (fail)</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentId,InstrumentId,TutorId,DurationId,term,year,LessonTime,Paid")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                // Save new Lesson.
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                // Duplicate Lesson as per the weeksToRepeat variable (if set).
                var lessonList = new List<Lesson>();
				int weeksToRepeat;
                if (int.TryParse(Request.Form["weeksToRepeat"].ToString(), out weeksToRepeat)) {
                    weeksToRepeat = weeksToRepeat > 0 ? weeksToRepeat-1 : weeksToRepeat; // Minus one week (the initial week) used to (hopefully) make the client side easy to understand.
                    if (weeksToRepeat > 1) {

					    for (int i = 1; i <= weeksToRepeat; i++) {

                            var newLesson = new Lesson();
                            newLesson.Duration = lesson.Duration;
                            newLesson.DurationId = lesson.DurationId;
                            newLesson.Students = lesson.Students;
                            newLesson.StudentId = lesson.StudentId;
                            newLesson.Instrument = lesson.Instrument;
                            newLesson.InstrumentId = lesson.InstrumentId;
                            newLesson.Tutor = lesson.Tutor;
                            newLesson.TutorId = lesson.TutorId;
                            newLesson.Invoice = lesson.Invoice;
                            newLesson.InvoiceId = lesson.InvoiceId;
                            newLesson.term = lesson.term;
                            newLesson.LessonTime = lesson.LessonTime.AddDays(7*i);  // Increment by a week.
                            newLesson.Paid = lesson.Paid;
                            lessonList.Add(newLesson);
					    }
                    }
				}
                _context.AddRange(lessonList);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            ViewData["DurationId"] = new SelectList(_context.Duration, "Id", "DurationCost", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Name", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "fullName", lesson.TutorId);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        /// <summary>
        /// Returns the Lesson->Edit page.
        /// Uses the EditViewModel to allow fine control of edited values.
        /// NOTE: Views->Lesson->Edit-old.cshtml is the default edit page for the base Lesson model.
        /// It has been retained for reference.
        /// </summary>
        /// <param name="id">(Required) Id of Lesson to edit.</param>
        /// <returns>ViewResult - Lesson->Edit | NotFoundResult</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // Get the currest state of the Lesson to Edit.
            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["DurationId"] = new SelectList(_context.Duration, "Id", "DurationCost", lesson.DurationId);
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Name", lesson.InstrumentId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", lesson.StudentId);
            ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "fullName", lesson.TutorId);


            // Transfer data from the Lesson model to the LessonViewModel model.
            LessonViewModel lessonViewModel = new LessonViewModel {
                Id = lesson.Id,
                StudentId = lesson.StudentId,
                InstrumentId = lesson.InstrumentId,
                TutorId = lesson.TutorId,
                DurationId = lesson.DurationId,
                term = lesson.term,
                LessonTime = lesson.LessonTime
            };
            
            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));

            return View(lessonViewModel);
        }
        // ======= Retained for reference ======
        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, [Bind("Id,StudentId,InstrumentId,TutorId,DurationId,term,year,LessonTime,Paid")] Lesson lesson)
         {
             if (id != lesson.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(lesson);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!LessonExists(lesson.Id))
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
             ViewData["DurationId"] = new SelectList(_context.Duration, "Id", "DurationCost", lesson.DurationId);
             ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Name", lesson.InstrumentId);
             ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FullName", lesson.StudentId);
             ViewData["TutorId"] = new SelectList(_context.Tutor, "Id", "fullName", lesson.TutorId);
             return View(lesson);
         }*/
        /// <summary>
        /// POST handler for Lesson->Edit page.
        /// Accepts, validates, and saves Lesson Data.
        /// </summary>
        /// <param name="id">(required) id of Lesson to edit.</param>
        /// <param name="model">(required) Form data bound to a LessonViewModel</param>
        /// <returns>ViewResult - Lesson->Index (success) | Lesson->Edit (fail)</returns>
        [HttpPost]
       [ValidateAntiForgeryToken]
       public async Task<IActionResult> Edit(int id, LessonViewModel model) {
            if (ModelState.IsValid) {
                var lesson = await _context.Lesson.FindAsync(id);
                if (lesson != null) {
                    lesson.InstrumentId = model.InstrumentId;
                    lesson.TutorId = model.TutorId;
                    lesson.DurationId = model.DurationId;
                    lesson.term = model.term;
                    lesson.LessonTime = model.LessonTime;

                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
				}
			}

            return View(model);
		}

        // GET: Lessons/Delete/5
        /// <summary>
        /// Returns Lesson->Delete page.
        /// </summary>
        /// <param name="id">(required) Id of Lesson to delete</param>
        /// <returns>ViewResult - Invoice->Lesson</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            

            var lesson = await _context.Lesson
                .Include(l => l.Duration)
                .Include(l => l.Instrument)
                .Include(l => l.Students)
                .Include(l => l.Tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        /// <summary>
        /// POST Handler for Lesson->Lesson.
        /// Handles Form data, validation and deleting from the database.
        /// </summary>
        /// <param name="id">(Required) Invoice Id to Lesson.</param>
        /// <returns>ViewResult - Lesson->Index</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.Id == id);
        }
    }
}
