using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Core.AspectsMessages;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

//Bu sınıf, metotlara gelen verilerin (nesnelerin) kurallara uygun olup olmadığını, metot çalışmadan önce otomatik kontrol eder. Hatalı durumlarda metodu durdurup hata fırlatarak uygulamanın güvenilirliğini artırır.

//Özetle: "Kontrolü elden bırakma, kuralları ben hallederim!" diyen bir bekçi gibi çalışır. 
namespace Core.Aspects.Validation
{
    public class ValidationAspects : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspects(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }        
    }
}
