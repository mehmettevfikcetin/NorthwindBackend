# NorthwindBackend
Bu proje, .NET Core Web API kullanılarak geliştirilmiş, katmanlı mimari (Layered Architecture) prensiplerine uygun bir Northwind Backend uygulamasıdır.
Proje, Clean Architecture yaklaşımına yakın bir yapıdadır ve bağımlılıkları yönetmek için Autofac, loglama için log4net, AOP (Aspect Oriented Programming) gibi teknikler kullanılmıştır.

📂 Proje Yapısı
Solution 'NorthwindBackend'
│
├── Business
│   ├── Abstract              # Service Interface tanımları
│   ├── BusinessAspects       # Yetkilendirme, güvenlik aspectleri
│   ├── Concrete              # Service implementasyonları
│   ├── Constants             # Sabit mesajlar ve değerler
│   ├── DependencyResolver    # Business katmanı bağımlılık yönetimi
│   ├── ValidationRules       # FluentValidation ile doğrulama kuralları
│
├── Core
│   ├── AspectMessages        # AOP mesajları
│   ├── Autofac               # Autofac konfigürasyonu
│   ├── CrossCuttingConcerns  # Loglama, cache, transaction vb.
│   ├── DataAccess            # Repository pattern altyapısı
│   ├── DependencyResolver    # Core bağımlılık yönetimi
│   ├── Entities              # Core'a özel entity tanımları
│   ├── Extensions            # Extension methodlar
│   ├── Utilities             # Yardımcı sınıflar
│
├── DataAccess
│   ├── Abstract              # Repository interface'leri
│   ├── Concrete              # EF Core repository implementasyonları
│
├── Entities
│   ├── Abstract              # Base entity tanımları
│   ├── Concrete              # Projeye ait entity'ler
│   ├── Dtos                  # Veri transfer objeleri (DTO)
│
└── WebAPI
    ├── Controllers           # API endpoint'leri
    ├── Pages                 # Swagger veya dokümantasyon sayfaları
    ├── wwwroot               # Statik dosyalar
    ├── appsettings.json      # Konfigürasyon dosyası
    ├── log4net.config        # Loglama yapılandırması
    ├── Program.cs            # Uygulama giriş noktası
    ├── Startup.cs            # Servis ve middleware konfigürasyonu

🚀 Özellikler

Katmanlı Mimari ile modüler yapı

AOP (Aspect Oriented Programming) ile loglama, yetkilendirme, validation

Repository Pattern ve Dependency Injection

Entity Framework Core ile veritabanı işlemleri

log4net ile gelişmiş loglama

Autofac ile bağımlılık yönetimi

FluentValidation ile model doğrulama

🛠 Kullanılan Teknolojiler

.NET 5/6+

Entity Framework Core

Autofac

log4net

FluentValidation

Swagger (opsiyonel olarak API testleri için)

📦 Kurulum ve Çalıştırma

Projeyi klonlayın:

git clone https://github.com/kullaniciadi/NorthwindBackend.git


Veritabanı bağlantı ayarlarını appsettings.json dosyasından yapın:

"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=Northwind;Trusted_Connection=True;"
}


Terminalden migration işlemini gerçekleştirin:

dotnet ef database update


Uygulamayı çalıştırın:

dotnet run --project WebAPI


Tarayıcıdan API dokümantasyonuna erişin:

https://localhost:5001/swagger

📄 Lisans

Bu proje MIT lisansı ile lisanslanmıştır.
