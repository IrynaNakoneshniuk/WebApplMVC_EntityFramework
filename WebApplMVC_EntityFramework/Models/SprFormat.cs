using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplMVC_EntityFramework.Models;

public partial class SprFormat
{
    [DisplayName("Формат")]
    public string? Format { get; set; }

    public int Id { get; set; }

    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
