
using System.Collections.Generic;
using SharedToolBox.Domain.Entities;

namespace SharedToolBox.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
