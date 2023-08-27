using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace WebApplMVC_EntityFramework.Models;

public partial class BooksNew
{
    [DisplayName("Ідентифікатор")]
    [Remote(action: "VerifyId", controller: "BooksNews")]
    public int ?N { get; set; }

    [DisplayName("Код")]
    public double? Code { get; set; }

    [DisplayName("Нова")]
    public bool New { get; set; }

    [DisplayName("Назва")]
    public string? Name { get; set; }

    [DisplayName("Ціна")]
    public decimal? Price { get; set; }

    [DisplayName("Сторінок")]
    public double? Pages { get; set; }

    [DisplayName("Дата")]
    public DateTime? Date { get; set; }

    [DisplayName("Тираж")]
    public double? Pressrun { get; set; }

    public int? IzdId { get; set; }

    public int? FormatId { get; set; }

    public int? ThemesId { get; set; }

    public int? KategoryId { get; set; }
    [DisplayName("Формат")]
    public virtual SprFormat? Format { get; set; }
    [DisplayName("Видавництво")]
    public virtual SprIzd? Izd { get; set; }
    [DisplayName("Категорія")]
    public virtual SprKategory? Kategory { get; set; }
    [DisplayName("Тема")]
    public virtual SprTheme? Themes { get; set; }
}
