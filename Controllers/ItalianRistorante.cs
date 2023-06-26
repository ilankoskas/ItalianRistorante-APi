using Microsoft.AspNetCore.Mvc;
using WebApplicationAPi.Models;
using WebApplicationAPi.Services;

namespace WebApplicationAPi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ItalianRistorante : ControllerBase
    {
        private readonly BooksService _booksService;
        public ItalianRistorante(BooksService booksService) =>
            _booksService = booksService;

        [HttpGet]
        public async Task<List<Plats>> GetPlatsAsync() =>
        await _booksService.GetAsync();



        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Plats>> Get(String id)
        {
            var plat = await _booksService.GetPlatsAsync(id);
            if (plat is null)
            {
                return NotFound();
            }
            return Ok(plat);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Plats newPlats)
        {
            await _booksService.CreateAsync(newPlats);
            return CreatedAtAction(nameof(Get), new { id = newPlats.Id }, newPlats);

        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(String id, Plats newPlats)
        {
            var plat = await _booksService.GetPlatsAsync(id);

            if (plat is null)
            {
                return NotFound();
            }
            newPlats.Id = plat.Id;
            await _booksService.UpdateAsync(id, newPlats);
            return NoContent();





        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(String id)
        {
          var plat = await _booksService.GetPlatsAsync(id);

            if (plat is null)
            {
                return NotFound();

            }
            await _booksService.RemoveAsync(id);

            return NoContent();



        }

    }
}
