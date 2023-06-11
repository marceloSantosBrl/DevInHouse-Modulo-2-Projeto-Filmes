using Filmes.DTO;
using Filmes.Mappings;
using Filmes.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("test")]
public class Test : ControllerBase
{

    private readonly IMoviesRepository _repository;

    public Test(IMoviesRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("{id:int}")]
    public async Task<ActionResult<MovieResponseDto>> GetActionResult(int id)
    {
        try
        {
            var movie = await _repository.GetMovie(id);
            return Ok(movie);
        }
        catch
        {
            return NotFound("Filme com o id não encontrado");
        }
    }

    [HttpPut]
    public async Task<ActionResult<int>> PutActionResult([FromBody] MovieRequestDto movie)
    {
        try
        {
            var id = await _repository.AddMovie(movie);
            return Ok(id);
        }
        catch
        {
            return BadRequest("Falha ao adicionar filme ao banco de dados");
        }
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> PatchActionResult(
        [FromBody] JsonPatchDocument<MovieRequestDto> patchDocument,
        int id)
    {
        try
        {
             await _repository.PatchMovie(patchDocument, id);
             return NoContent();
        }
        catch
        {
            return NotFound("filme com o id não encontrado");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteActionResult(int id)
    {
        try
        {
            await _repository.DeleteMovie(id);
            return NoContent();
        }
        catch (ArgumentOutOfRangeException)
        {
            return NotFound("Filme com o id não encontrado");
        }
    }

}