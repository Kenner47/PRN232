using FUNewsManagementSystem.Repository.GenericRepo;
using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Repository.Repositories.IRepository
{
    public interface INewsArticleRepository : IGenericRepository<NewsArticle>
    {
        Task<List<NewsArticle>> GetNewsArticlesByCategoryAsync(int categoryId);
        Task<List<NewsArticle>> GetNewsArticlesByStatusAsync(int status);
        Task<NewsArticle> GetNewsArticleWithDetailsAsync(int id);
        Task<List<NewsArticle>> GetNewsArticlesByAuthorAsync(int authorId);
        Task<List<NewsArticle>> GetRecentNewsArticlesAsync(int count);
    }
}