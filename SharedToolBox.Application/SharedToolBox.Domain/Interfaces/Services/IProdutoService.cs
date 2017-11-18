using System.Collections.Generic;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Domain.Interfaces.Services
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
