namespace FilmProjesi.Models
{
    public class Film
    {
        public string FilmAdi { get; set; } = string.Empty;  // Null hatasını önler
        public string FilmAdiIng { get; set; } = string.Empty;
        public int YapimYili { get; set; }
        public string Oyuncular { get; set; } = string.Empty;
        public double ImdbPuani { get; set; }
        public string Kategori { get; set; } = string.Empty; // Null hatasını önler
    }
}
