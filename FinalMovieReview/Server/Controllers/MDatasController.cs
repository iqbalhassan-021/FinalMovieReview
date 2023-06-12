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
    public class MDatasController : Controller
    {
        private readonly FinalMovieReviewServerContext _context;

        public MDatasController(FinalMovieReviewServerContext context)
        {
            _context = context;
        }

        // GET: MDatas
        public async Task<IActionResult> Index()
        {
              return _context.MData != null ? 
                          View(await _context.MData.ToListAsync()) :
                          Problem("Entity set 'FinalMovieReviewServerContext.MData'  is null.");
        }

        // GET: MDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MData == null)
            {
                return NotFound();
            }

            var mData = await _context.MData
                .FirstOrDefaultAsync(m => m.MovieName == id);
            if (mData == null)
            {
                return NotFound();
            }

            return View(mData);
        }

        // GET: MDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieName,MovieDescription,MovieRating")] MData mData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mData);
        }

        // GET: MDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MData == null)
            {
                return NotFound();
            }

            var mData = await _context.MData.FindAsync(id);
            if (mData == null)
            {
                return NotFound();
            }
            return View(mData);
        }

        // POST: MDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MovieName,MovieDescription,MovieRating")] MData mData)
        {
            if (id != mData.MovieName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDataExists(mData.MovieName))
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
            return View(mData);
        }

        // GET: MDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MData == null)
            {
                return NotFound();
            }

            var mData = await _context.MData
                .FirstOrDefaultAsync(m => m.MovieName == id);
            if (mData == null)
            {
                return NotFound();
            }

            return View(mData);
        }

        // POST: MDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MData == null)
            {
                return Problem("Entity set 'FinalMovieReviewServerContext.MData'  is null.");
            }
            var mData = await _context.MData.FindAsync(id);
            if (mData != null)
            {
                _context.MData.Remove(mData);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDataExists(string id)
        {
          return (_context.MData?.Any(e => e.MovieName == id)).GetValueOrDefault();
        }
    }
}
