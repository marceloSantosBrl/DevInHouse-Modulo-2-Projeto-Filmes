namespace Filmes.DTO;

public class MovieResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Length { get; set; }
    public string Director { get; set; }
    public string Genre { get; set; }

    public MovieResponseDto(int id, string name, int length, string director, string genre)
    {
        Id = id;
        Name = name;
        Length = length;
        Director = director;
        Genre = genre;
    }
}