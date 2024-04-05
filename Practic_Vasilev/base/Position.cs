using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Position
{
    public int Positionid { get; set; }

    public string? Positiontitle { get; set; }

    public string? Description { get; set; }

    public string? Salaryrange { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
