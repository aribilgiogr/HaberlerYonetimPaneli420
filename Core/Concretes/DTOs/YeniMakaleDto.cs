using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class YeniMakaleDto
    {
        [Required, Display(Name = "Başlık", Prompt = "Başlık")]
        public string Baslik { get; set; } = null!;

        [Required, Display(Name = "İçerik", Prompt = "İçerik"), DataType(DataType.MultilineText)]
        public string Icerik { get; set; } = null!;

        [Display(Name = "Kapak Görseli", Prompt = "Kapak Görseli"), DataType(DataType.Upload)]
        public IFormFile? KapakGorseli { get; set; }

        [Required, Display(Name = "Kategori", Prompt = "Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Etiketler", Prompt = "Etiketler (virgülle ayrılmış)")]
        public IEnumerable<string> Etiketler { get; set; } = [];
    }
}
