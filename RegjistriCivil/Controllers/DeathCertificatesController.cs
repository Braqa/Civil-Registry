using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegjistriCivil.Models;

namespace RegjistriCivil.Controllers
{
    public class DeathCertificatesController : Controller
    {
        private readonly AppDbContext _context;

        public DeathCertificatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DeathCertificates
        [AllowAnonymous]
        public IActionResult Index()
        {
            var deathCertificates = _context.DeathCertificates
                .Include(x => x.Person)
                .Include(x => x.Father)
                .Include(x => x.Mother)
                .Include(x => x.Spouse);

            return View(deathCertificates.ToList());
        }

        // GET: DeathCertificates/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathCertificate = _context.DeathCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.Father)
                .Include(x => x.Mother)
                .Include(x => x.Spouse).FirstOrDefault();

            if (deathCertificate == null)
            {
                return NotFound();
            }

            return View(deathCertificate);
        }

        // GET: DeathCertificates/Create
        public IActionResult Create()
        {
            var model = new DeathCertificate() { DocumentIssuingDate = DateTime.Now, DocumentIssuedBy = "MPB" };
            return View(model);
        }

        // POST: DeathCertificates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DeathCertificate deathCertificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deathCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deathCertificate);
        }

        // GET: DeathCertificates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathCertificate = _context.DeathCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.Father)
                .Include(x => x.Mother)
                .Include(x => x.Spouse).FirstOrDefault();

            if (deathCertificate == null)
            {
                return NotFound();
            }
            return View(deathCertificate);
        }

        // POST: DeathCertificates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DeathCertificate deathCertificate)
        {
            if (id != deathCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deathCertificate.Person);
                    _context.SaveChanges();

                    _context.Update(deathCertificate.Father);
                    _context.SaveChanges();

                    _context.Update(deathCertificate.Mother);
                    _context.SaveChanges();

                    _context.Update(deathCertificate.Spouse);
                    _context.SaveChanges();

                    _context.Update(deathCertificate);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeathCertificateExists(deathCertificate.Id))
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
            return View(deathCertificate);
        }

        // GET: DeathCertificates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deathCertificate = _context.DeathCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.Father)
                .Include(x => x.Mother)
                .Include(x => x.Spouse).FirstOrDefault();


            if (deathCertificate == null)
            {
                return NotFound();
            }

            return View(deathCertificate);
        }

        // POST: DeathCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var deathCertificate = _context.DeathCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.Father)
                .Include(x => x.Mother)
                .Include(x => x.Spouse).FirstOrDefault();

            try
            {
                _context.FamilyMembers.Remove(deathCertificate.Father);
                _context.FamilyMembers.Remove(deathCertificate.Mother);
                _context.FamilyMembers.Remove(deathCertificate.Spouse);
                _context.People.Remove(deathCertificate.Person);
                _context.DeathCertificates.Remove(deathCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View(deathCertificate);
            }

        }

        private bool DeathCertificateExists(int id)
        {
            return _context.DeathCertificates.Any(e => e.Id == id);
        }
    }
}
