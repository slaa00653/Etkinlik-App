namespace etkinlikuygulaması.Models
{
    public class Etkinlik
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Kategori { get; set; }
        public string Konum { get; set; }
        public string Ucret { get; set; }
        public int Kontenjan { get; set; }
        public string DokumanYolu { get; set; }
    }
}
