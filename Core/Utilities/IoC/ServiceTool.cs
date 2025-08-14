using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //ServiceTool sınıfı, uygulama genelinde servis sağlayıcısına (DI container) kolay erişim sağlamak için kullanılır. Create metodu ile servis sağlayıcıyı oluşturur ve statik olarak saklar. Bu sayede, servisleri doğrudan çözümlemek mümkün olur
    // //ServiceTool, IServiceProvider ve IServiceCollection arayüzlerini kullanarak uygulamanın bağımlılıklarını yönetir.


    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
