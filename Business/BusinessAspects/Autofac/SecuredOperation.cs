using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



//bu sayfa , yetkilendirme işlemlerini gerçekleştiren bir aspect sınıfıdır.
// Bu sınıf, bir metot çağrılmadan önce kullanıcının rollerini kontrol eder.
// Eğer kullanıcının rolü belirtilen rollerle eşleşmiyorsa, yetkilendirme reddedilir ve bir istisna fırlatılır.
namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation:MethodInterception
    {
        private string[] _roles;
        IHttpContextAccessor _httpContextAccessor;
        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            // Bu sınıf, HTTP isteklerini işlemek için kullanılan IHttpContextAccessor servisini alır.
        }
        protected override void OnBefore(IInvocation ınvocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
                throw new Exception(Messages.AuthorizationDenied);
            }
        }
    }
}
