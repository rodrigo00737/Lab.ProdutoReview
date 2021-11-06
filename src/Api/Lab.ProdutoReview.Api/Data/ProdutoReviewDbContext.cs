using Lab.ProdutoReview.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Lab.ProdutoReview.Api.Data
{
    public class ProdutoReviewDbContext : DbContext
    {
        public ProdutoReviewDbContext(DbContextOptions<ProdutoReviewDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Entidades.ProdutoReview> ProdutoReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(p =>
            {
                p.ToTable("Produto");
                p.HasKey(p => p.Id);

                p
                    .HasMany(pp => pp.Avaliacoes)
                    .WithOne()
                    .HasForeignKey(r => r.ProdutoId);

            });

            modelBuilder.Entity<Entidades.ProdutoReview>(pr => {
                pr.ToTable("ProdutoReview");
                pr.HasKey(pr => pr.Id);

                pr.Property(pr => pr.Autor)
                .HasMaxLength(50)
                .IsRequired();
            });
        }
    }
}
