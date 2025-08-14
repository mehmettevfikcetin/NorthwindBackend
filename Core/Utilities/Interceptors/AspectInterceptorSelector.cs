using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector   //castle dynamic proxy kütüphanesinden gelen IInterceptorSelector arayüzünü implement ediyoruz.
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {   
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            classAttributes.AddRange(methodAttributes);
            classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
//      Bu yapı ile validation loglama gibi cross cuting concerns'leri merkezi bir yerden yönetebiliriz.
//1.	Sınıf düzeyinde ve metot düzeyinde tanımlanmış olan özel nitelikleri (attributes) toplar
//2.    Bu nitelikleri öncelik sırasına göre sıralar
//3.	İlgili metot çağrıldığında hangi aspect'lerin (kesişen ilgi alanlarının) hangi sırayla çalışacağını belirler