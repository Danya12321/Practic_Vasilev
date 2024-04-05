using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Supplyorder
{
    public int IdOrder { get; set; }

    public int? Supplierid { get; set; }

    public DateOnly? Dateordered { get; set; }

    public DateOnly? Expecteddelivery { get; set; }

    public string? Status { get; set; }

    public virtual Supplier? Supplier { get; set; }
}
