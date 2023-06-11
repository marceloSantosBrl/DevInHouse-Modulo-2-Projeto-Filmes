using Filmes.Models;
using Microsoft.EntityFrameworkCore;

public class MovieContext : DbContext
{

    public DbSet<MovieEntity> Movies { get; }
    private readonly IConfiguration _configuration;

    public MovieContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new Exception("Configuration Not Found");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        Console.WriteLine(_configuration.GetConnectionString("DefaultConnection"));
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
    }

}
