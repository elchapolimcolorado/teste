using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Domain.Services
{
    public class SubtipoService : ServiceBase<Subtipo>, ISubtipoService
    {
        //private readonly ISubtipoRepository _repository;

        //public SubtipoService(ISubtipoService repository)
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

        public SubtipoService(IRepositoryBase<Subtipo> repository) : base(repository)
        {
        }
    }
}
