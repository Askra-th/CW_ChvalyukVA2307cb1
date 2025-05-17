using System;
using System.Collections.Generic;

namespace CW_ChvalyukVA2307cb1;

public partial class Заявка
{
    public int ЗаявкаId { get; set; }

    public string? ОписаниеЗаявки { get; set; }

    public string? Тип { get; set; }

    public DateTime ДатаРегистрацииЗаявки { get; set; }

    public int СтатусЗаявки { get; set; }

    public int ИсполнительЗаявки { get; set; }

    public string? Описание { get; set; }

    public virtual Пользователь ИсполнительЗаявкиNavigation { get; set; } = null!;

    public virtual ОпцииСтатуса СтатусЗаявкиNavigation { get; set; } = null!;
}
