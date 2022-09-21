# Patika & PayCore .NET/.NET Core Bootcamp Graduation Project
Projede .NET Core 6, NHibernate, PostgreSQL ve Hangfire kullanılmıştır. Proje 7 katmandan oluşmaktadır.

### ✨ SinemYoruc-Project Katmanı
Controllerlar ve StartupExtensionlar yönetilmektedir.

### ✨ SinemYoruc-Project.Base Katmanı
Projede kullanılacak genel sınıflar yönetilmektedir.

### ✨ SinemYoruc-Project.Data Katmanı
Kullanılacak modeller ve mapping işlemleri yönetilmektedir.

### ✨ SinemYoruc-Project.Dto Katmanı
Mapping için gerekli sınıflar yönetilmektedir.

### ✨ SinemYoruc-Project.Hangfire Katmanı
Mail gönderme servisi için Hangfire paketi eklenmiştir ve JobDelayed sınıfı yönetilmektedir. Mailler kuyruğa alınıp asenkron şekilde gönderilmektedir.

### ✨ SinemYoruc-Project.NUnitTest Katmanı
Test sınıfları yönetilmektedir.

### ✨ SinemYoruc-Project.Service Katmanı
İşleyiş için gerekli olan fonksiyonları yönetmektedir.

# Installation
Öncelikle projeyi clonelayın.

```
git clone https://github.com/sinemyoruc/SinemYoruc-Project.git
```

# Usage
Projeyi cloneladıktan sonra Visual Studio 2022 programında açınız.

Daha sonra appsettings.json dosyasındaki ConnectionStrings alanını kendi database connection bilgilerinize göre doldurunuz.


Mail servisini kullanmak için SinemYoruc_Project.Hangfire paketi içindeki JobDelayed.cs dosyasından ilgili alanları kendi mail bilgilerinize göre güncelleyiniz.



# Outputs

### Swagger
![Swagger](Screenshots/account.png)
![Swagger](Screenshots/accountdetail-category.png)
![Swagger](Screenshots/login-product.png)


# Http Methods Details

## Account
⭐ GET /api/Account

Tüm kayıtlı accountları listeler.

⭐ POST /api/Account

Yeni account ekler. Email ve şifre validasyonları vardır. Şifre databasede MD5 ile şifrelenmiş şekilde saklanır.

⭐ DELETE /api/Account

Idsi verilen accountu siler.

⭐ GET /api/Account/{id}

Idsi verilen accountu listeler.

⭐ PUT /api/Account/{id}

Idsi verilen accountu günceller.


## AccountDetail

⭐ GET /api/AccountDetail/GetProduct

Account id alır ve o accountun productlarını listeler.

⭐ GET /api/AccountDetail/GetOfferProduct

Account id alır ve o accountun yaptığı offerları listeler.

⭐ GET /api/AccountDetail/GetRecievedOffer

Account id alır ve o accountun ürünlerine gelen offerları listeler.

⭐ POST /api/AccountDetail/CreateAcceptOffer

Idsi verilen offerı kabul eder. Producttaki offerStatus true, isOfferable false, isSold true yapar.

⭐ POST /api/AccountDetail/CreateRefuseOffer

Idsi verilen offerı reddeder. Producttaki offerStatus false, isOfferable true, isSoldu false yapar.


## Category
⭐ GET /api/Category

Kayıtlı olan kategorilerin tümünü listeler.

⭐ POST /api/Category

Kategori ekler.

⭐ DELETE /api/Category

Idsi verilen kategoriyi siler.

⭐ GET /api/Category/{id}

Idsi verilen kategoriyi listeler.

⭐ PUT /api/Category/{id}

Idsi verilen kategoriyi günceller.


## Login

⭐ POST /api/Login

Kayıtlı olan email ve şifre ile giriş yapar, token üretir.


## Product

⭐ POST /api/Product/ProductOffer

Product idye göre offer verir.

⭐ GET /api/Product/SoldProduct

Idsi verilen ürünün offerStatus true ise satın almayı sağlar. isSold alanını true yapar.

⭐ GET /api/Product

Kayıtlı tüm productları listeler.

⭐ POST /api/Product

Bilgileri girilen ürünü veritabanına ekler.

⭐ DELETE /api/Product

Idsi verilen productı siler.

⭐ GET /api/Product/{id}

Idsi verilen productı listeler.

⭐ PUT /api/Product/{id}

Idsi verilen productı günceller.