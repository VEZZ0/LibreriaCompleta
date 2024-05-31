using LibreriaCompleta.Models.Dto;
using LibreriaCompleta.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibreriaCompleta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        

        [HttpGet("GetScaffale", Name = "GetScaffale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LibroDTO>> GetLibri()
        {
            var listaLibri = Scaffale.getListaLibri();
            if (listaLibri == null || !listaLibri.Any())
            {
                return NoContent();
            }

            return Ok(listaLibri);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LibroDTO> CreateLibro([FromBody] LibroDTO librodto)
        {
            if (librodto == null)
            {
                return BadRequest();
            }

            Scaffale.listaLibri.Add(librodto);

            return CreatedAtAction(nameof(GetLibri), new { }, librodto);
        }

        [HttpDelete("{isbn}", Name = "DeleteLibro")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteBiblioteca(string isbn)
        {
            if (isbn.Length != 10 || isbn.Length != 13) return BadRequest();
            var libro = Scaffale.listaLibri.FirstOrDefault(l => l.isbn == isbn);
            if (libro == null)                          return NotFound();
            Scaffale.listaLibri.Remove(libro);
            return NoContent();
        }
    }
}
