using AutoMapper;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data.Dtos.SubCategoria;

namespace ProjetoEcommerceAPI.Profiles
{
    public class SubCategoriaProfile: Profile
       
    {
        public SubCategoriaProfile()
        {

            CreateMap<CreateSubCategoriaDto, SubCategoria>();
            CreateMap<SubCategoria, ReadSubCategoriaDto>();
            CreateMap<UpDateSubCategoriaDto, SubCategoria>();
        }
    }
}

