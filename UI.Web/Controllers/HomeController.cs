using Core.Abstracts.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Threading.Tasks;
using UI.Web.Models;

namespace UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMakaleService service;
        public HomeController(IMakaleService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.MakaleleriGetir());
        }

        public async Task<IActionResult> Create()
        {
            var kategoriler = await service.KategorileriGetir();
            ViewBag.Kategoriler = new SelectList(kategoriler, "Id", "Ad");
            return View();
        }

        public async Task<IActionResult> Kategoriler(int? id)
        {
            var kategoriler = await service.KategorileriGetir();
            var secili = id != null ? kategoriler.FirstOrDefault(x => x.Id == id) : null;

            var model = new KategorilerViewModel
            {
                Kategoriler = kategoriler,
                SeciliKategori = secili
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> KategoriOlustur(KategorilerViewModel model)
        {
            await service.KategoriEkleAsync(model.SeciliKategori.Ad);
            return RedirectToAction("kategoriler");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
