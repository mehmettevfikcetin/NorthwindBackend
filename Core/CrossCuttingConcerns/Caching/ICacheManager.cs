using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Tüm cache yöneticilerinin uyması gereken kuralları (metot imzalarını) tanımlar.




namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {   
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object data, int duration);
        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern); 
    }
}
