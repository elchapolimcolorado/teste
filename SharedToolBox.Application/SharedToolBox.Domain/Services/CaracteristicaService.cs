using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Repositories;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Domain.Services
{
    public class CaracteristicaService : ServiceBase<Caracteristica>, ICaracteristicaService
    {
        //private readonly ICaracteristicaRepository _repository;

        //public CaracteristicaService(ICaracteristicaService repository)
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

        public CaracteristicaService(IRepositoryBase<Caracteristica> repository) : base(repository)
        {
        }
    }
}
