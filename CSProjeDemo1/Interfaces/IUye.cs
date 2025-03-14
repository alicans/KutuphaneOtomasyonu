using CSProjeDemo1.Models;

namespace CSProjeDemo1.Interfaces
{
    public interface IUye
    {
        string Ad { get; set; }
        string Soyad { get; set; }
        int UyeNumarasi { get; set; }
        List<Kitap> OduncAlinanKitaplar { get; set; }

        void KitapOduncAl(Kitap kitap);
        void KitapOduncVer(Kitap kitap);
    }
}
