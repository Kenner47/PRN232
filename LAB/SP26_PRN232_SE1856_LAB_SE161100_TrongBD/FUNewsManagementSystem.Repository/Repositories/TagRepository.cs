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
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(FUNewsDBContext context) : base(context)
        {
        }

        public async Task<Tag> GetTagByNameAsync(string tagName)
        {
            return await _context.Tags
                .FirstOrDefaultAsync(t => t.TagName == tagName);
        }

        public async Task<List<Tag>> GetTagsByNewsArticleIdAsync(int newsArticleId)
        {
            return await _context.Tags
                .Where(t => t.NewsArticles.Any(n => n.NewsArticleId == newsArticleId))
                .ToListAsync();
        }

        public async Task<bool> IsTagNameExistAsync(string tagName)
        {
            return await _context.Tags
                .AnyAsync(t => t.TagName == tagName);
        }
    }
}