# 👩‍🎓👨‍🎓 Öğrenci Not Kayıt Sistemi 📝

Bu proje, öğrenci notlarını kayıt altına almak, sınıfın genel durumunu analiz etmek ve öğretmenlerin öğrenci eklemesini sağlamak için geliştirilmiş bir **Windows Forms** uygulamasıdır.

**Roller**: Öğrenciler, sınav sonuçlarını ve başarı durumlarını görüntülerken; öğretmenler öğrenci ekleyebilir, notları güncelleyebilir ve sınıfın genel analizini yapabilir.

---
## 📋 Özellikler

### Veritabanı Yapısı:
Tablo adı: `Tbl_Lesson`


| Sütun Adı          | Veri Tipi       | Açıklama                                     |
|---------------------|-----------------|---------------------------------------------|
| `Student_ID`       | `SMALLINT`      | Birincil anahtar                            |
| `Student_Number`   | `CHAR(4)`       | Öğrenci numarası                            |
| `Student_Name`     | `VARCHAR(15)`   | Öğrencinin adı                              |
| `Student_Surname`  | `VARCHAR(20)`   | Öğrencinin soyadı                           |
| `Student_Exam1`    | `TINYINT`       | 1. sınav notu                               |
| `Student_Exam2`    | `TINYINT`       | 2. sınav notu                               |
| `Student_Exam3`    | `TINYINT`       | 3. sınav notu                               |
| `Average`          | `DECIMAL(18,2)` | Sınavların ortalaması                       |
| `Situation`        | `BIT`           | Durum (1: Başarılı, 0: Başarısız)           |

### Uygulama Özellikleri:

- **Giriş Ekranı**: Kullanıcı öğrenci numarası ile sisteme giriş yapar.
  - **Öğrenci Numarası (1111)**: Öğretmen detay ekranına yönlendirir.
  - Diğer numaralar: Öğrenci detay ekranına yönlendirir.
- **Öğrenci Detay Ekranı**:
  - Öğrencinin sınav notlarını ve genel başarı durumunu görüntüler.
- **Öğretmen Detay Ekranı**:
  - Yeni öğrenci eklenebilir.
  - Öğrencilerin sınav notları güncellenebilir.
  - Sınıfın genel not ortalaması ve başarı durumu görüntülenebilir.

---

## 🖥️ Uygulama Ekranları

### 1️⃣ Giriş Ekranı
- Kullanıcı, öğrenci numarasını girerek uygun ekrana yönlendirilir.

![Giriş Ekranı](https://via.placeholder.com/800x400.png?text=Giri%C5%9F+Ekran%C4%B1)

---

### 2️⃣ Öğrenci Detay Ekranı
- Öğrenci sınav notlarını ve genel durumunu bu ekranda görüntüleyebilir.

![Öğrenci Detay Ekranı](https://via.placeholder.com/800x400.png?text=%C3%96%C4%9Frenci+Detay+Ekran%C4%B1)

![Öğretmen Detay Ekranı](https://via.placeholder.com/800x400.png?text=%C3%96%C4%9Fretmen+Detay+Ekran%C4%B1)

---

### 3️⃣ Öğretmen Detay Ekranı
- Öğretmenler bu ekranı kullanarak sınıfın genel durumunu analiz edebilir ve öğrencilerle ilgili işlemler yapabilir.
  - **Yeni Öğrenci Ekleme**
  - **Not Güncelleme**
  - **Genel Ortalama ve Başarı Durumu Analizi**

![Öğretmen Detay Ekranı](https://via.placeholder.com/800x400.png?text=%C3%96%C4%9Fretmen+Detay+Ekran%C4%B1)

![Öğretmen Detay Ekranı](https://via.placeholder.com/800x400.png?text=%C3%96%C4%9Fretmen+Detay+Ekran%C4%B1)
---

## 🛠️ Kullanılan Teknolojiler

- **C#** ile Windows Forms geliştirme
- **Microsoft SQL Server** ile veritabanı yönetimi
- Visual Studio IDE

## 🚀 Çalıştırma Talimatları

1. **Proje Dosyasını İndir:**  
   - Proje klasörünü indirin veya klonlayın.

2. **Uygulamayı Çalıştır:**  
   - Aşağıdaki dizinde bulunan **ÖğrenciNotKayıtSistemi.exe** dosyasını çalıştırın:  
     ```
     Öğrenci Not Kayıt Sistemi\ÖğrenciNotKayıtSistemi\ÖğrenciNotKayıtSistemi\bin\Debug\
     ```

 **Not:**  
   - Veritabanı bağlantısı için **SQL Server**'ınızın çalıştığından emin olun.


