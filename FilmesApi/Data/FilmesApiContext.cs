using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data;

public class FilmesApiContext : DbContext
{
    public FilmesApiContext(DbContextOptions<FilmesApiContext> options)
        : base(options) { }

    public DbSet<Filme> Filmes { get; set; }
    public DbSet<Cinema> Cinemas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }    
    public DbSet<Gerente> Gerentes { get; set; }    
    public DbSet<Sessao> Sessoes { get; set; }    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //1 x 1
        modelBuilder.Entity<Cinema>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cinema)
            .HasForeignKey<Cinema>(c => c.EnderecoId);       

        //1 x N
        modelBuilder.Entity<Cinema>()
            .HasOne(c => c.Gerente)
            .WithMany(g => g.Cinemas)
            .HasForeignKey(c => c.GerenteId);

        //N x N
        modelBuilder.Entity<Sessao>()
            .HasOne(sessao => sessao.Cinema)
            .WithMany(cinema => cinema.Sessoes)
            .HasForeignKey(sessao => sessao.CinemaId);
        modelBuilder.Entity<Sessao>()
            .HasOne(sessao => sessao.Filme)
            .WithMany(filme => filme.Sessoes)
            .HasForeignKey(sessao => sessao.FilmeId);

        base.OnModelCreating(modelBuilder);
    }
}
