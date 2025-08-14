using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;



//Servis koleksiyonuna (DI container) yeni servisler eklemek için yardımcı uzatma metotları içerir.
// Bu uzantı metotları, modüllerin bağımlılıklarını yüklemek için IServiceCollection kullanır ve ServiceTool aracılığıyla servis sağlayıcısını oluşturur.


namespace Core.Extensions
{
    public static class ServiceCollectionExtansions
    {
        public static IServiceCollection AddDependecyResolvers(this IServiceCollection services, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                module.Load(services);
            }
            return ServiceTool.Create(services);    
        }        
    }
}
