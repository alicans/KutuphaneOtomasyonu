using CSProjeDemo1;
using CSProjeDemo1.Models;
using CSProjeDemo1.Enums;
using CSProjeDemo1.Services;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();

            try
            {
                // Üye Ekleme İşlemleri
                try
                {
                    kutuphane.UyeEkle(new Uye { Ad = "Ali", Soyad = "Veli", UyeNumarasi = 1 });
                    kutuphane.UyeEkle(new Uye { Ad = "Ahmet", Soyad = "Mehmet", UyeNumarasi = 2 });

                    // HATA KONTROLÜ: Aynı üye numarasıyla eklemeyi deneyelim
                    //kutuphane.UyeEkle(new Uye { Ad = "Test", Soyad = "Test", UyeNumarasi = 1 });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }

                // Kitap Ekleme İşlemleri
                try
                {
                    kutuphane.BilimKurguEkle("12234", "Bilim Kurgu1", "Yazar1", 2020, Durum.OduncAlinabilir);
                    kutuphane.BilimKurguEkle("12345", "Bilim Kurgu2", "Yazar2", 2021, Durum.MevcutDegil);
                    kutuphane.BilimKurguEkle("12344", "Bilim Kurgu5", "Yazar3", 2021, Durum.OduncAlinabilir);

                    // HATA KONTROLÜ: Aynı ISBN ile eklemeyi dene
                    //kutuphane.BilimKurguEkle("12234", "Test", "Test", 2023, Durum.OduncAlinabilir);

                    kutuphane.RomanEkle("12444", "Roman1", "Yazar1", 2020, Durum.OduncAlinabilir);
                    kutuphane.RomanEkle("12445", "Roman2", "Yazar2", 2021, Durum.OduncAlinabilir);
                    kutuphane.RomanEkle("12446", "Roman3", "Yazar3", 2021, Durum.OduncAlinabilir);

                    kutuphane.TarihEkle("12544", "Tarih1", "Yazar1", 2020, Durum.OduncAlinabilir);
                    kutuphane.TarihEkle("12545", "Tarih2", "Yazar2", 2021, Durum.OduncAlinabilir);
                    kutuphane.TarihEkle("12546", "Tarih3", "Yazar3", 2021, Durum.OduncAlinabilir);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }

                // Kitap Ödünç Alma - Verme İşlemleri
                try
                {
                    kutuphane.KitapOduncVer(kutuphane.Kitaplar[0], kutuphane.Uyeler[0]);
                    kutuphane.KitapOduncVer(kutuphane.Kitaplar[4], kutuphane.Uyeler[1]);
                    kutuphane.KitapOduncVer(kutuphane.Kitaplar[3], kutuphane.Uyeler[0]);

                    kutuphane.KitapOduncAl(kutuphane.Kitaplar[0], kutuphane.Uyeler[0]);

                    // HATA KONTROLÜ: Olmayan indeksle denemek
                    //kutuphane.KitapOduncVer(kutuphane.Kitaplar[99], kutuphane.Uyeler[99]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Hata: indeks aralık dışında.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }

                // Kitabın durumunu güncelleme işlemi

                try
                {
                    kutuphane.KitapDurumGuncelle(kutuphane.Kitaplar[99], Durum.MevcutDegil);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Hata: Kitap kütüphanede mevcut değil.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                }

                // Listeleme İşlemleri
                Console.WriteLine("Kitaplar:");
                foreach (var kitap in kutuphane.Kitaplar)
                {
                    Console.WriteLine($"Başlık: {kitap.Baslik} - Tür: {kitap.Tur} - Durum: {kitap.Durum}");
                }

                Console.WriteLine("\nÜyeler:");
                foreach (var uye in kutuphane.Uyeler)
                {
                    Console.WriteLine($"Üye No: {uye.UyeNumarasi} - Ad: {uye.Ad} - Soyad: {uye.Soyad}");
                }

                Console.WriteLine("\nÜyelerin Aldığı Kitaplar:");
                foreach (var uye in kutuphane.Uyeler)
                {
                    Console.WriteLine($"Üye adı: {uye.Ad}");
                    if (uye.OduncAlinanKitaplar.Any())
                    {
                        foreach (var kitap in uye.OduncAlinanKitaplar)
                        {
                            Console.WriteLine($"Başlık: {kitap.Baslik} - Tür: {kitap.Tur} - Durum: {kitap.Durum}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ödünç alınan kitap yok");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}