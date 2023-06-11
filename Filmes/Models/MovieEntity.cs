using System.ComponentModel.DataAnnotations;

namespace Filmes.Models;

public class MovieEntity
{
    [Key] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] public int Length { get; set; }
    [Required] [MaxLength(100)] public string Director { get; set; }
    [Required] [MaxLength(60)] public string Genre { get; set; }

    public MovieEntity(string name, int length, string director, string genre)
    {
        Name = name;
        Length = length;
        Director = director;
        Genre = genre;
    }
}