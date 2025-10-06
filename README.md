# EasyHR.DemoFormApp

EasyHR.DemoFormApp, form yönetimi için geliştirilmiş bir ASP.NET Core uygulamasıdır. Proje, modern yazılım geliştirme prensipleri ve katmanlı mimari kullanılarak oluşturulmuştur.

## 📖 Açıklama

Bu uygulama, kullanıcı bilgilerini (Email, Ad, Soyad, Doğum Tarihi) toplayabilen, yönetebilen ve saklayabilen bir form yönetim sistemidir. API ve Web UI olmak üzere iki ayrı projeden oluşur ve modern web teknolojileri kullanılarak geliştirilmiştir.

## 🏗️ Proje Yapısı

```
EasyHR.DemoFormApp/
│
├── EasyHR.DemoFormApp.API/              # RESTful API katmanı
├── EasyHR.DemoFormApp.WebUI/            # Razor Pages web arayüzü
├── EasyHR.DemoFormApp.Business/         # İş mantığı katmanı
├── EasyHR.DemoFormApp.DataAccess/       # Entity Framework Core veri erişim katmanı
└── EasyHR.DemoFormApp.Entities/         # Veri modelleri ve DTO'lar
```

## ✨ Özellikler

- ✅ Form oluşturma ve yönetimi
- ✅ Kullanıcı bilgileri (Email, Ad, Soyad, Doğum Tarihi) toplama
- ✅ RESTful API desteği
- ✅ Swagger/OpenAPI dokümantasyonu
- ✅ Razor Pages ile modern web arayüzü
- ✅ Entity Framework Core ile veritabanı yönetimi
- ✅ Soft delete özelliği
- ✅ Zaman damgası yönetimi (CreatedAt, UpdatedAt, DeletedAt)

## 🚀 Teknolojiler

- **Framework**: ASP.NET Core
- **Dil**: C#
- **Veritabanı**: Microsoft SQL Server LocalDB
- **ORM**: Entity Framework Core
- **API Dokümantasyonu**: Swagger/OpenAPI
- **Frontend**: Razor Pages, HTML, CSS, JavaScript

## 📋 Gereksinimler

- .NET SDK (6.0 veya üzeri)
- Visual Studio 2022 (önerilen) veya Visual Studio Code
- Microsoft SQL Server LocalDB (Visual Studio ile birlikte gelir)

## ⚙️ Kurulum ve Çalıştırma

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/BeratARPA/EasyHR.DemoFormApp.git
cd EasyHR.DemoFormApp
```

### 2. Veritabanını Oluşturun

Proje **Microsoft SQL Server LocalDB** kullanmaktadır. Veritabanı adı: `EasyHRDemo`

Entity Framework Core migrations ile veritabanını oluşturmak için:

**Package Manager Console'da (Visual Studio):**
```powershell
Update-Database
```

**veya Terminal'de:**
```bash
dotnet ef database update --project EasyHR.DemoFormApp.DataAccess --startup-project EasyHR.DemoFormApp.API
```

> **Not**: Eğer `dotnet ef` komutu bulunamazsa, önce Entity Framework Core CLI araçlarını yükleyin:
```bash
dotnet tool install --global dotnet-ef
```

### 3. API ve Web UI'ı Aynı Anda Çalıştırın

#### Seçenek 1: Visual Studio ile (Önerilen)

1. `EasyHR.DemoFormApp.sln` dosyasını Visual Studio ile açın
2. Solution Explorer'da solution'a **sağ tıklayın**
3. **Properties** > **Startup Project** seçeneğini açın
4. **Multiple startup projects** seçeneğini işaretleyin
5. Hem `EasyHR.DemoFormApp.API` hem de `EasyHR.DemoFormApp.WebUI` projelerini **Start** olarak ayarlayın
6. **F5** tuşuna basarak veya **Start** butonuna tıklayarak her iki projeyi birden çalıştırın

#### Seçenek 2: Terminal ile

İki ayrı terminal penceresi açarak projeleri çalıştırabilirsiniz:

**Terminal 1 - API:**
```bash
cd EasyHR.DemoFormApp.API
dotnet run
```

**Terminal 2 - Web UI:**
```bash
cd EasyHR.DemoFormApp.WebUI
dotnet run
```

> **Önemli**: Web UI, API'nin `http://localhost:5027` adresinde çalıştığını varsayar. Eğer API farklı bir portta çalışıyorsa, `EasyHR.DemoFormApp.WebUI/appsettings.json` dosyasındaki `ApiSettings:BaseUrl` değerini güncelleyin.

## 🌐 Uygulamaya Erişim

Projeler çalıştıktan sonra:

- **API (Swagger UI)**: `https://localhost:<port>/swagger` veya `http://localhost:5027/swagger`
- **Web UI**: `https://localhost:<port>` (terminal çıktısında görüntülenir)

### Örnek API Endpoint'leri

```
GET    /api/Forms          # Tüm formları listele
GET    /api/Forms/{id}     # Belirli bir formu getir
POST   /api/Forms          # Yeni form oluştur
PUT    /api/Forms/{id}     # Form güncelle
DELETE /api/Forms/{id}     # Form sil (soft delete)
```

### Form Entity Yapısı

```json
{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "email": "ornek@email.com",
    "firstName": "Ahmet",
    "lastName": "Yılmaz",
    "birthDate": "1990-01-15T00:00:00",
    "createdAt": "2024-01-01T10:00:00",
    "updatedAt": "2024-01-01T10:00:00",
    "isDeleted": false,
    "deletedAt": null
}
```

## 🗄️ Veritabanı Bağlantısı

Bağlantı stringi `EasyHR.DemoFormApp.API/appsettings.json` dosyasında tanımlıdır:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EasyHRDemo;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

LocalDB yerine farklı bir SQL Server kullanmak isterseniz bu connection string'i değiştirebilirsiniz.
