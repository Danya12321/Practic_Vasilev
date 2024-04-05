using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Sparepart
{
    public int IdPart { get; set; }

    public string? Partname { get; set; }

    public string? Partnumber { get; set; }

    public string? Manufacturer { get; set; }

    public decimal? Price { get; set; }

    public int? Instock { get; set; }
}
