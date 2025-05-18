# İngilizce Kelime Öğrenme Web Uygulaması

Bu proje, kullanıcıların İngilizce kelimeleri öğrenmesini ve puan kazanmasını sağlayan, mobil uyumlu ve dinamik özellikler içeren bir ASP.NET MVC web uygulamasıdır. Proje içerisinde kullanıcı girişi, kayıt olma, kelime yönetimi, puan tablosu gibi fonksiyonlar yer almaktadır.

Ayrıca, kayıt olurken **T.C. Kimlik No** doğrulaması yapmak için kendi geliştirdiğim SOA tabanlı bir Node.js API’si kullanılmış ve [https://tckimlik.nvi.gov.tr/service/kpspublic.asmx](https://tckimlik.nvi.gov.tr/service/kpspublic.asmx) servisine bağlanılmıştır.

## 🚀 Kullanılan Teknolojiler

- ASP.NET MVC (C#)
- Entity Framework (MySQL)
- HTML, CSS, Bootstrap (Responsive Tasarım)
- Node.js (SOAP API ile TCKN doğrulama)
- SOA Mimarisi
- MySQL Veritabanı

---

## 🔍 Proje Özeti

### 🎨 Layout ve Görünümler
- **Özel olarak hazırlanmış Layout.cshtml** kullanılmıştır.

### 📱 Mobil Uyumlu (Responsive) Tasarım

### ♻️ PartialView

### 🧩 ViewComponent

### 📂 Entity Framework & CRUD İşlemleri
- Aşağıdaki işlemler Entity Framework üzerinden yapılmaktadır:
  - Kelime Ekleme, Silme, Güncelleme
  - Kullanıcı Yönetimi
  - Kategori İşlemleri
- **İlişkili Tablolar**

### 🧭 Controller ve Action'lar
- En az **3 Controller** mevcuttur:
  - `HomeController`
  - `KelimeController`
  - `AccountController`
- Her birinde birden fazla **Action** bulunmaktadır.

### 🔐 Kimlik Doğrulama ve Rol Bazlı Yetkilendirme
- Kullanıcı kayıt, giriş ve çıkış işlemleri mevcuttur.
- Bazı sayfalar yalnızca giriş yapmış kullanıcılar tarafından görüntülenebilir.
- Kayıt sırasında T.C. Kimlik Numarası doğrulaması yapılmaktadır.
  - Bu doğrulama işlemi, projeye dahil edilen **Node.js tabanlı SOA API** ile gerçekleştirilmekte ve SOAP protokolü ile resmi NVI servisine bağlanılmaktadır.

---
![image](https://github.com/user-attachments/assets/70627e1f-2fc7-45fe-89b1-f59726c5b864)
![image](https://github.com/user-attachments/assets/b110c0c8-f5db-477a-83f1-bbff181aaf65)
![image](https://github.com/user-attachments/assets/d001fc89-cfab-4e74-a355-91fac3407d02)
![image](https://github.com/user-attachments/assets/e06390f0-b41f-4dcb-b868-635a0875d219)
![image](https://github.com/user-attachments/assets/686c00fe-5c04-4dea-83f9-b606d84ff21d)
![image](https://github.com/user-attachments/assets/b1664951-3c00-4a39-84c9-ba267d9b4f4b)
![image](https://github.com/user-attachments/assets/d2c2b8bc-9229-4314-a588-b69818fc92ca)
![image](https://github.com/user-attachments/assets/dee3797c-aab5-44fc-ac33-ffb7ce373f79)
![image](https://github.com/user-attachments/assets/feaac7d9-1e9a-4e67-91fe-14a1b1c63981)
![image](https://github.com/user-attachments/assets/ce4bf185-b807-43a6-9a54-40d93e02ec27)
![image](https://github.com/user-attachments/assets/6cffad54-e256-403b-ac0e-4292959d7fa5)
![image](https://github.com/user-attachments/assets/fb02d11e-e6ac-4b2a-b265-0bbba1349f5a)

## ⚙️ Kurulum Adımları

1. **MySQL Veritabanını Kurun**
   - `kelime_ogrenme_projesi.sql` dosyasını MySQL'e içe aktarın.
   - Veritabanı adı: `kelime_ogrenme_projesi`

2. **SOA Servisini Başlatın**
   - Servisi başlatın:
     ```bash
     npm start
     ```

3. **Web Uygulamasını Çalıştırın**
   - Projeyi Visual Studio 202X ile açın.
   - Web projesini derleyip çalıştırın.
   - MySQL bağlantısı otomatik olarak yapılandırılmıştır, ekstra bir ayar yapmanıza gerek yoktur.

---

## 📌 Notlar

- Giriş işlemleri sırasında T.C. Kimlik doğrulama işlemleri Node.js servisi üzerinden yapılır.
- Bu servis, Türkiye Cumhuriyeti Kimlik Doğrulama Web Servisi (SOAP) ile bağlantı kurar.
- Test işlemleri için Postman kullanılabilir.

---
