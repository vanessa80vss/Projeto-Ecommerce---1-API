using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEcommerceAPI.Data.Dtos.Categoria
{
    public class UpDateCategoriaDto
    {
        [Required(ErrorMessage = "o campo nome da categoria é obrigatório")]
        [RegularExpression(@"^[a-z A-Z]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        public string NomeDaCategoria { get; set; }
        public bool StatusDaCategoria { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}


//https://localhost:5001/categoria?nome=ele&ordem=desc
