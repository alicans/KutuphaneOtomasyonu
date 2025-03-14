# Kütüphane Yönetim Sistemi

## Genel Bakış
Bu proje, C# ile uygulanmış bir kütüphane yönetim sistemidir. Kullanıcıların kitapları ve üyeleri yönetmesine, kitap ödünç alma ve iade işlemlerini gerçekleştirmesine olanak tanır.

## Özellikler
- Kütüphaneye yeni kitaplar ekleyin.
- Kütüphaneye yeni üyeler ekleyin.
- Üyelere kitap ödünç verin.
- Üyelerden kitap iade alın.

## Sınıflar ve Metodlar

### Kutuphane Sınıfı
`Kutuphane` sınıfı, kütüphanedeki kitapları ve üyeleri yönetmekten sorumludur.

#### Özellikler
- `List<Kitap> Kitaplar`: Kütüphanedeki kitapların listesi.
- `List<Uye> Uyeler`: Kütüphanedeki üyelerin listesi.

#### Metodlar
- `void KitapOduncVer(Kitap kitap, Uye uye)`: Bir kitabı bir üyeye ödünç verir.
- `void KitapOduncAl(Kitap kitap, Uye uye)`: Bir üyeden kitabı iade alır.
- `void KitapEkle(Kitap kitap)`: Kütüphaneye yeni bir kitap ekler.
- `void UyeEkle(Uye uye)`: Kütüphaneye yeni bir üye ekler.
- `void BilimKurguEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)`: Kütüphaneye yeni bir bilim kurgu kitabı ekler.
- `void RomanEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)`: Kütüphaneye yeni bir roman ekler.
- `void TarihEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)`: Kütüphaneye yeni bir tarih kitabı ekler.

### Kitap Sınıfı
`Kitap` sınıfı, bir kitabı temsil eden soyut bir sınıftır.

#### Özellikler
- `string ISBN`: Kitabın ISBN numarası.
- `string Baslik`: Kitabın başlığı.
- `string Yazar`: Kitabın yazarı.
- `int YayinYili`: Kitabın yayın yılı.
- `string Tur`: Kitabın türü.
- `abstract Durum Durum`: Kitabın durumu.

### Uye Sınıfı
`Uye` sınıfı, kütüphanenin bir üyesini temsil eder.

#### Özellikler
- `string Ad`: Üyenin adı.
- `string Soyad`: Üyenin soyadı.
- `int UyeNumarasi`: Üye numarası.
- `List<Kitap> OduncAlinanKitaplar`: Üyenin ödünç aldığı kitapların listesi.

#### Metodlar
- `void KitapOduncAl(Kitap kitap)`: Bir kitabı ödünç alır.
- `void KitapOduncVer(Kitap kitap)`: Ödünç alınan bir kitabı iade eder.

### Durum Enum
`Durum` enum, bir kitabın durumunu temsil eder.

#### Değerler
- `OduncAlinabilir`: Kitap ödünç alınabilir durumda.
- `OduncVerildi`: Kitap ödünç verilmiş durumda.
- `MevcutDegil`: Kitap mevcut değil.

## Kullanım
Bu kütüphane yönetim sistemini kullanmak için, `Kutuphane` sınıfının bir örneğini oluşturun ve kitapları ve üyeleri yönetmek için metodlarını kullanın.

## Gereksinimler
- .NET 8
- C# 12.0

## Lisans
Bu proje MIT Lisansı ile lisanslanmıştır.
