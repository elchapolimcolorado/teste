using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Newtonsoft.Json;

namespace SoftFramework.Web.Helpers
{
    public class UserPrincipal : IPrincipal
    {
        private IIdentity _identity;

        [JsonIgnore]
        public IIdentity Identity
        {
            get { return _identity ?? (_identity = new GenericIdentity(Name)); }
        }

        public string Name { get; set; }
        public int Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }

        /// <summary>
        /// Get's a JSON serialized string of a SimplePrincipal object
        /// </summary>
        public static string GetCookieUserData(UserPrincipal principal)
        {
            return JsonConvert.SerializeObject(principal);
        }

        /// <summary>
        /// Creates a SimplePrincipal object using a JSON string from the asp.net auth cookie
        /// </summary>
        public static UserPrincipal CreatePrincipalFromCookieData(string userData)
        {
            return JsonConvert.DeserializeObject<UserPrincipal>(userData);
        }
    }
}