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
    public class MarriageCertificatesController : Controller
    {
        private readonly AppDbContext _context;

        public MarriageCertificatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MarriageCertificates
        [AllowAnonymous]
        public IActionResult Index()
        {
            var marriageCertificates = _context.MarriageCertificates
                .Include(x => x.Husband)
                .Include(x => x.Wife)
                .Include(x => x.HusbandFather)
                .Include(x => x.HusbandMother)
                .Include(x => x.WifeFather)
                .Include(x => x.WifeMother);

            return View(marriageCertificates.ToList());
        }

        // GET: MarriageCertificates/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriageCertificate = _context.MarriageCertificates
                .Include(x => x.Husband)
                .Include(x => x.Wife)
                .Include(x => x.HusbandFather)
                .Include(x => x.HusbandMother)
                .Include(x => x.WifeFather)
                .Include(x => x.WifeMother).FirstOrDefault();

            if (marriageCertificate == null)    
            {
                return NotFound();
            }

            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Create
        public IActionResult Create()
        {
            var model = new MarriageCertificate() { DocumentIssuingDate = DateTime.Now, DocumentIssuedBy = "MPB" };
            return View(model);
        }

        // POST: MarriageCertificates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MarriageCertificate marriageCertificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marriageCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriageCertificate = _context.MarriageCertificates
                .Include(x => x.Husband)
                .Include(x => x.Wife)
                .Include(x => x.HusbandFather)
                .Include(x => x.HusbandMother)
                .Include(x => x.WifeFather)
                .Include(x => x.WifeMother).FirstOrDefault();

            if (marriageCertificate == null)
            {
                return NotFound();
            }
            return View(marriageCertificate);
        }

        // POST: MarriageCertificates/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MarriageCertificate marriageCertificate)
        {
            if (id != marriageCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marriageCertificate.Husband);
                    _context.SaveChanges();

                    _context.Update(marriageCertificate.Wife);
                    _context.SaveChanges();

                    _context.Update(marriageCertificate.HusbandFather);
                    _context.SaveChanges();
                    
                    _context.Update(marriageCertificate.HusbandMother);
                    _context.SaveChanges();

                    _context.Update(marriageCertificate.WifeFather);
                    _context.SaveChanges();

                    _context.Update(marriageCertificate.WifeMother);
                    _context.SaveChanges();

                    _context.Update(marriageCertificate);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarriageCertificateExists(marriageCertificate.Id))
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
            return View(marriageCertificate);
        }

        // GET: MarriageCertificates/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marriageCertificate = _context.MarriageCertificates
                .Include(x => x.Husband)
                .Include(x => x.Wife)
                .Include(x => x.HusbandFather)
                .Include(x => x.HusbandMother)
                .Include(x => x.WifeFather)
                .Include(x => x.WifeMother).FirstOrDefault();
            if (marriageCertificate == null)
            {
                return NotFound();
            }

            return View(marriageCertificate);
        }

        // POST: MarriageCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var marriageCertificate = _context.MarriageCertificates
                .Include(x => x.Husband)
                .Include(x => x.Wife)
                .Include(x => x.HusbandFather)
                .Include(x => x.HusbandMother)
                .Include(x => x.WifeFather)
                .Include(x => x.WifeMother).FirstOrDefault();

            try
            {
                _context.FamilyMembers.Remove(marriageCertificate.HusbandFather);
                _context.FamilyMembers.Remove(marriageCertificate.HusbandMother);
                _context.FamilyMembers.Remove(marriageCertificate.WifeFather);
                _context.FamilyMembers.Remove(marriageCertificate.WifeMother);
                _context.People.Remove(marriageCertificate.Husband);
                _context.People.Remove(marriageCertificate.Wife);
                _context.MarriageCertificates.Remove(marriageCertificate);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(marriageCertificate);
            }
            
        }

        private bool MarriageCertificateExists(int id)
        {
            return _context.MarriageCertificates.Any(e => e.Id == id);
        }
    }
}
