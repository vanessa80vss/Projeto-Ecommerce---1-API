using AutoMapper;
using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data.Dtos.Produto;


namespace ProjetoEcommerceAPI.Profiles
{
    public class ProdutoProfile: Profile
       
    {
        public ProdutoProfile()
        {

            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<Produto, ReadProdutoDto>();
            CreateMap<UpDateProdutoDto, Produto>();
        }
    }
}

