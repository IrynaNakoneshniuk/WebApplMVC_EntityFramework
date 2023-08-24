using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplMVC_EntityFramework.Models;

public partial class SprKategory
{
    [DisplayName("Категорія")]
    public string? Category { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
