using CSProjeDemo1.Enums;
using CSProjeDemo1.Models;
using CSProjeDemo1.Models.Types;

namespace CSProjeDemo1.Services
{
    public class Kutuphane
    {
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();
        public List<Uye> Uyeler { get; set; } = new List<Uye>();

        public void KitapOduncVer(Kitap kitap, Uye uye)
        {
            if (kitap == null || uye == null)
            {
                throw new ArgumentNullException("Kitap veya üye boş olamaz.");
            }

            // Kitap ve üye kontrolü
            if (!Kitaplar.Contains(kitap))
                throw new IndexOutOfRangeException("Kitap kütüphanede mevcut değil.");

            if (!Uyeler.Contains(uye))
                throw new IndexOutOfRangeException("Üye kütüphaneye kayıtlı değil.");

            // Kitabın durumunu kontrol et ve ödünç ver
            if (kitap.Durum != Durum.OduncAlinabilir)
                throw new InvalidOperationException("Kitap ödünç verilebilir durumda değil.");

            uye.KitapOduncAl(kitap);
        }

        public void KitapOduncAl(Kitap kitap, Uye uye)
        {
            if (kitap == null || uye == null)
            {
                throw new ArgumentNullException("Kitap veya üye boş olamaz.");
            }

            // Kitap ve üye kontrolü
            if (!Kitaplar.Contains(kitap))
                throw new InvalidOperationException("Kitap kütüphanede mevcut değil.");

            if (!Uyeler.Contains(uye))
                throw new InvalidOperationException("Üye kütüphaneye kayıtlı değil.");

            // Kitabın durumunu ve üyede olup olmadığını kontrol et
            if (kitap.Durum != Durum.OduncVerildi)
                throw new InvalidOperationException("Kitap ödünç verilmiş durumda değil.");

            if (!uye.OduncAlinanKitaplar.Contains(kitap))
                throw new InvalidOperationException("Kitap bu üyede bulunmuyor.");

            uye.KitapOduncVer(kitap);
        }
        public void KitapDurumGuncelle(Kitap kitap, Durum yeniDurum)
        {
            if (kitap == null)
            {
                throw new ArgumentNullException("Kitap boş olamaz.");
            }

            if (!Kitaplar.Contains(kitap))
            {
                throw new InvalidOperationException("Kitap kütüphanede mevcut değil.");
            }

            kitap.Durum = yeniDurum;
        }

        public void KitapEkle(Kitap kitap)
        {
            if (Kitaplar.Any(k => k.ISBN == kitap.ISBN))
                throw new InvalidOperationException("Bu ISBN'e sahip kitap zaten mevcut.");

            Kitaplar.Add(kitap);
        }

        public void UyeEkle(Uye uye)
        {
            if (Uyeler.Any(u => u.UyeNumarasi == uye.UyeNumarasi))
                throw new InvalidOperationException("Bu üye numarasına sahip üye zaten mevcut.");

            Uyeler.Add(uye);
        }

        public void BilimKurguEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)
        {
            KitapBilim kitapBilim = new KitapBilim
            {
                ISBN = isbn,
                Baslik = baslik,
                Yazar = yazar,
                YayinYili = yayinYili,
                Tur = "Bilim Kurgu",
                Durum = durum
            };
            KitapEkle(kitapBilim);
        }

        public void RomanEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)
        {
            KitapRoman kitapRoman = new KitapRoman
            {
                ISBN = isbn,
                Baslik = baslik,
                Yazar = yazar,
                YayinYili = yayinYili,
                Tur = "Roman",
                Durum = durum
            };
            KitapEkle(kitapRoman);
        }

        public void TarihEkle(string isbn, string baslik, string yazar, int yayinYili, Durum durum)
        {
            KitapTarih kitapTarih = new KitapTarih
            {
                ISBN = isbn,
                Baslik = baslik,
                Yazar = yazar,
                YayinYili = yayinYili,
                Tur = "Tarih",
                Durum = durum
            };
            KitapEkle(kitapTarih);
        }
    }
}
