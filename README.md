# Patika & PayCore .NET/.NET Core Bootcamp Graduation Project
Proje 7 katmandan oluşmaktadır.

### ✨ SinemYoruc-Project Katmanı
Controllerlar ve StartupExtensionlar yönetilmektedir.

### ✨ SinemYoruc-Project.Base Katmanı
Projede kullanılacak genel sınıflar yönetilmektedir.

### ✨ SinemYoruc-Project.Data Katmanı
Kullanılacak modeller ve mapping işlemleri yönetilmektedir.

### ✨ SinemYoruc-Project.Dto Katmanı
Mapping için gerekli sınıflar yönetilmektedir.

### ✨ SinemYoruc-Project.Hangfire Katmanı
Mail gönderme servisi için Hangfire eklenmiş ve JobDelayed sınıfı yönetilmektedir. Mailler kuyruğa alınıp asenkron şekilde gönderilmektedir.

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
![Swagger](SinemYoruc-Project/Screenshots/.png)
