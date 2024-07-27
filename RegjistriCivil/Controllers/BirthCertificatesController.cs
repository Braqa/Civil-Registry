using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegjistriCivil.Models;

namespace RegjistriCivil.Controllers
{
    public class BirthCertificatesController : Controller
    {
        private readonly AppDbContext _context;

        public BirthCertificatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: BirthCertificates
        [AllowAnonymous]
        public IActionResult Index()
        {
            var birthCertificates = _context.BirthCertificates
                .Include(x => x.Person)
                .Include(x => x.FatherDetails)
                .Include(x => x.MotherDetails);
            return View(birthCertificates.ToList());
        }

        // GET: BirthCertificates/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthCertificate = _context.BirthCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.FatherDetails)
                .Include(x => x.MotherDetails).FirstOrDefault();

            if (birthCertificate == null)
            {
                return NotFound();
            }

            return View(birthCertificate);
        }

        // GET: BirthCertificates/Create
        [Authorize(Policy = "CreateCertificatePolicy")]
        public IActionResult Create()
        {
            var model = new BirthCertificate() { DocumentIssuingDate = DateTime.Now, DocumentIssuedBy = "MPB" };
            return View(model);
        }

        // POST: BirthCertificates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "CreateCertificatePolicy")]
        public IActionResult Create(BirthCertificate birthCertificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(birthCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Edit/5
        [Authorize(Policy = "EditCertificatePolicy")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthCertificate = _context.BirthCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.FatherDetails)
                .Include(x => x.MotherDetails).FirstOrDefault();

            if (birthCertificate == null)
            {
                return NotFound();
            }
            return View(birthCertificate);
        }

        // POST: BirthCertificates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EditCertificatePolicy")]
        public IActionResult Edit(int id, BirthCertificate birthCertificate)
        {
            if (id != birthCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Update(birthCertificate.Person);
                    _context.SaveChanges();

                    _context.Update(birthCertificate.FatherDetails);
                    _context.SaveChanges();


                    _context.Update(birthCertificate.MotherDetails);
                    _context.SaveChanges();

                    _context.Update(birthCertificate);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BirthCertificateExists(birthCertificate.Id))
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
            return View(birthCertificate);
        }

        // GET: BirthCertificates/Delete/5
        [Authorize(Policy = "DeleteCertificatePolicy")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var birthCertificate = _context.BirthCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.FatherDetails)
                .Include(x => x.MotherDetails).FirstOrDefault(); ;

            if (birthCertificate == null)
            {
                return NotFound();
            }

            return View(birthCertificate);
        }

        // POST: BirthCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DeleteCertificatePolicy")]
        public IActionResult DeleteConfirmed(int id)
        {
            var birthCertificate = _context.BirthCertificates.Where(x => x.Id == id)
                .Include(x => x.Person)
                .Include(x => x.FatherDetails)
                .Include(x => x.MotherDetails).FirstOrDefault();


            try
            {
                _context.FamilyMembers.Remove(birthCertificate.FatherDetails);
                _context.FamilyMembers.Remove(birthCertificate.MotherDetails);
                _context.People.Remove(birthCertificate.Person);
                _context.BirthCertificates.Remove(birthCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(birthCertificate);
            }
        }

        private bool BirthCertificateExists(int id)
        {
            return _context.BirthCertificates.Any(e => e.Id == id);
        }
    }
}
