using System;
using System.Collections.Generic;

namespace CW_ChvalyukVA2307cb1;

public partial class Пользователь
{
    public int UsersId { get; set; }

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public DateTime ДатаРегистрация { get; set; }

    public string Фио { get; set; } = null!;

    public string НомерТелефона { get; set; } = null!;

    public virtual ICollection<Заявка> Заявкаs { get; set; } = new List<Заявка>();
}
