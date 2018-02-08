using SharedToolBox.Domain.Entities;
using System.Collections.Generic;

namespace SharedToolBox.Domain.Interfaces.Repositories
{
    public interface IFerramentaRepository : IRepositoryBase<Ferramenta>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
        IEnumerable<Produto> BuscarPorDescricao(string descricao);
    }
}

