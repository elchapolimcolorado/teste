using System.Collections.Generic;
using SharedToolBox.Application.Interface;
using SharedToolBox.Domain.Entities;
using SharedToolBox.Domain.Interfaces.Services;

namespace SharedToolBox.Application
{
    public class MarcaAppService : AppServiceBase<Marca>, IMarcaAppService
    {
        private readonly IMarcaService _service;

        public MarcaAppService(IMarcaService service)
            : base(service)
        {
            _service = service;
        }

        //public IEnumerable<Marca> ObterClientesEspeciais()
        //{
        //    return _service.ObterClientesEspeciais(_service.GetAll());
        //}

        //public IEnumerable<Produto> BuscarPorNome(string nome)
        //{
        //    return _produtoService.BuscarPorNome(nome);
        //}
    }
}