using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{

    //bu sayfa ClaimsPrincipal nesnesine ek özellikler ekler
    
    public static class ClaimsPrincipalExtensions
    {
        // bu metot ClaimsPrincipal nesnesinden belirli bir claim tipine ait tüm değerleri liste olarak döner
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
           var result = claimsPrincipal?.FindAll(claimType)?.Select(c => c.Value).ToList();
            return result;
        }

        // ClaimsPrincipal nesnesinden rol claim'lerini liste olarak döner
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(claimType:ClaimTypes.Role);
        }
    }
}
