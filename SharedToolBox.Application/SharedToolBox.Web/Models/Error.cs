using System;

namespace SharedToolBox.Web.Models
{
    public class Error
    {
        public Error(Exception ex)
        {
            ErrorEx = ex;
        }

        public Exception ErrorEx { get; set; }
    }
}