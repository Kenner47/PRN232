using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Service.Services.IServices
{
    public interface ITagService
    {
        Task<List<Tag>> GetAllTagsAsync();
        Task<Tag> GetTagByIdAsync(int id);
        Task<Tag> GetTagByNameAsync(string tagName);
        Task<List<Tag>> GetTagsByNewsArticleIdAsync(int newsArticleId);
        Task<bool> CreateTagAsync(Tag tag);
        Task<bool> UpdateTagAsync(Tag tag);
        Task<bool> DeleteTagAsync(int id);
        Task<bool> IsTagNameExistAsync(string tagName);
    }
}