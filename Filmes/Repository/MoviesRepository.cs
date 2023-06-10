using Filmes.DTO;
using Filmes.Mappings;
using Filmes.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Filmes.Repository;

public static class MoviesRepository
{
    private static readonly List<MovieEntity> _movies = Data.MovieData;

    public static MovieResponseDto GetMovie(int index)
    {
        MovieEntity movie;
        try
        {
            movie = _movies.ElementAt(index);
        }
        catch (Exception)
        {
            throw new ArgumentException($"O elemento {index} não encontrado no banco de dados",
                nameof(index));
        }

        return MoviesMappings.MovieEntityToResponse(movie);
    }

    public static void AddMovie(MovieRequestDto movie)
    {
        var movieEntity = MoviesMappings.MovieRequestToEntity(movie);
        _movies.Add(movieEntity);
    }

    public static void DeleteMovie(int id)
    {
        _movies.RemoveAt(id);
    }

    public static void PatchMovie(
        JsonPatchDocument<MovieRequestDto> patchDoc,
        int id)
    {
        var movie = GetMovie(id);
        var movieResponse = MoviesMappings.MovieResponseToRequestDto(movie);
        patchDoc.ApplyTo(movieResponse);
        DeleteMovie(id);
        AddMovie(movieResponse);
    }

    public static int GetIndexFromRequest(MovieRequestDto requestDto) {
        var movie = MoviesMappings.MovieRequestToEntity(requestDto);
        return _movies.IndexOf(movie);
    }
}