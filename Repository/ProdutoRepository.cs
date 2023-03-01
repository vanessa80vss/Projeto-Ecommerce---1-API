using ProjetoEcommerceAPI.Controllers.Models;
using ProjetoEcommerceAPI.Data;
using ProjetoEcommerceAPI.Data.Dtos.Produto;
using System;
using System.Linq;

namespace ProjetoEcommerceAPI.Repository
{
    public class ProdutoRepository
    {
        private AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CadastrarProduto(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
        }

        public void EditarProduto(Produto produtoDto)
        {
            _context.Update(produtoDto);
            _context.SaveChanges();
        }

        public void DeletarProduto(Produto produtoDto)
        {
            _context.Remove(produtoDto);
            _context.SaveChanges();
        }

        public Produto PesquisarProdutoPorNome(CreateProdutoDto produtoDto)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.NomeDoProduto.ToUpper()
            == produtoDto.NomeDoProduto.ToUpper());

        }

        public Produto PesquisarProdutoPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(produto => produto.ProdutoId == id);
        }
        public void Salvar()
        {
            _context.SaveChanges();
        }

        public IQueryable<Produto> PesquisarProdutoComFiltros(string nome, bool? status, string ordem, int pagina, int quantidade)
        {
            IQueryable<Produto> lista = null;
            if (nome != null)
            {
                lista = _context.Produtos.Where(c => c.NomeDoProduto.ToLower().Contains(nome.ToLower()));
            }
            else
            {
                lista = _context.Produtos;
            }
            if (status != null)
            {
                lista = lista.Where(c => c.StatusDoProduto == status);
            }
            if (ordem != null)
            {
                if (ordem.ToLower() == "desc")
                {
                    lista = lista.OrderByDescending(c => c.NomeDoProduto);
                    return lista;
                }
                else if (ordem.ToLower() == "asc")
                {
                    lista = lista.OrderBy(c => c.NomeDoProduto);
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


//vou usar depois no filtro 
//public class ProdutosRepository
//{
//private readonly IConfiguration configuration; // inicialização

//public ProdutosRepository(IConfiguration configuration)
//{
//    this.configuration = configuration;
//}

//public async Task<Produto> GetByIdAsync(int id) // usando o parametro id
//{
//    var sql = "SELECT * FROM Produtos WHERE ProdutoID = @Id"; // preciso saber se é id só

//    using var connection = new SqlConnection(configuration.GetConnectionString("CategoriaConnection")); //abertura da conexão como estamos usando sqlserver a classe é sqlconnection
//    connection.Open(); // essa connectionstring vem do json do configuration(confirmar a minha)
//                       // até aqui está tudo ok. pq estamos usando a sql connection
//                       // agora vamos usar o query...metodo extensor do sqlmapper que vem do dapper F12
//                       //estou falando p dapper executar essa sql usando a models e trazendo por id uma entidade
//    var result = await connection.QuerySingleOrDefaultAsync<Produto>(sql, new { Id = id });

//    return result; // finalizando ele mapeia através da models e traz o resultado
//}

//public async Task<IReadOnlyList<Produto>> GetAllAsync() // vai trazer todos
//{
//    var sql = "SELECT * FROM Produtos";
//    using var connection = new SqlConnection(configuration.GetConnectionString("CategoriaConnection")); //abertura da conexão como estamos usando sqlserver a classe é sqlconnection
//    connection.Open(); // confirmar minha connectionstring
//                       //instanciando a sql connection e abrindo a conexao
//                       // aqui sem o where e usando o queryasync q traz um enumerable, a lista/coleção
//                       //não passamos parametro, logo o resultado é uma lista
//    var result = await connection.QueryAsync<Produto>(sql);
//    return result.ToList();
//    //
//}

//public async Task<Produto> AddAsync(Produto entity) //vamos adicionar uma nova entidade
//{
//    entity.DataCriacaoDoProduto = DateTime.Now; //uso a minha data?)
//    var sql = "INSERT INTO Produtos(NomeDoProduto, DescricaoDoProduto, PesoDoProduto, AlturaDoProduto, LarguraDoProduto,ComprimentoDoProduto, ValorDoProduto, QuantidadeEmEstoqueDoProduto, CentroDeDistribuicao, StatusDoProduto, DataCriacaoDoProduto) " +
//    "Values (@nomeDoProduto, @descricaoDoProduto, @pesoDoProduto, @alturaDoProduto, @larguraDoProduto, @comprimentoDoProduto, @valorDoProduto, @quantidadeEmEstoqueDoProduto, @centroDeDistribuicao, @statusDoProduto, @dataCriacaoDoProduto);" +
//    "SELECT CAST(SCOP_IDENTITY() as int)";
//    // select into insere os valores q passamos
//    //select cast.. é para inserir o id que ele criou 
//    using var connection = new SqlConnection(configuration.GetConnectionString("CategoriaConnection")); //abertura da conexão como estamos usando sqlserver a classe é sqlconnection
//    connection.Open();

//    entity.ProdutoId = await connection.QuerySingleAsync<int>(sql, entity);
//    //aqui o querysingleasync é para não pegar toda a entidade, só o id /19.39
//    return entity;
//}

//public async Task<int> DeleteAsync(int id)
//{
//    var sql = "DELETE FROM Produtos WHERE ProdutoID = @Id"; // delete um produto onde o produto é = ao id
//    using var connection = new SqlConnection(configuration.GetConnectionString("CategoriaConnection")); //abertura da conexão como estamos usando sqlserver a classe é sqlconnection
//    connection.Open();
//    var result = await connection.ExecuteAsync(sql, new { id });// execute a query mas não precisa de linhas afetadas, mas sim o que foi deletado
//    return result;
//}

//public async Task<int> UpdateAsync(Produto entity)
//{
//    var sql = "UPDATE Produtos SET NomeDoProduto = @nomeDoProduto, DescricaoDoProduto = @descricaoDoProduto, PesoDoProduto = @pesoDoProduto, AlturaDoProduto = @alturaDoProduto, LarguraDoProduto = @larguraDoProduto, ComprimentoDoProduto = @comprimentoDoProduto, ValorDoProduto = @valorDoProduto, QuantidadeEmEstoqueDoProduto = @quantidadeEmEstoqueDoProduto, CentroDeDistribuicao = @centroDeDistribuicao, StatusDoProduto = @statusDoProduto, DataCriacaoDoProduto= @dataCriacaoDoProduto WHERE ProdutoId = @ProdutoId";
//    using var connection = new SqlConnection(configuration.GetConnectionString("CategoriaConnection")); //abertura da conexão como estamos usando sqlserver a classe é sqlconnection
//    connection.Open();

//    var result = await connection.ExecuteAsync(sql, entity);
//    return result;

//}
//}












/*
 * QuerySingleOrDefaultAsync : retorna apenas uma entidade
 * QueryAsync : retorna um enumerable/lista/--coleção
 * só query  = uma lista tbm
 * 
 */

/*card cadastrar produtos
    Nome do produto (obrigatório - 128 caracteres - alfanumérico)
Descrição do produto(obrigatório - 512 caracteres - alfanumérico)
Peso(obrigatório - decimal 0, 00)
Altura(obrigatório - decimal 0, 00)
Largura(obrigatório - decimal 0, 00)
Comprimento(obrigatório - decimal 0, 00)
Valor(obrigatório - decimal 0, 00)
Quantidade em estoque (obrigatório - inteiro)
Centro de distribuição (obrigatório)
Categoria / subcategoria(obrigatório)
Critérios de aceite

Todo produto cadastrado deve ser registrado com o status de ativo.
Todo produto cadastrado deve ser registrado com a data e hora de criação.
Não é possível cadastrar o produto em uma categoria e subcategoria inativa.
Uma vez associado um produto a uma subcategoria ativa, não é possível inativar essa subcategoria.
Criar uma camada de serviço para alocar as regras de negócio.*/
//****organização do código..

/*editar
    Nome do produto(128 caracteres - alfanumérico)
Descrição do produto(512 caracteres - alfanumérico)
Peso(decimal 0, 00)
Altura(decimal 0, 00)
Largura(decimal 0, 00)
Comprimento(decimal 0, 00)
Valor(decimal 0, 00)
Quantidade em estoque (inteiro)
Centro de distribuição
Categoria/subcategoria
Status

Critérios de aceite
Um produto pode ser alterado para ativo ou inativo.
Todo produto alterado deve ser registrado com a data e hora de modificação.
Criar uma camada de serviço para alocar as regras de negócio.*/

/*Campos de pesquisa:

Nome da do produto (128 caracteres - alfanumérico - mínimo 3 caracteres)
Peso(decimal 0, 00)
Altura(decimal 0, 00)
Largura(decimal 0, 00)
Comprimento(decimal 0, 00)
Valor(decimal 0, 00)
Quantidade em estoque (inteiro)
Centro de distribuição (um ou mais)
Categoria / subcategoria(uma ou mais)
Status(Todos, Ativos, Inativos)
Campos de visualização:

Id de registro
Nome do produto
Valor
Quantidade em estoque
Centro de distribuição
Categoria/subcategoria
Status
Data de criação
Data de modificação
Critérios de aceite

Exibir paginação configurável (opção de determinar quantos registros exibir por página)
A ordenação deverá ser crescente por nome do produto, Categoria/subcategoria ou Centro de distribuição (possibilidade de realizar uma ordenação decrescente)
Criar uma camada de serviço para alocar as regras de negócio.
Utilizar o framework Dapper para realizar as consultas no banco de dados, utilizando queries nativas.*/

//*****mentoria 10.02- solid - services - MulticastNotSupportedException ultimo dapper
//****   dao = repository

/*solid: principios
 * code smells - cheiro de problema - temos que ter qualidade no código.... código repetido não
 * design patters - padrões e principios de outros devs
 * como repetimos muitas vezes o buscar por id e o mostrar/buscar categorias.
 * cria um metodo pra isso
 * private Inumerable <Categoria> BuscarCategorias()
 * {return _context.Categorias.ToList();}
 * 
 * e outro por busca por id
 * leilaodao data acess object
 * refatorar ele usa entity e eu o dapper?
 * traz o context
 * e o construtor q inicializa
 * extrair as operações para uma classe (Dao) e depois altera e chama ela nos metodos
 * usamos coesaõ, harmonia. 
 * metodos e classes devem ter apenas uma responsabilidade
 * classe coesa com apenas 1 razão. responde 1 agente
 * s = responsablidade unica***
 * Encapsular o appdbcontex
 * 
 * 
  */