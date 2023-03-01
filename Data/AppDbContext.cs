using Microsoft.EntityFrameworkCore;
using ProjetoEcommerceAPI.Controllers.Models;

namespace ProjetoEcommerceAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt ) : base( opt )
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategoria>()
                .HasOne(subCategoria => subCategoria.Categoria)
                .WithMany(categoria => categoria.SubCategorias)
                .HasForeignKey(subCategoria => subCategoria.CategoriaId);

            builder.Entity<Produto>()
                .HasOne(produto => produto.SubCategoria)
                .WithMany(subcategoria => subcategoria.Produtos)
                .HasForeignKey(produto => produto.SubCategoriaId);
        }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}

   
   