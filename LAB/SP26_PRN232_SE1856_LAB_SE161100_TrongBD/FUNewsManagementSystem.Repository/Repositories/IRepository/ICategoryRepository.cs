using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.Repositories.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetActiveCategoriesAsync();
        Task<List<Category>> GetCategoriesByParentIdAsync(int? parentId);
        Task<Category> GetCategoryWithChildrenAsync(int id);
    }
}