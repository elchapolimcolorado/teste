using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;

namespace SoftFramework.Web.Helpers
{
    public class StringEnum 
    {
        #region Instance implementation

        /// <summary>
        /// Private Type _enumType.
        /// </summary>
        private Type _enumType;

        /// <summary>
        /// Construtor da classe StringEnum.
        /// </summary>
        /// <param name="enumType">Tipo do Enumerador.</param>
        public StringEnum(Type enumType)
        {
            if (enumType == null)
            {
                throw new ArgumentNullException("enumType", "Supplied type must be an Enum. Value was null.");
            }

            if (!enumType.IsEnum)
            {
                throw new ArgumentException(String.Format("Supplied type must be an Enum.  Type was {0}", enumType.ToString()));
            }

            _enumType = enumType;
        }

        /// <summary>
        /// Recupera o tipo do enumerador.
        /// </summary>
        /// <value>Public Type EnumType.</value>
        public Type EnumType
        {
            get { return _enumType; }
        }

        #endregion

        #region Static implementation

        public static string GetDescription(System.Enum enumerador)
        {
            if (enumerador == null)
            {
                return string.Empty;
            }

            var campo = enumerador.GetType().GetField(enumerador.ToString());
            var atributos = campo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (atributos.Length > 0)
            {
                DescriptionAttribute atributo = (DescriptionAttribute)atributos[0];
                return atributo.Description;
            }

            return string.Empty;
        }

        #endregion
    }
}
