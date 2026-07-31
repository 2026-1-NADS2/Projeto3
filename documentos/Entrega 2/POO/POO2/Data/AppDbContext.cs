using Microsoft.EntityFrameworkCore;
using POO2.Models;

namespace POO2.Data
{
    public class AppDbContext : DbContext
    {
        //Construtor do banco
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Comprador> Comprador {get; set;}
        public DbSet<Vendedor> Vendedor {get; set;}

        public DbSet<Anuncio> Anuncio {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Informa que o CNPJ na classe Vendedor é único e uma chave alternativa
            modelBuilder.Entity<Vendedor>()
                .HasAlternateKey(v => v.cnpj);

            // 2. Configura o relacionamento específico
            modelBuilder.Entity<Anuncio>()
                .HasOne(a => a.vendedor)
                .WithMany() // ou .WithMany(v => v.Anuncios) se houver uma lista no Vendedor
                .HasForeignKey(a => a.fornecedor)
                .HasPrincipalKey(v => v.cnpj); // Aqui definimos que a ligação é pelo CNPJ
        }
    }
}