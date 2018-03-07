using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class CaracteristicaAppService : AppServiceBase<Caracteristica>, ICaracteristicaAppService
    {
        private readonly ICaracteristicaService _service;

        public CaracteristicaAppService(ICaracteristicaService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Caracteristica> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}