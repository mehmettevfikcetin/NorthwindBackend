using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Results;
using Entities.Dtos;

//bu sayfa Business katmanında yer alır ve AuthService için gerekli olan arayüzü tanımlar.
// Bu arayüz, kullanıcı kayıt, giriş, kullanıcı varlığını kontrol etme ve erişim token'ı oluşturma işlemlerini içerir.

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
