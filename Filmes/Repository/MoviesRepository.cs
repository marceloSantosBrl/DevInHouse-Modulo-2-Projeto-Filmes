using Filmes.DTO;
using Filmes.Mappings;
using Filmes.Models;

namespace Filmes.Repository;

public class MoviesRepository
{
    private readonly List<MovieEntity> _movies = Data.MovieData;

    public int Lenght()
    {
        return _movies.Count;
    }
    
    public MovieResponseDto GetMovie(int id)
    {
        MovieEntity movie;
        try
        {
            movie = _movies.ElementAt(id);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"O elemento {id} não encontrado no banco de dados",
                nameof(id));
        }

        return MoviesMappings.MovieEntityToResponse(movie);
    }

    public void AddMovie(MovieRequestDto movie)
    {
        var movieEntity = MoviesMappings.MovieRequestToEntity(movie);
        _movies.Add(movieEntity);
    }

    public void DeleteMovie(int id)
    {
        _movies.RemoveAt(id);
    }
}