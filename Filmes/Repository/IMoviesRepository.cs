using Filmes.DTO;
using Microsoft.AspNetCore.JsonPatch;

public interface IMoviesRepository {
    public Task<MovieResponseDto> GetMovie(int id);
    public Task<int> AddMovie(MovieRequestDto movie);
    public Task DeleteMovie(int id);
    public Task PatchMovie(JsonPatchDocument<MovieRequestDto> patchDoc,int id);
}