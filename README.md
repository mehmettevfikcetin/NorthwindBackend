# NorthwindBackend
# 🏗️ Northwind Backend

Bu proje, **.NET Core Web API** kullanılarak geliştirilmiş, **katmanlı mimari (Layered Architecture)** prensiplerine uygun bir Northwind Backend uygulamasıdır.

Proje, **Clean Architecture** yaklaşımına yakın bir yapıdadır ve bağımlılıkları yönetmek için **Autofac**, loglama için **log4net**, **AOP (Aspect Oriented Programming)** gibi teknikler kullanılmıştır.

## 📂 Proje Yapısı

```
Solution 'NorthwindBackend'
│
├── Business
│   ├── Abstract              # Service Interface tanımları
│   ├── BusinessAspects       # Yetkilendirme, güvenlik aspectleri
│   ├── Concrete              # Service implementasyonları
│   ├── Constants             # Sabit mesajlar ve değerler
│   ├── DependencyResolver    # Business katmanı bağımlılık yönetimi
│   └── ValidationRules       # FluentValidation ile doğrulama kuralları
│
├── Core
│   ├── AspectMessages        # AOP mesajları
│   ├── Autofac               # Autofac konfigürasyonu
│   ├── CrossCuttingConcerns  # Loglama, cache, transaction vb.
│   ├── DataAccess            # Repository pattern altyapısı
│   ├── DependencyResolver    # Core bağımlılık yönetimi
│   ├── Entities              # Core'a özel entity tanımları
│   ├── Extensions            # Extension methodlar
│   └── Utilities             # Yardımcı sınıflar
│
├── DataAccess
│   ├── Abstract              # Repository interface'leri
│   └── Concrete              # EF Core repository implementasyonları
│
├── Entities
│   ├── Abstract              # Base entity tanımları
│   ├── Concrete              # Projeye ait entity'ler
│   └── Dtos                  # Veri transfer objeleri (DTO)
│
└── WebAPI
    ├── Controllers           # API endpoint'leri
    ├── Pages                 # Swagger veya dokümantasyon sayfaları
    ├── wwwroot               # Statik dosyalar
    ├── appsettings.json      # Konfigürasyon dosyası
    ├── log4net.config        # Loglama yapılandırması
    ├── Program.cs            # Uygulama giriş noktası
    └── Startup.cs            # Servis ve middleware konfigürasyonu
```

## 🚀 Özellikler

- **Katmanlı Mimari** ile modüler yapı
- **AOP (Aspect Oriented Programming)** ile loglama, yetkilendirme, validation
- **Repository Pattern** ve **Dependency Injection**
- **Entity Framework Core** ile veritabanı işlemleri
- **log4net** ile gelişmiş loglama
- **Autofac** ile bağımlılık yönetimi
- **FluentValidation** ile model doğrulama

## 🛠️ Kullanılan Teknolojiler

- **.NET 8**
- **Entity Framework Core**
- **Autofac**
- **log4net**
- **FluentValidation**
- **Swagger** (opsiyonel olarak API testleri için)

## 📦 Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın
```bash
git clone https://github.com/kullaniciadi/NorthwindBackend.git
cd NorthwindBackend
```

### 2. Veritabanı Bağlantısını Yapılandırın
`appsettings.json` dosyasında veritabanı bağlantı ayarlarını düzenleyin:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=Northwind;Trusted_Connection=True;"
  }
}
```

### 3. Veritabanını Güncelleyin
```bash
dotnet ef database update
```

### 4. Uygulamayı Çalıştırın
```bash
dotnet run --project WebAPI
```

### 5. API Dokümantasyonuna Erişin
Tarayıcıdan şu adrese gidin:
```
https://localhost:5001/swagger
```

## 📋 API Kullanımı

Uygulama başlatıldıktan sonra Swagger UI üzerinden tüm endpoint'leri test edebilirsiniz. Ana endpoint'ler şunlardır:

- `/api/products` - Ürün işlemleri
- `/api/categories` - Kategori işlemleri
- `/api/customers` - Müşteri işlemleri
- `/api/orders` - Sipariş işlemleri

## 🏗️ Mimari Detayları

### Katmanlar
- **WebAPI**: Presentation katmanı (Controllers)
- **Business**: İş kuralları ve servis implementasyonları
- **DataAccess**: Veri erişim katmanı (Repository Pattern)
- **Entities**: Veri modelleri ve DTO'lar
- **Core**: Ortak kullanılan altyapı bileşenleri

### Öne Çıkan Özellikler
- **AOP**: Cross-cutting concerns (loglama, yetkilendirme) için
- **Dependency Injection**: Autofac container kullanımı
- **Validation**: FluentValidation ile güçlü doğrulama
- **Logging**: log4net ile yapılandırılabilir loglama

## 🤝 Katkıda Bulunma

1. Bu repository'yi fork edin
2. Feature branch'i oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📄 Lisans

Bu proje **MIT Lisansı** ile lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakınız.

## 📞 İletişim

Proje hakkında sorularınız için:
- GitHub Issues kullanabilirsiniz
- Email: [your-email@example.com]

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!
https://localhost:5001/swagger

📄 Lisans

Bu proje MIT lisansı ile lisanslanmıştır.
