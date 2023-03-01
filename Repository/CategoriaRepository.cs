using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Categoria;
using System;
using System.Linq;

namespace ProjetoEcommerceAPI.Repository
{
    public class CategoriaRepository 
    { 
        private AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            _context.SaveChanges();
        }

        public void EditarCategoria(Categoria categoriaDto)
        {
            _context.Update(categoriaDto);
            _context.SaveChanges();
        }

        public void DeletarCategoria(Categoria categoriaDto)
        {
            _context.Remove(categoriaDto);
            _context.SaveChanges();
        }

        public Categoria PesquisarCategoriaPorNome(CreateCategoriaDto categoriaDto)
        { 
           return  _context.Categorias.FirstOrDefault(categoria => categoria.NomeDaCategoria.ToUpper() 
           == categoriaDto.NomeDaCategoria.ToUpper());
            
        }

        public  Categoria PesquisarCategoriaPorId(int id)
        {
            return _context.Categorias.FirstOrDefault(categoria => categoria.Id == id);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public IQueryable<Categoria> PesquisarComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
            IQueryable<Categoria> lista = null;
            if (nome != null)
            {
                lista = _context.Categorias.Where(c => c.NomeDaCategoria.ToLower().Contains(nome.ToLower()));
            }
            else
            {
                lista = _context.Categorias;
            }
            if (status != null)
            {
                lista = lista.Where(c => c.StatusDaCategoria == status);
            }
            if (ordem != null)
            {
                if (ordem.ToLower() == "desc")
                {
                    lista = lista.OrderByDescending(c => c.NomeDaCategoria);
                    return lista;
                }
                else if (ordem.ToLower() == "asc") 
                {
                    lista = lista.OrderBy(c => c.NomeDaCategoria);
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

    /*
     * //esse aqui depois eu faço a refatoração no repository - fazer um metodo de validar nomeexistente
            Categoria categoriaRepetida = _context.Categorias.FirstOrDefault(categoria => categoria.NomeDaCategoria.ToLower().Equals(categoria.NomeDaCategoria));

            if (categoriaRepetida != null)
                return BadRequest("Digite um novo nome, não pode existir categoria com nomes iguais");
     */
}
