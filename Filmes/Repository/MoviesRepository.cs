using Filmes.DTO;
using Filmes.Mappings;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace Filmes.Repository;

public class MoviesRepository: IMoviesRepository
{
    
    private readonly MovieContext _context;

    public MoviesRepository(MovieContext context)
    {
        _context = context;
    }

    public async Task<MovieResponseDto> GetMovie(int id)
    {
        try
        {
            var movie = await _context.Movies.FirstAsync(x => x.Id == id);
            return MoviesMappings.MovieEntityToResponse(movie);

        }
        catch
        {
            throw new Exception("Erro ao recuperar filme");
        }
    }

    public async Task<int> AddMovie(MovieRequestDto movie)
    {
        var movieEntity = MoviesMappings.MovieRequestToEntity(movie);
        _context.Movies.Add(movieEntity);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0 ) {
            throw new Exception($"Falha ao adicionar {nameof(movie)} ao banco de dados");
        }
        return movieEntity.Id;
    }

    public async Task DeleteMovie(int id)
    {
        var movieToDelete = await _context.Movies.FindAsync(id) 
        ?? throw new Exception($"Filme com Id:{id} não encontrado");

        _context.Movies.Remove(movieToDelete);
        var recordsChanged = await _context.SaveChangesAsync();
        if (recordsChanged == 0) {
            throw new Exception($"Falha ao remover filme com id:{id} ao banco de dados");
        }
    }

    public async Task PatchMovie(
        JsonPatchDocument<MovieRequestDto> patchDoc,
        int id)
    {
        var movie = await _context.Movies.Where(m => m.Id == id).FirstOrDefaultAsync() ??
        throw new ArgumentException(nameof(id), $"filme com o id ${id} não encontrado");
        var movieResponse = MoviesMappings.MovieEntityToRequest(movie);
        patchDoc.ApplyTo(movieResponse);
        var recordsChanged = await _context.Database.ExecuteSqlAsync($@"UPDATE Movies 
                                                                        SET Name = {movieResponse.Name},
                                                                            Length = {movieResponse.Length},
                                                                            Director = {movieResponse.Director},
                                                                            Genre = {movieResponse.Genre}
                                                                        WHERE Id = {id}");
        if(recordsChanged == 0) {
            throw new ArgumentException("Erro ao recuperar filme", nameof(id));
        }
    }

}