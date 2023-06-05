using Filmes.DTO;
using Filmes.Models;

namespace Filmes.Mappings;

public static class MoviesMappings
{
    public static MovieEntity MovieRequestToEntity(MovieRequestDto movieRequestDto)
    {
        return new MovieEntity(
            id: movieRequestDto.Id,
            name: movieRequestDto.Name,
            length: movieRequestDto.Length,
            director: movieRequestDto.Director,
            genre: movieRequestDto.Genre
        );
    }

    public static MovieResponseDto MovieEntityToResponse(MovieEntity movieEntity)
    {
        return new MovieResponseDto(
            id: movieEntity.Id,
            name: movieEntity.Name,
            length: movieEntity.Length,
            director: movieEntity.Director,
            genre: movieEntity.Genre
        );
    }
    
    public static MovieRequestDto MovieResponseToRequestDto(MovieResponseDto movieResponse)
    {
        return new MovieRequestDto(
            id: movieResponse.Id,
            name: movieResponse.Name,
            length: movieResponse.Length,
            director: movieResponse.Director,
            genre: movieResponse.Genre
        );
    }
}