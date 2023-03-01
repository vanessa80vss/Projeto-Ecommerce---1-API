using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.SubCategoria;
using System;
using System.Linq;

namespace ProjetoEcommerceAPI.Repository
{
    public class SubCategoriaRepository
    {
        private AppDbContext _context;
        public SubCategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarSubCategoria(SubCategoria subCategoria)
        {
            _context.Add(subCategoria);
            _context.SaveChanges();
        }

        public void EditarSubCategoria(SubCategoria subCategoriaDto)
        {
            _context.Update(subCategoriaDto);
            _context.SaveChanges();
        }

        public void DeletarSubCategoria(SubCategoria SubCategoriaDto)
        {
            _context.Remove(SubCategoriaDto);
            _context.SaveChanges();
        }

        public SubCategoria PesquisarSubCategoriaPorNome(CreateSubCategoriaDto subCategoriaDto)
        {
            return _context.SubCategorias.FirstOrDefault(subCategoria => subCategoria.NomeDaSubCategoria.ToUpper()
            == subCategoriaDto.NomeDaSubCategoria.ToUpper());

        }

        public SubCategoria PesquisarSubCategoriaPorId(int id)
        {
            return _context.SubCategorias.FirstOrDefault(subCategoria => subCategoria.Id == id);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public IQueryable<SubCategoria> PesquisarSubCategoriaComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
            IQueryable<SubCategoria> lista = null;
            if (nome != null)
            {
                lista = _context.SubCategorias.Where(c => c.NomeDaSubCategoria.ToLower().Contains(nome.ToLower()));
            }
            else
            {
                lista = _context.SubCategorias;
            }
            if (status != null)
            {
                lista = lista.Where(c => c.StatusDaSubCategoria == status);
            }
            if (ordem != null)
            {
                if (ordem.ToLower() == "desc")
                {
                    lista = lista.OrderByDescending(c => c.NomeDaSubCategoria);
                    return lista;
                }
                else if (ordem.ToLower() == "asc")
                {
                    lista = lista.OrderBy(c => c.NomeDaSubCategoria);
                    return lista;
                }
                return lista = null;

                //if (quantidade > 0 && pagina > 0)
                //{
                //    var resultado = lista.Skip((pagina - 1) * quantidade).Take(quantidade).ToList();
                //}

            }
            return lista;
        }
    }
}

