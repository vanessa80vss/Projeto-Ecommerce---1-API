using System.ComponentModel.DataAnnotations;

namespace ProjetoEcommerceAPI.Data.Dtos.SubCategoria
{
    public class CreateSubCategoriaDto
    {

        [Required(ErrorMessage = "o campo nome da categoria é obrigatório")]
        [RegularExpression(@"^[a-z A-Z]{0,128}$", ErrorMessage = "O campo nome da categoria é somente letras e até 128 caracteres")]
        public string NomeDaSubCategoria { get; set; }
        
        public int CategoriaId { get; set; }

    }
}
