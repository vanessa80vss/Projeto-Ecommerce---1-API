using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoEcommerceAPI.Controllers.Models

{
    public class Produto
    {

        [Key]
        [Required]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "o campo nome do produto é obrigatório")]
        [RegularExpression(@"^[a-z A-Z ]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        [StringLength(128, MinimumLength = 3)]
        public string NomeDoProduto { get; set; } //        (obrigatório - 128 caracteres - alfanumérico)
        [Required(ErrorMessage = "o campo descrição do produto é obrigatório")]
        [RegularExpression(@"^[a-z A-Z ]{3,512}$", ErrorMessage = "O campo descriçãodo produto aceita letras e números até  512 caracteres")]
        [StringLength(512, MinimumLength = 3)]
        public string DescricaoDoProduto { get; set; } // Descrição do produto(obrigatório - 512 caracteres - alfanumérico)
        [Required(ErrorMessage = "o campo peso do produto é obrigatório")]
        public decimal PesoDoProduto { get; set; } //(obrigatório - decimal 0,00)
       [Required(ErrorMessage = "o campo altura do produto é obrigatório")]
        public decimal AlturaDoProduto { get; set; } //  (obrigatório - decimal 0,00)
        [Required(ErrorMessage = "o campo largura do produto é obrigatório")]
        public decimal LarguraDoProduto { get; set; } //(obrigatório - decimal 0,00)
        [Required(ErrorMessage = "o campo comprimento do produto é obrigatório")]
        public decimal ComprimentoDoProduto { get; set; } //(obrigatório - decimal 0,00)

        [Required(ErrorMessage = "o campo valor do produto é obrigatório")]
       public decimal ValorDoProduto { get; set; } //(obrigatório - decimal 0,00)
        [Required(ErrorMessage = "o campo quantidade em estoque do produto é obrigatório")]
       public int QuantidadeEmEstoqueDoProduto {get; set;} //(obrigatório - inteiro)
       //[Required(ErrorMessage = "o campo Centro de distribuição do produto é obrigatório")]
       //[RegularExpression(@"^[a-z A-Z ]{0,128}$", ErrorMessage = "O campo centro de distribuição é somente letras e até 128 caracteres")]
       // [StringLength(512, MinimumLength = 3)]
        public string CentroDeDistribuicao { get; set; } //(obrigatório)
                                                         
        public bool StatusDoProduto { get; set; }

        public DateTime DataCriacaoDoProduto { get; set; }

        public DateTime DataModificacaoDoProduto { get; set; }

        [JsonIgnore]
        public virtual SubCategoria SubCategoria { get; set; }
        public int SubCategoriaId { get; set; }
    }
}

//Required(ErrorMessage = "é obrigatório informar a categoria do produto")]
//Categoria/subcategoria(obrigatório)
