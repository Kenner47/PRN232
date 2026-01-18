using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsArticlesController : ControllerBase
    {
        private readonly INewsArticleService _newsArticleService;

        public NewsArticlesController(INewsArticleService newsArticleService)
        {
            _newsArticleService = newsArticleService;
        }

        // GET: api/NewsArticles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticles()
        {
            var newsArticles = await _newsArticleService.GetAllNewsArticlesAsync();
            return Ok(newsArticles);
        }

        // GET: api/NewsArticles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsArticle>> GetNewsArticle(int id)
        {
            var newsArticle = await _newsArticleService.GetNewsArticleByIdAsync(id);

            if (newsArticle == null)
            {
                return NotFound(new { message = $"News article with ID {id} not found." });
            }

            return Ok(newsArticle);
        }

        // GET: api/NewsArticles/5/details
        [HttpGet("{id}/details")]
        public async Task<ActionResult<NewsArticle>> GetNewsArticleWithDetails(int id)
        {
            var newsArticle = await _newsArticleService.GetNewsArticleWithDetailsAsync(id);

            if (newsArticle == null)
            {
                return NotFound(new { message = $"News article with ID {id} not found." });
            }

            return Ok(newsArticle);
        }

        // GET: api/NewsArticles/category/5
        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticlesByCategory(int categoryId)
        {
            var newsArticles = await _newsArticleService.GetNewsArticlesByCategoryAsync(categoryId);
            return Ok(newsArticles);
        }

        // GET: api/NewsArticles/status/1
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticlesByStatus(int status)
        {
            var newsArticles = await _newsArticleService.GetNewsArticlesByStatusAsync(status);
            return Ok(newsArticles);
        }

        // GET: api/NewsArticles/author/5
        [HttpGet("author/{authorId}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNewsArticlesByAuthor(int authorId)
        {
            var newsArticles = await _newsArticleService.GetNewsArticlesByAuthorAsync(authorId);
            return Ok(newsArticles);
        }

        // GET: api/NewsArticles/recent/10
        [HttpGet("recent/{count}")]
        public async Task<ActionResult<IEnumerable<NewsArticle>>> GetRecentNewsArticles(int count)
        {
            var newsArticles = await _newsArticleService.GetRecentNewsArticlesAsync(count);
            return Ok(newsArticles);
        }

        // POST: api/NewsArticles
        [HttpPost]
        public async Task<ActionResult<NewsArticle>> CreateNewsArticle(NewsArticle newsArticle)
        {
            var result = await _newsArticleService.CreateNewsArticleAsync(newsArticle);

            if (!result)
            {
                return BadRequest(new { message = "Failed to create news article." });
            }

            return CreatedAtAction(nameof(GetNewsArticle), new { id = newsArticle.NewsArticleId }, newsArticle);
        }

        // PUT: api/NewsArticles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNewsArticle(int id, NewsArticle newsArticle)
        {
            if (id != newsArticle.NewsArticleId)
            {
                return BadRequest(new { message = "News article ID mismatch." });
            }

            var result = await _newsArticleService.UpdateNewsArticleAsync(newsArticle);

            if (!result)
            {
                return NotFound(new { message = $"News article with ID {id} not found." });
            }

            return NoContent();
        }

        // DELETE: api/NewsArticles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsArticle(int id)
        {
            var result = await _newsArticleService.DeleteNewsArticleAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"News article with ID {id} not found." });
            }

            return NoContent();
        }
    }
}