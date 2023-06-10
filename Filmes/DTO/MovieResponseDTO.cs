namespace Filmes.DTO;

public class MovieResponseDto
{
    public string Name { get; set; }
    public int Length { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }

    public MovieResponseDto(string name, int length, string director, string genre)
    {
        Name = name;
        Length = length;
        Director = director;
        Genre = genre;
    }
}