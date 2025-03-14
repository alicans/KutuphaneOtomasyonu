using CSProjeDemo1.Enums;
using CSProjeDemo1.Interfaces;

namespace CSProjeDemo1.Models
{
    public class Uye : IUye
    {
        public string Ad { get; set; } = "";
        public string Soyad { get; set; } = "";
        public int UyeNumarasi { get; set; } = new Random().Next(1000, 9999);
        public List<Kitap> OduncAlinanKitaplar { get; set; } = new List<Kitap>();

        public void KitapOduncAl(Kitap kitap)
        {
            if (kitap.Durum == Durum.OduncAlinabilir)
            {
                kitap.Durum = Durum.OduncVerildi;
                OduncAlinanKitaplar.Add(kitap);
            }
        }

        public void KitapOduncVer(Kitap kitap)
        {
            if (OduncAlinanKitaplar.Contains(kitap))
            {
                kitap.Durum = Durum.OduncAlinabilir;
                OduncAlinanKitaplar.Remove(kitap);
            }
        }
    }
}
