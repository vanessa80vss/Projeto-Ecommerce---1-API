using AutoMapper;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;

namespace ProjetoEcommerceAPI.Profiles
{
    public class CategoriaProfile: Profile
       
    {
        public CategoriaProfile()
        {

            CreateMap<CreateCategoriaDto, Categoria>();
            CreateMap<Categoria, ReadCategoriaDto>();
            CreateMap<UpDateCategoriaDto, Categoria>();
        }
    }
}

