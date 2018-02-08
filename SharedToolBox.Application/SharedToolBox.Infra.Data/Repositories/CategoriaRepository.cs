using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;

namespace SharedToolBox.Infra.Data.Repositories
{
    public class CategoriaRepository : RepositoryBase<Categoria>, ICategoriaRepository
    {
        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return Db.Produtos.Where(p => p.Nome == nome);
        //}
}
}