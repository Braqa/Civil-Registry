using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegjistriCivil.Models;

namespace RegjistriCivil.Controllers
{
    public class PersonStatisticsController : Controller
    {
        private readonly AppDbContext _context;

        public PersonStatisticsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PersonStatistics
        [AllowAnonymous]
        public IActionResult Index()
        {
            var personStatistics = _context.PersonStatistics.Include(x => x.Person);
            return View(personStatistics.ToList());
        }

        // GET: PersonStatistics/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatistic = _context.PersonStatistics.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (personStatistic == null)
            {
                return NotFound();
            }

            return View(personStatistic);
        }

        // GET: PersonStatistics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonStatistics/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonStatistic personStatistic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personStatistic);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(personStatistic);
        }

        // GET: PersonStatistics/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatistic = _context.PersonStatistics.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (personStatistic == null)
            {
                return NotFound();
            }
            return View(personStatistic);
        }

        // POST: PersonStatistics/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,PersonStatistic personStatistic)
        {
            if (id != personStatistic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personStatistic.Person);
                    _context.SaveChanges();

                    _context.Update(personStatistic);
                    _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonStatisticExists(personStatistic.Id))
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
            return View(personStatistic);
        }

        // GET: PersonStatistics/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatistic = _context.PersonStatistics.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (personStatistic == null)
            {
                return NotFound();
            }

            return View(personStatistic);
        }

        // POST: PersonStatistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var personStatistic = _context.PersonStatistics.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();
            try
            {
                _context.People.Remove(personStatistic.Person);
                _context.PersonStatistics.Remove(personStatistic);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(personStatistic);
            }
        }

        private bool PersonStatisticExists(int id)
        {
            return _context.PersonStatistics.Any(e => e.Id == id);
        }
    }
}
