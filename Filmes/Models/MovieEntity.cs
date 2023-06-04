using System.ComponentModel.DataAnnotations;

namespace Filmes.Models;

public class MovieEntity
{
    [Required] public int Id { get; set; }
    [Required] [MaxLength(100)] public string Name { get; set; }
    [Required] public int Length { get; set; }
    [Required] [MaxLength(100)] public string Director { get; set; }
    [Required] [MaxLength(60)] public string Genre { get; set; }
}