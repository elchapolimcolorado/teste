using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;

namespace SharedToolBox.Infra.Data.Repositories
{
    public class DominioRepository : RepositoryBase<Dominio>, IDominioRepository
    {
        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return Db.Produtos.Where(p => p.Nome == nome);
        //}
    }
}