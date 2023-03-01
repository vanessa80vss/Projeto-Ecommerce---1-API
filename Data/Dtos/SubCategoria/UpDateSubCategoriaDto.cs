using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoEcommerceAPI.Data.Dtos.SubCategoria
{
    public class UpDateSubCategoriaDto
    {
        [Required(ErrorMessage = "o campo nome da categoria é obrigatório")]
        [RegularExpression(@"^[a-z A-Z]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        public string NomeDaSubCategoria { get; set; }
        public bool StatusDaSubCategoria { get; set; }
        public DateTime DataModificacao { get; set; }
    }
}


//https://localhost:5001/categoria?nome=ele&ordem=desc
