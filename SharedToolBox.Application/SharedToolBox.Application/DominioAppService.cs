using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class DominioAppService : AppServiceBase<Dominio>, IDominioAppService
    {
        private readonly IDominioService _service;

        public DominioAppService(IDominioService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Dominio> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}