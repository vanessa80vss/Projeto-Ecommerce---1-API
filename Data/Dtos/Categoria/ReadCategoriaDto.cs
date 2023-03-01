using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEcommerceAPI.Data.Dtos.Categoria
{
    public class ReadCategoriaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo nome da categoria é obrigatório")]
        [RegularExpression(@"^[a-z A-Z]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        public string NomeDaCategoria { get; set; }

        [Required(ErrorMessage = "o campo Status da Categoria já é cadastrado como ativo")]
        public bool StatusDaCategoria { get; set; }

        public DateTime DataCriacao { get; set; }
        
    }
}
