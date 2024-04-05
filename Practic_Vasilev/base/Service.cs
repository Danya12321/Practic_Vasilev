using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Service
{
    public int IdService { get; set; }

    public int? IdAuto { get; set; }

    public string? Servicetype { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Cost { get; set; }

    public int? Employeeid { get; set; }

    public string? Notes { get; set; }

    public virtual Car? IdAutoNavigation { get; set; }
}
