using Filmes.DTO;
using Filmes.Models;

namespace Filmes.Repository;

public static class Data
{
    
    public static List<MovieEntity> MovieData = new( new []
    {
        new MovieEntity(
            name: "ShawShank Redemption",
            length: 230,
            director: "SSR Director",
            genre: "drama"),
        new MovieEntity(
            name: "Spider-Man",
            length: 190,
            director: "S-M Director",
            genre: "Hero"),
        new MovieEntity(
            name: "Ricochet",
            length: 100,
            director: "RC Director",
            genre: "Action"),
    });
}