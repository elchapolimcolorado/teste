using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using SoftFramework.Web.Models.Resource;

namespace SoftFramework.Web.Models.Resources
{
    public class PortalResource : ResourceBase
    {
        #region Grau Instrução

        protected string EnsinoFundamental { get { return "Ensino Fundamental"; } }
        protected string EnsinoMedio { get { return "Ensino Médio"; } }
        protected string PosGraduacao { get { return "Pós Graduação"; } }

        #endregion

        #region Estado Civil

        protected string Solteiro { get { return "Solteiro"; } }
        protected string Casado { get { return "Casado"; } }
        protected string Divorciado { get { return "Divorciado"; } }
        protected string Viuvo { get { return "Viúvo"; } }

        #endregion
    }
}