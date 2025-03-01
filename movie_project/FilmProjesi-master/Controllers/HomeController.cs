using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using FilmProjesi.Models;


namespace FilmProjesi.Controllers
{
    public class HomeController : Controller
    {
        private static List<Film> Filmler = new List<Film>();

        public IActionResult Index()
        {
            return View(Filmler);
        }

        [HttpPost]
        public IActionResult FilmEkle(string filmAdi, string filmAdiIng, int yapimYili, string oyuncular, double imdbPuani, string kategori)
{
    Filmler.Add(new Film
    {
        FilmAdi = filmAdi,
        FilmAdiIng = filmAdiIng,
        YapimYili = yapimYili,
        Oyuncular = oyuncular,
        ImdbPuani = imdbPuani,
        Kategori = kategori
    });
    TempData["Success"] = "Film başarıyla eklendi! 🎉"; // Başarı mesajı gönder

    return RedirectToAction("Index");
}

        // IMDB Puanına Göre Sıralama
        public IActionResult Sirala(string tur)
        {
            if (tur == "asc")
                Filmler = Filmler.OrderBy(f => f.ImdbPuani).ToList();
            else
                Filmler = Filmler.OrderByDescending(f => f.ImdbPuani).ToList();

            return View("Index", Filmler);
        }

        // Kategoriye Göre Filtreleme
        public IActionResult Filtrele(string kategori)
        {
            if (kategori == "Hepsi")
                return View("Index", Filmler);
            else
                return View("Index", Filmler.Where(f => f.Kategori == kategori).ToList());
        }
    }

    
}
