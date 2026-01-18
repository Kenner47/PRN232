using FUNewsManagementSystem.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FUNewsManagementSystem.Service.Services.IServices
{
    public interface INewsArticleService
    {
        Task<List<NewsArticle>> GetAllNewsArticlesAsync();
        Task<NewsArticle> GetNewsArticleByIdAsync(int id);
        Task<NewsArticle> GetNewsArticleWithDetailsAsync(int id);
        Task<List<NewsArticle>> GetNewsArticlesByCategoryAsync(int categoryId);
        Task<List<NewsArticle>> GetNewsArticlesByStatusAsync(int status);
        Task<List<NewsArticle>> GetNewsArticlesByAuthorAsync(int authorId);
        Task<List<NewsArticle>> GetRecentNewsArticlesAsync(int count);
        Task<bool> CreateNewsArticleAsync(NewsArticle newsArticle);
        Task<bool> UpdateNewsArticleAsync(NewsArticle newsArticle);
        Task<bool> DeleteNewsArticleAsync(int id);
    }
}