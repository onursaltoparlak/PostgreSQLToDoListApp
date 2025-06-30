# PostgreSQLToDoListApp
PostgreSQLToDoListApp, C# ve PostgreSQL kullanılarak geliştirilmiş basit bir yapılacaklar listesi (To-Do List) uygulamasıdır. Kullanıcıların görev ekleyip, durumlarını takip edebileceği temel işlevleri içerir. Proje, veritabanı işlemleri ve temel CRUD işlemlerinin nasıl yapılacağını göstermek için ideal bir örnek teşkil eder.

## Ekran Görüntüleri

![categorylis](https://github.com/user-attachments/assets/523cb5f0-7ed8-4957-b404-e2f6e0e77fc0)

![devam edenler](https://github.com/user-attachments/assets/0ed8b71d-5630-47a4-9361-e324b8729e59)

![frmcategory](https://github.com/user-attachments/assets/155f5c66-15db-48e0-96ea-43eeda249db1)


## Özellikler

Görev ekleme, listeleme, güncelleme ve silme

Görev durumunu (tamamlandı/devam ediyor) değiştirme

Görevlerin öncelik ve kategori bilgisi ile yönetimi

PostgreSQL veritabanı kullanımı

Basit ve anlaşılır kullanıcı arayüzü (Windows Forms)

## Kullanılan Teknolojiler

C# (Windows Forms)

PostgreSQL (Veritabanı)

Npgsql (.NET için PostgreSQL bağlantı kütüphanesi)

## Kurulum ve Çalıştırma

PostgreSQL veritabanını kurun ve aşağıdaki tabloları içeren bir veritabanı oluşturun:

ToDoLists

Categories

## Projeyi bilgisayarınıza klonlayın:

git clone https://github.com/onursaltoparlak/PostgreSQLToDoListApp.git

Visual Studio veya tercih ettiğiniz IDE ile projeyi açın.

app.config ya da bağlantı dizesi ayarlarını kendi PostgreSQL kullanıcı adı, şifre ve sunucu bilgilerinize göre güncelleyin.

Projeyi derleyip çalıştırın.

## Proje Yapısı

FrmToDoListApp.cs: Ana form ve kullanıcı arayüzü kodları

NpgsqlConnection: PostgreSQL bağlantı ve sorgu işlemleri

CRUD işlemleri için SQL sorguları

## Katkıda Bulunma

Proje açık kaynak olarak paylaşılmıştır. İyileştirme ve önerileriniz için pull request gönderebilir veya issue açabilirsiniz.

