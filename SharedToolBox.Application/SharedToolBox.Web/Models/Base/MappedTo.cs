using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoftFramework.Web.Models.Base
{
    public abstract class MappedTo<T>
    {
        protected MappedTo()
        {
            //Mapper.CreateMap(GetType(), typeof(T));
        }

        public T Convert()
        {
            return (T)Mapper.Map(this, this.GetType(), typeof(T));
        }
    }
}