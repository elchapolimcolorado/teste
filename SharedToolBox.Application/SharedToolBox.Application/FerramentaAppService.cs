using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class FerramentaAppService : AppServiceBase<Ferramenta>, IFerramentaAppService
    {
        private readonly IFerramentaService _service;

        public FerramentaAppService(IFerramentaService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Ferramenta> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}