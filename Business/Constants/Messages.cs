using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün başarı ile eklendi";
        public static string ProductDeleted = "Ürün başarı ile silindi";
        public static string ProductUpdated = "Ürün başarı ile güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError= "Girdiğiniz şifre hatalı ";
        public static string SuccusfullLogin = "Şifre doğru, giriş başarılı.";
        public static string UserAlreadyExists = "Bu kullanıcı daha önce kayıt olmuş.";
        public static string UserRegistered = "Giriş başarılı";
        public static string AccessTokenCreated = "Access token başarı ile oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok.";

    }
}
