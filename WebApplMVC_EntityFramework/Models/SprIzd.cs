using System.ComponentModel;

namespace WebApplMVC_EntityFramework.Models;

public partial class SprIzd
{
    [DisplayName("Видавництво")]
    public string? Izd { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
