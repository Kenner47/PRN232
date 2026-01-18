using FUNewsManagementSystem.Repository.Models;
using FUNewsManagementSystem.Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            var tags = await _tagService.GetAllTagsAsync();
            return Ok(tags);
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);

            if (tag == null)
            {
                return NotFound(new { message = $"Tag with ID {id} not found." });
            }

            return Ok(tag);
        }

        // GET: api/Tags/name/technology
        [HttpGet("name/{tagName}")]
        public async Task<ActionResult<Tag>> GetTagByName(string tagName)
        {
            var tag = await _tagService.GetTagByNameAsync(tagName);

            if (tag == null)
            {
                return NotFound(new { message = $"Tag with name '{tagName}' not found." });
            }

            return Ok(tag);
        }

        // GET: api/Tags/newsarticle/5
        [HttpGet("newsarticle/{newsArticleId}")]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTagsByNewsArticle(int newsArticleId)
        {
            var tags = await _tagService.GetTagsByNewsArticleIdAsync(newsArticleId);
            return Ok(tags);
        }

        // POST: api/Tags
        [HttpPost]
        public async Task<ActionResult<Tag>> CreateTag(Tag tag)
        {
            var result = await _tagService.CreateTagAsync(tag);

            if (!result)
            {
                return BadRequest(new { message = "Failed to create tag. Tag name may already exist." });
            }

            return CreatedAtAction(nameof(GetTag), new { id = tag.TagId }, tag);
        }

        // PUT: api/Tags/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTag(int id, Tag tag)
        {
            if (id != tag.TagId)
            {
                return BadRequest(new { message = "Tag ID mismatch." });
            }

            var result = await _tagService.UpdateTagAsync(tag);

            if (!result)
            {
                return NotFound(new { message = $"Tag with ID {id} not found." });
            }

            return NoContent();
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var result = await _tagService.DeleteTagAsync(id);

            if (!result)
            {
                return NotFound(new { message = $"Tag with ID {id} not found." });
            }

            return NoContent();
        }
    }
}