using System.ComponentModel.DataAnnotations;

namespace ProjetoEcommerceAPI.Data.Dtos.Produto
{
    public class CreateProdutoDto
    {
        
        [Required(ErrorMessage = "o campo nome do produto é obrigatório")]
        [RegularExpression(@"^[a-z A-Z ]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        [StringLength(128, MinimumLength = 3)]
        public string NomeDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo descrição do produto é obrigatório")]
        [RegularExpression(@"^[a-z A-Z ]{3,512}$", ErrorMessage = "O campo descriçãodo produto aceita letras e números até  512 caracteres")]
        [StringLength(512, MinimumLength = 3)]
        public string DescricaoDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo peso do produto é obrigatório")]
        public decimal PesoDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo altura do produto é obrigatório")]
        public decimal AlturaDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo largura do produto é obrigatório")]
        public decimal LarguraDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo comprimento do produto é obrigatório")]
        public decimal ComprimentoDoProduto { get; set; } 

       [Required(ErrorMessage = "o campo valor do produto é obrigatório")]
        public decimal ValorDoProduto { get; set; } 
        [Required(ErrorMessage = "o campo quantidade em estoque do produto é obrigatório")]
        public int QuantidadeEmEstoqueDoProduto { get; set; } 
        //[Required(ErrorMessage = "o campo Centro de distribuição do produto é obrigatório")]
        //[RegularExpression(@"^[a-z A-Z ]{0,128}$", ErrorMessage = "O campo centro de distribuição é somente letras e até 128 caracteres")]
        //[StringLength(512, MinimumLength = 3)]
        public string CentroDeDistribuicao { get; set; } 

        public bool StatusDoProduto { get; set; }

        public int SubCategoriaId { get; set; } 

    }
}
/********* perguntas... 
 * aqui no create não devo criar uma dependencia?  ok virtual devido override
 * 
 * e no categoria context preciso fazer o relacionamento de produto e subcategoria e categoria?
 * ok fazer
 * 
 * 
 * e o dbset produtos não fiz... pq estou acessando pelo dapper ou ? tem que fazer dbset produtos
 * 
 * 
 * protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SubCategoria>()
                .HasOne(subCategoria => subCategoria.Categoria)
                .WithMany(categoria => categoria.SubCategorias)
                .HasForeignKey(subCategoria => subCategoria.CategoriaId);
        }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<SubCategoria> SubCategorias { get; set; }


{
    "NomeDoProduto" : "produtonovo",
    "DescricaoDoProduto": 
    "StatusDoProduto": true,
    "PesoDoProduto": 240,
    "AlturaDoProduto": 16.1,
    "LarguraDoProduto": 7.76,
    "ComprimentoDoProduto":0.78,
    "ValorDoProduto": 13.499,
    "QuantidadeEmEstoqueDoProduto": 100,
    "CentroDeDistribuicao" : "SP"
    "SubCategoriaId": 2

}
 * 
 * */