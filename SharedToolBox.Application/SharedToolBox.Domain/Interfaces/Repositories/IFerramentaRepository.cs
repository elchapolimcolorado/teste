using SharedToolBox.Domain.Entities;
using System.Collections.Generic;

namespace SharedToolBox.Domain.Interfaces.Repositories
{
    public interface IFerramentaRepository : IRepositoryBase<Ferramenta>
    {
        IEnumerable<Ferramenta> BuscarPorNome(string nome);
        IEnumerable<Ferramenta> BuscarPorDescricao(string descricao);

    }
}

