using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharedToolBox.Domain.Entities
{
    public enum TipoOcorrencia
    {
        Problema = 1,
        Perda = 2,
        Dano = 3,
        Reclamação = 4,
        Sugestão = 5,
        Elogio = 6,
        Outros = 7
    }
}