using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalMovieReview.Server.Data;
using FinalMovieReview.Shared.Model;

namespace FinalMovieReview.Server.Controllers
{
    public class MReviewsController : Controller
    {
        private readonly FinalMovieReviewServerContext _context;

        public MReviewsController(FinalMovieReviewServerContext context)
        {
            _context = context;
        }

        // GET: MReviews
        public async Task<IActionResult> Index()
        {
              return _context.MReviews != null ? 
                          View(await _context.MReviews.ToListAsync()) :
                          Problem("Entity set 'FinalMovieReviewServerContext.MReviews'  is null.");
        }

        // GET: MReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MReviews == null)
            {
                return NotFound();
            }

            var mReviews = await _context.MReviews
                .FirstOrDefaultAsync(m => m.user == id);
            if (mReviews == null)
            {
                return NotFound();
            }

            return View(mReviews);
        }

        // GET: MReviews/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user,MRating,MDesc")] MReviews mReviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mReviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mReviews);
        }

        // GET: MReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MReviews == null)
            {
                return NotFound();
            }

            var mReviews = await _context.MReviews.FindAsync(id);
            if (mReviews == null)
            {
                return NotFound();
            }
            return View(mReviews);
        }

        // POST: MReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("user,MRating,MDesc")] MReviews mReviews)
        {
            if (id != mReviews.user)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mReviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MReviewsExists(mReviews.user))
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
            return View(mReviews);
        }

        // GET: MReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MReviews == null)
            {
                return NotFound();
            }

            var mReviews = await _context.MReviews
                .FirstOrDefaultAsync(m => m.user == id);
            if (mReviews == null)
            {
                return NotFound();
            }

            return View(mReviews);
        }

        // POST: MReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MReviews == null)
            {
                return Problem("Entity set 'FinalMovieReviewServerContext.MReviews'  is null.");
            }
            var mReviews = await _context.MReviews.FindAsync(id);
            if (mReviews != null)
            {
                _context.MReviews.Remove(mReviews);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MReviewsExists(int id)
        {
          return (_context.MReviews?.Any(e => e.user == id)).GetValueOrDefault();
        }
    }
}
