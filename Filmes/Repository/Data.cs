using Filmes.DTO;
using Filmes.Models;

namespace Filmes.Repository;

public static class Data
{
    
    public static List<MovieEntity> MovieData = new List<MovieEntity>( new []
    {
        new MovieEntity(
            id: 1,
            name: "ShawShank Redemption",
            length: 230,
            director: "SSR Director",
            genre: "drama"),
        new MovieEntity(
            id: 2,
            name: "Spider-Man",
            length: 190,
            director: "S-M Director",
            genre: "Hero"),
        new MovieEntity(
            id: 3,
            name: "Ricochet",
            length: 100,
            director: "RC Director",
            genre: "Action"),
    });
}