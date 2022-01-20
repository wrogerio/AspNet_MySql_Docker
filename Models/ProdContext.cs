using Microsoft.EntityFrameworkCore;

namespace MySqlNet.Models
{
    public class ProdContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().ToTable("tbProdutos");
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Descricao).HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Produto>().Property(p => p.Valor).HasPrecision(8, 2).HasDefaultValue(0);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("server=host.docker.internal;user=root;database=produtosDB;password=root", new MySqlServerVersion(new System.Version()));
        }
    }
}
