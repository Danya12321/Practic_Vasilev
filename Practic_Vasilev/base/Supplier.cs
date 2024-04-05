using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Supplier
{
    public int Supplierid { get; set; }

    public string? Companyname { get; set; }

    public string? Contactname { get; set; }

    public string? Contactinfo { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Supplyorder> Supplyorders { get; set; } = new List<Supplyorder>();
}
