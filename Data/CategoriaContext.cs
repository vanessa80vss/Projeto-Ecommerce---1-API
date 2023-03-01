using Microsoft.EntityFrameworkCore;
using ProjetoEcommerceAPI.Controllers.Models;

namespace ProjetoEcommerceAPI.Data
{
    public class CategoriaContext : DbContext
    {
        public CategoriaContext(DbContextOptions<CategoriaContext> opt ) : base( opt )
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategoria>()
                .HasOne(subCategoria => subCategoria.Categoria)
                .WithMany(categoria => categoria.SubCategorias)
                .HasForeignKey(subCategoria => subCategoria.CategoriaId);
        }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }
    }
}

   
   