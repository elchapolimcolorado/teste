using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Domain.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        //private readonly IMarcaRepository _repository;

        //public MarcaService(IMarcaService repository)
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

        public MarcaService(IRepositoryBase<Marca> repository) : base(repository)
        {
        }
    }
}
