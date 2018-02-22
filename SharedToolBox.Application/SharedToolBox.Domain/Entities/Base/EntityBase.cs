using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedToolBox.Domain.Entities
{
    public partial class EntityBase
    {
        public bool Ativo { get; set; }
        public DateTime DataManipulacao { get; set; }
        public string LoginManipulacao { get; set; }
    }
}
