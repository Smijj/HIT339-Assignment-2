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
    public class LessonsController : Controller
    {
        private readonly HIT339_Assignment1Context _context;

        public LessonsController(HIT339_Assignment1Context context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            var hIT339_Assignment1Context = _context.Lesson.Include(l => l.duration).Include(l => l.instrument).Include(l => l.student).Include(l => l.tutor);
            return View(await hIT339_Assignment1Context.ToListAsync());
        }

        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.duration)
                .Include(l => l.instrument)
                .Include(l => l.student)
                .Include(l => l.tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            ViewData["durationID"] = new SelectList(_context.Duration, "Id", "DisplayInfo");
            ViewData["instrumentID"] = new SelectList(_context.Instrument, "Id", "InstrumentName");
            ViewData["studentID"] = new SelectList(_context.Student, "Id", "FullName");
            ViewData["tutorID"] = new SelectList(_context.Tutor, "Id", "TutorName");

            ViewData["Terms"] = new SelectList(Enum.GetValues(typeof(Terms)));
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,studentID,instrumentID,tutorID,Term,dateTime,durationID,isPaid")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["durationID"] = new SelectList(_context.Duration, "Id", "Id", lesson.durationID);
            ViewData["instrumentID"] = new SelectList(_context.Instrument, "Id", "InstrumentName", lesson.instrumentID);
            ViewData["studentID"] = new SelectList(_context.Student, "Id", "FullName", lesson.studentID);
            ViewData["tutorID"] = new SelectList(_context.Tutor, "Id", "TutorName", lesson.tutorID);
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["durationID"] = new SelectList(_context.Duration, "Id", "DisplayInfo", lesson.durationID);
            ViewData["instrumentID"] = new SelectList(_context.Instrument, "Id", "InstrumentName", lesson.instrumentID);
            ViewData["studentID"] = new SelectList(_context.Student, "Id", "FullName", lesson.studentID);
            ViewData["tutorID"] = new SelectList(_context.Tutor, "Id", "TutorName", lesson.tutorID);
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,studentID,instrumentID,tutorID,Term,dateTime,durationID,isPaid")] Lesson lesson)
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
            ViewData["durationID"] = new SelectList(_context.Duration, "Id", "Id", lesson.durationID);
            ViewData["instrumentID"] = new SelectList(_context.Instrument, "Id", "InstrumentName", lesson.instrumentID);
            ViewData["studentID"] = new SelectList(_context.Student, "Id", "FullName", lesson.studentID);
            ViewData["tutorID"] = new SelectList(_context.Tutor, "Id", "TutorName", lesson.tutorID);
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .Include(l => l.duration)
                .Include(l => l.instrument)
                .Include(l => l.student)
                .Include(l => l.tutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
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
