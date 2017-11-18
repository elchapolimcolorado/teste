using System.Collections.Generic;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
