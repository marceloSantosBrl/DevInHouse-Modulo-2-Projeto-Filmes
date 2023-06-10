using Filmes.DTO;
using Filmes.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("test")]
public class Test : ControllerBase
{


    [HttpGet("{id:int}")]
    public ActionResult<MovieResponseDto> GetActionResult(int id)
    {
        try
        {
            var movie = MoviesRepository.GetMovie(id);
            return Ok(movie);
        }
        catch (ArgumentException)
        {
            return NotFound("Filme com o id não encontrado");
        }
    }

    [HttpPut]
    public IActionResult PutActionResult([FromBody] MovieRequestDto movie)
    {
        MoviesRepository.AddMovie(movie);
        return Created($"/test/{MoviesRepository.GetIndexFromRequest(movie)}", movie);
    }

    [HttpPatch("{id:int}")]
    public IActionResult PatchActionResult(
        [FromBody] JsonPatchDocument<MovieRequestDto> patchDocument,
        int id)
    {
        try
        {
            MoviesRepository.PatchMovie(patchDocument, id);
            return NoContent();
        }
        catch
        {
            return NotFound("filme com o id não encontrado");
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteActionResult(int id)
    {
        try
        {
            MoviesRepository.DeleteMovie(id);
            return NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound("Filme com o id não encontrado");
        }
    }

}