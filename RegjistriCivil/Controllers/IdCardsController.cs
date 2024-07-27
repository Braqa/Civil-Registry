using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegjistriCivil.Models;

namespace RegjistriCivil.Controllers
{
    public class IdCardsController : Controller
    {
        private readonly AppDbContext _context;

        public IdCardsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: IdCards
        [AllowAnonymous]
        public IActionResult Index()
        {
            var idCards = _context.IdCards.Include(x => x.Person);
            return View(idCards.ToList());
        }

        // GET: IdCards/Details/5
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idCard = _context.IdCards.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (idCard == null)
            {
                return NotFound();
            }

            return View(idCard);
        }

        // GET: IdCards/Create
        [Authorize("CreateIdCardPolicy")]
        public IActionResult Create()
        {
            var model = new IdCard() { DocumentIssuingDate = DateTime.Now, ExpireDate = DateTime.Now.AddYears(5), DocumentIssuedBy = "MPB"};
            return View(model);
        }

        // POST: IdCards/Create
        [HttpPost]
        [Authorize("CreateIdCardPolicy")]
        public IActionResult Create(IdCard idCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(idCard);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(idCard);
        }

        // GET: IdCards/Edit/5
        [Authorize("EditIdCardPolicy")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var idCard = _context.IdCards.Find(id);
            //var person = _context.IdCards.Find(id);

            var idCard = _context.IdCards.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (idCard == null)
            {
                return NotFound();
            }
            return View(idCard);
        }

        // POST: IdCards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "EditIdCardPolicy")]
        public IActionResult Edit(int id, IdCard idCard)
        {
            if (id != idCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(idCard.Person);
                    _context.SaveChanges();

                    _context.Update(idCard);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IdCardExists(idCard.Id))
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
            return View(idCard);
        }

        // GET: IdCards/Delete/5
        [Authorize("DeleteIdCardPolicy")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var idCard = _context.IdCards.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            if (idCard == null)
            {
                return NotFound();
            }

            return View(idCard);
        }

        // POST: IdCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "DeleteIdCardPolicy")]
        public IActionResult DeleteConfirmed(int id)
        {
            var idCard = _context.IdCards.Where(x => x.Id == id)
                .Include(x => x.Person).FirstOrDefault();

            try
            {
                _context.People.Remove(idCard.Person);
                _context.IdCards.Remove(idCard);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                return View(idCard);
            }
        }

        private bool IdCardExists(int id)
        {
            return _context.IdCards.Any(e => e.Id == id);
        }
    }
}
