using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    //bir methodu nasıl yorumlayacagını anlatılan sayfa
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation ınvocation) { }
        protected virtual void OnAfter(IInvocation ınvocation) { }
        protected virtual void OnException(IInvocation ınvocation,System.Exception e) { }
        protected virtual void OnSuccess(IInvocation ınvocation) { }

        public override void Intercept(IInvocation invocation) // bu benim kodu nasıl yorumlayacagımı anlatan yer 
        {

            //methodun nasıl ele alınacaagnı yazdıgımız kısım
            var isSuccess = true;
            OnBefore(invocation);

            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
