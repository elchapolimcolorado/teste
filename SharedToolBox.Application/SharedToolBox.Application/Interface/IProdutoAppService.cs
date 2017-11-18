
using System.Collections.Generic;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Application.Interface
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
