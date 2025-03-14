using CSProjeDemo1.Enums;

namespace CSProjeDemo1.Models
{
    public abstract class Kitap
    {
        public string ISBN { get; set; } = Guid.NewGuid().ToString();
        public string Baslik { get; set; } = "";
        public string Yazar { get; set; } = "";
        public int YayinYili { get; set; } = 0;
        public string Tur { get; set; } = "";
        public abstract Durum Durum { get; set; } 

    }
}
