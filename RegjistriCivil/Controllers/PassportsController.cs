using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegjistriCivil.Models;

namespace RegjistriCivil.Controllers
{
    public class PassportsController : Controller
    {
        private readonly AppDbContext _context;

        public PassportsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Passports
        [AllowAnonymous]
        public IActionResult Index()
        {
            var passports = _context.Passports.Include(x => x.Person);
            return View(passports.ToList());
        }

        // GET: Passports/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = _context.Passports.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // GET: Passports/Create
        [Authorize("CreatePassportPolicy")]
        public IActionResult Create()
        {
            var model = new Passport() { DocumentIssuingDate = DateTime.Now, ExpireDate = DateTime.Now.AddYears(10), DocumentIssuedBy = "MPB" };
            return View(model);
        }

        // POST: Passports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("CreatePassportPolicy")]
        public IActionResult Create(Passport passport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passport);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(passport);
        }

        // GET: Passports/Edit/5
        [Authorize("EditPassportPolicy")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = _context.Passports.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (passport == null)
            {
                return NotFound();
            }
            return View(passport);
        }

        // POST: Passports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("EditPassportPolicy")]
        public IActionResult Edit(int id, Passport passport)
        {
            if (id != passport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passport.Person);
                    _context.SaveChanges();

                    _context.Update(passport);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassportExists(passport.Id))
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
            return View(passport);
        }

        // GET: Passports/Delete/5
        [Authorize("DeletePassportPolicy")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passport = _context.Passports.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (passport == null)
            {
                return NotFound();
            }

            return View(passport);
        }

        // POST: Passports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("DeletePassportPolicy")]
        public IActionResult DeleteConfirmed(int id)
        {
            var passport = _context.Passports.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            try
            {
                _context.People.Remove(passport.Person);
                _context.Passports.Remove(passport);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(passport);
            }
        }

        private bool PassportExists(int id)
        {
            return _context.Passports.Any(e => e.Id == id);
        }
    }
}
