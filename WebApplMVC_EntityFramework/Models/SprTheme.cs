using System.ComponentModel;

namespace WebApplMVC_EntityFramework.Models;

public partial class SprTheme
{
    [DisplayName("Тема")]
    public string? Themes { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
