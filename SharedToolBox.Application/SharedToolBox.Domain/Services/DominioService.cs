using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Domain.Services
{
    public class DominioService : ServiceBase<Dominio>, IDominioService
    {
        //private readonly IDominioRepository _repository;

        //public DominioService(IDominioService repository)
        //    : base(repository)
        //{
        //    _repository = repository;
        //}





        //public IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> clientes)
        //{
        //    return clientes.Where(c => c.ClienteEspecial(c));
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoRepository.BuscarPorNome(nome);
        //}

        public DominioService(IRepositoryBase<Dominio> repository) : base(repository)
        {
        }
    }
}
