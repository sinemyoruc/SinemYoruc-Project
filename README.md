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
Mail gönderme servisi için Hangfire paketi eklenmiştir ve JobDelayed sınıfı yönetilmektedir. Mailler kuyruğa alınıp asenkron şekilde ve maksimum 2 saniyede gönderilmektedir. Bir job maksimum 5 kez çalışmaktadır. Eğer başarılı olamadıysa Fail statusune çekilmektedir.

### ✨ SinemYoruc-Project.NUnitTest Katmanı
Test sınıfları yönetilmektedir.

### ✨ SinemYoruc-Project.Service Katmanı
İşleyiş için gerekli olan fonksiyonlar yönetilmektedir.

# Installation
Öncelikle projeyi clonelayınız.

```
git clone https://github.com/sinemyoruc/SinemYoruc-Project.git
```

# Usage
Projeyi cloneladıktan sonra Visual Studio 2022 programında açınız.

Daha sonra appsettings.json dosyasındaki ConnectionStrings alanını kendi database connection bilgilerinize göre doldurunuz.


Mail servisini kullanmak için SinemYoruc_Project.Hangfire paketi içindeki JobDelayed.cs dosyasından ilgili alanları kendi mail bilgilerinize göre güncelleyiniz.

Account ve Login apileri dışında diğer apileri kullanabilmek için authorization ayarlanmıştır. Önce hesap oluşturup login olarak token alabilirsiniz.



# Outputs

### Swagger
![Swagger](Screenshots/account.png)
![Swagger](Screenshots/accountdetail-category.png)
![Swagger](Screenshots/login-product.png)
 

# Http Methods Details

## Account
⭐  <font color="blue"> **GET**</font> **/api/Account**

Tüm kayıtlı accountları listeler.

⭐  <font color="green"> **POST**</font> **/api/Account**

Yeni account ekler. Email ve şifre validasyonları vardır. Şifre databasede MD5 ile şifrelenmiş şekilde saklanır. Hesap oluşturulduktan sonra kullanıcıya hoşgeldiniz maili gönderir.

⭐ <font color="red"> **DELETE**</font> **/api/Account**

Idsi verilen accountu siler.

⭐  <font color="blue"> **GET**</font> **/api/Account/{id}**

Idsi verilen accountu listeler.

⭐ <font color="orange"> **PUT**</font> **/api/Account/{id}**

Idsi verilen accountu günceller.


## AccountDetail

⭐  <font color="blue"> **GET**</font> **/api/AccountDetail/GetProduct**

Account id alır ve o accountun productlarını listeler.

⭐  <font color="blue"> **GET**</font> **/api/AccountDetail/GetOfferProduct**

Account id alır ve o accountun yaptığı offerları listeler.

⭐  <font color="blue"> **GET**</font> **/api/AccountDetail/GetRecievedOffer**

Account id alır ve o accountun ürünlerine gelen offerları listeler.

⭐ <font color="green"> **POST**</font> **/api/AccountDetail/CreateAcceptOffer**

Idsi verilen offerı kabul eder. Producttaki offerStatus true ve isOfferable false yapar. Teklifin kabul edildiğine dair kullanıcıya mail gönderir. Price alanı offerdaki fiyata göre güncellenir. Kullanıcı ***GET /api/Product/SoldProduct*** apisi ile productı satın alabilir. 

⭐ <font color="green"> **POST**</font> **/api/AccountDetail/CreateRefuseOffer**

Idsi verilen offerı reddeder. Producttaki offerStatus false ve isOfferable true yapar. Teklifin reddedildiğine dair kullanıcıya mail gönderir.


## Category
⭐  <font color="blue"> **GET**</font> **/api/Category**

Kayıtlı olan kategorilerin tümünü listeler.

⭐ <font color="green"> **POST**</font> **/api/Category**

Kategori ekler.

⭐ <font color="red"> **DELETE**</font> **/api/Category**

Idsi verilen kategoriyi siler.

⭐  <font color="blue"> **GET**</font> **/api/Category/{id}**

Idsi verilen kategoriyi listeler.

⭐ <font color="orange"> **PUT**</font> **/api/Category/{id}**

Idsi verilen kategoriyi günceller.


## Login

⭐ <font color="green"> **POST**</font> **/api/Login**

Kayıtlı olan email ve şifre ile giriş yapar, token üretir. Kullanıcıya giriş yapıldı maili gönderir.


## Product

⭐ <font color="green"> **POST**</font> **/api/Product/ProductOffer**

Product idye göre isOfferable true, isSold alanı false ise offer verir.

⭐  <font color="blue"> **GET**</font> **/api/Product/SoldProduct**

Idsi verilen ürünün isSold alanı false ise satın almayı sağlar. isSold alanını true yapar.

⭐ <font color="blue"> **GET**</font> **/api/Product**

Kayıtlı tüm productları listeler.

⭐ <font color="green"> **POST**</font> **/api/Product**

Bilgileri girilen ürünü veritabanına ekler. Validasyonları mevcut.

⭐ <font color="red"> **DELETE**</font> **/api/Product**

Idsi verilen productı siler.

⭐ <font color="blue"> **GET**</font> **/api/Product/{id}**

Idsi verilen productı listeler.

⭐ <font color="orange"> **PUT**</font> **api/Product/{id}**

Idsi verilen productı günceller.


