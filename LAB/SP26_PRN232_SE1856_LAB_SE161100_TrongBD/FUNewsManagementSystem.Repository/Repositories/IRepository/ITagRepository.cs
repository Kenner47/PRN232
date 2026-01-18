using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.Repositories.IRepository
{
    public interface ITagRepository : IGenericRepository<Tag>
    {
        Task<Tag> GetTagByNameAsync(string tagName);
        Task<List<Tag>> GetTagsByNewsArticleIdAsync(int newsArticleId);
        Task<bool> IsTagNameExistAsync(string tagName);
    }
}