using Filmes.DTO;
using Filmes.Models;

namespace Filmes.Mappings;

public static class MoviesMappings
{


    public static MovieEntity MovieRequestToEntity(MovieRequestDto movieRequestDto)
    {
        return new MovieEntity(
            name: movieRequestDto.Name,
            length: movieRequestDto.Length,
            director: movieRequestDto.Director,
            genre: movieRequestDto.Genre
        );
    }

    public static MovieResponseDto MovieEntityToResponse(MovieEntity movieEntity)
    {
        return new MovieResponseDto(
            name: movieEntity.Name,
            length: movieEntity.Length,
            director: movieEntity.Director,
            genre: movieEntity.Genre
        );
    }
    
    public static MovieRequestDto MovieResponseToRequestDto(MovieResponseDto movieResponse)
    {
        return new MovieRequestDto(
            name: movieResponse.Name,
            length: movieResponse.Length,
            director: movieResponse.Director,
            genre: movieResponse.Genre
        );
    }
}