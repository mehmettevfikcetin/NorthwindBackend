using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


//Core modüllerinin uyması gereken kuralları tanımlar, modüllerin nasıl yapılandırılacağını belirtir.
// Bu arayüz, modüllerin bağımlılıklarını yüklemek için IServiceCollection kullanır.

namespace Core.Utilities.IoC
{
    public interface ICoreModule
    {
       public void Load(IServiceCollection serviceCollection);
    }
}
