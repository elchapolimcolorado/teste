using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class SubtipoAppService : AppServiceBase<Subtipo>, ISubtipoAppService
    {
        private readonly ISubtipoService _service;

        public SubtipoAppService(ISubtipoService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Subtipo> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}