using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoEcommerceAPI.Controllers.Models
{
    public class Categoria
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "o campo nome da categoria é obrigatório")]
        [RegularExpression(@"^[a-z A-Z]$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        [StringLength(128, MinimumLength = 3)]
        public string NomeDaCategoria { get; set; }
        [Required(ErrorMessage = "o campo Status da Categoria já é cadastrado como ativo")]
        public bool StatusDaCategoria { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataModificacao { get; set; }
        [JsonIgnore]
        public virtual List<SubCategoria> SubCategorias { get; set; }
    }
}
