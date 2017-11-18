
using System.Collections.Generic;
using System.Linq;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;

namespace SharedToolBox.Infra.Data.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
