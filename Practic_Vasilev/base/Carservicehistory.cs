using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Carservicehistory
{
    public int IdHistory { get; set; }

    public int? IdAuto { get; set; }

    public int? IdService { get; set; }

    public DateOnly? Servicedate { get; set; }

    public string? Description { get; set; }

    public virtual Car? IdAutoNavigation { get; set; }
}
