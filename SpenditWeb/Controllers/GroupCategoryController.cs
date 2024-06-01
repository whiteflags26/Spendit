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
    public class GroupCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroupCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GroupCategory
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.GroupCategories.Include(g => g.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GroupCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupCategory = await _context.GroupCategories
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupCategoryId == id);
            if (groupCategory == null)
            {
                return NotFound();
            }

            return View(groupCategory);
        }

        // GET: GroupCategory/Create
        public IActionResult Create()
        {
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name");
            return View();
        }

        // POST: GroupCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupCategoryId,CreatorId,GroupId,Title,Icon,Type")] GroupCategory groupCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groupCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", groupCategory.GroupId);
            return View(groupCategory);
        }

        // GET: GroupCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupCategory = await _context.GroupCategories.FindAsync(id);
            if (groupCategory == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", groupCategory.GroupId);
            return View(groupCategory);
        }

        // POST: GroupCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupCategoryId,CreatorId,GroupId,Title,Icon,Type")] GroupCategory groupCategory)
        {
            if (id != groupCategory.GroupCategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groupCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupCategoryExists(groupCategory.GroupCategoryId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", groupCategory.GroupId);
            return View(groupCategory);
        }

        // GET: GroupCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupCategory = await _context.GroupCategories
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.GroupCategoryId == id);
            if (groupCategory == null)
            {
                return NotFound();
            }

            return View(groupCategory);
        }

        // POST: GroupCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groupCategory = await _context.GroupCategories.FindAsync(id);
            if (groupCategory != null)
            {
                _context.GroupCategories.Remove(groupCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupCategoryExists(int id)
        {
            return _context.GroupCategories.Any(e => e.GroupCategoryId == id);
        }
    }
}
