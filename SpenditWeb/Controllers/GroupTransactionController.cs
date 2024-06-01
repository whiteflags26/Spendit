using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spendit.DataAccess;
using Spendit.Models;

namespace SpenditWeb.Controllers
{
    public class GroupTransactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupTransactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupTransaction
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GroupTransactions.Include(g => g.GroupCategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GroupTransaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTransaction = await _context.GroupTransactions
                .Include(g => g.GroupCategory)
                .FirstOrDefaultAsync(m => m.GroupTransactionId == id);
            if (groupTransaction == null)
            {
                return NotFound();
            }

            return View(groupTransaction);
        }

        // GET: GroupTransaction/Create
        public IActionResult Create()
        {
            ViewData["GroupCategoryId"] = new SelectList(_context.GroupCategories, "GroupCategoryId", "CreatorId");
            return View();
        }

        // POST: GroupTransaction/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupTransactionId,CreatorId,GroupCategoryId,Amount,Note,Date")] GroupTransaction groupTransaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupTransaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupCategoryId"] = new SelectList(_context.GroupCategories, "GroupCategoryId", "CreatorId", groupTransaction.GroupCategoryId);
            return View(groupTransaction);
        }

        // GET: GroupTransaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTransaction = await _context.GroupTransactions.FindAsync(id);
            if (groupTransaction == null)
            {
                return NotFound();
            }
            ViewData["GroupCategoryId"] = new SelectList(_context.GroupCategories, "GroupCategoryId", "CreatorId", groupTransaction.GroupCategoryId);
            return View(groupTransaction);
        }

        // POST: GroupTransaction/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupTransactionId,CreatorId,GroupCategoryId,Amount,Note,Date")] GroupTransaction groupTransaction)
        {
            if (id != groupTransaction.GroupTransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupTransaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupTransactionExists(groupTransaction.GroupTransactionId))
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
            ViewData["GroupCategoryId"] = new SelectList(_context.GroupCategories, "GroupCategoryId", "CreatorId", groupTransaction.GroupCategoryId);
            return View(groupTransaction);
        }

        // GET: GroupTransaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupTransaction = await _context.GroupTransactions
                .Include(g => g.GroupCategory)
                .FirstOrDefaultAsync(m => m.GroupTransactionId == id);
            if (groupTransaction == null)
            {
                return NotFound();
            }

            return View(groupTransaction);
        }

        // POST: GroupTransaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupTransaction = await _context.GroupTransactions.FindAsync(id);
            if (groupTransaction != null)
            {
                _context.GroupTransactions.Remove(groupTransaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupTransactionExists(int id)
        {
            return _context.GroupTransactions.Any(e => e.GroupTransactionId == id);
        }
    }
}
