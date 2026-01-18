using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Repository.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(FUNewsDBContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetActiveCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => c.IsActive == true)
                .Include(c => c.ParentCategory)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByParentIdAsync(int? parentId)
        {
            return await _context.Categories
                .Where(c => c.ParentCategoryId == parentId)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryWithChildrenAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.InverseParentCategory)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(c => c.CategoryId == id);
        }
    }
}