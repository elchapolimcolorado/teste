using System;

namespace SoftFramework.Web.Models.MercadoLivre
{
    public class NotificationCallbackModel
    {
        public string resource { get; set; }
        public int user_id { get; set; }
        public string topic { get; set; }
        public DateTime received { get; set; }
        public DateTime sent { get; set; }

        //"resource": "/items/MLB139876",
        //"user_id": 1234,
        //"topic": "items",
        //"received": "2011-10-19T16:38:34.425Z",
        //"sent" : "2011-10-19T16:40:34.425Z",
    }
}