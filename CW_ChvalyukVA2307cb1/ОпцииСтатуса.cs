using System;
using System.Collections.Generic;

namespace CW_ChvalyukVA2307cb1;

public partial class ОпцииСтатуса
{
    public int Id { get; set; }

    public string Names { get; set; } = null!;

    public virtual ICollection<Заявка> Заявкаs { get; set; } = new List<Заявка>();
}
