using System.Collections.Generic;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;

namespace SharedToolBox.Infra.Data.Repositories
{
    public class FerramentaRepository : RepositoryBase<Ferramenta>, IFerramentaRepository
    {
        public IEnumerable<Ferramenta> BuscarPorDescricao(string descricao)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ferramenta> BuscarPorNome(string nome)
        {
            throw new System.NotImplementedException();
        }
    }
}