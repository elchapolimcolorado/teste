using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Domain.Services
{
    public class FerramentaService : ServiceBase<Ferramenta>, IFerramentaService
    {
        //private readonly IFerramentaRepository _repository;

        //public FerramentaService(IFerramentaService repository)
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

        public FerramentaService(IRepositoryBase<Ferramenta> repository) : base(repository)
        {
        }
    }
}
