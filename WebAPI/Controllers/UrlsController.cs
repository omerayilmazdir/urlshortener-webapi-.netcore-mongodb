using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlsController : ControllerBase
    {
        private readonly ShortUrlService _shorturlService;

        public UrlsController(ShortUrlService shorturlService)
        {
            _shorturlService = shorturlService;
        }

        [HttpGet]
        public ActionResult<List<ShortenedUrl>> Get() =>
            _shorturlService.Get();

        [HttpGet("{id:length(24)}", Name = "GetName")]
        public ActionResult<ShortenedUrl> Get(string id)
        {
            var shortUrl = _shorturlService.Get(id);

            if (shortUrl == null)
            {
                return NotFound();
            }

            return shortUrl;
        }

        [HttpPost]
        public ActionResult<ShortenedUrl> Create(ShortenedUrl url)
        {
            _shorturlService.Create(url);

            return CreatedAtRoute("GetName", new { id = url.Id.ToString() }, url);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, ShortenedUrl shortUrlIn)
        {
            var shortUrl = _shorturlService.Get(id);

            if (shortUrl == null)
            {
                return NotFound();
            }

            _shorturlService.Update(id, shortUrlIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _shorturlService.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            _shorturlService.Remove(id);

            return NoContent();
        }
    }
}
