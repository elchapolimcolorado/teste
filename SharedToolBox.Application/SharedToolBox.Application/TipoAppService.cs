using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class TipoAppService : AppServiceBase<Tipo>, ITipoAppService
    {
        private readonly ITipoService _service;

        public TipoAppService(ITipoService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Tipo> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}