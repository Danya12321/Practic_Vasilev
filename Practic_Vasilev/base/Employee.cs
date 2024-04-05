using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Employee
{
    public int Employeeid { get; set; }

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public int? Positionid { get; set; }

    public decimal? Salary { get; set; }

    public DateOnly? Hiredate { get; set; }

    public int? Performancerating { get; set; }

    public int? Useraccountid { get; set; }

    public virtual Position? Position { get; set; }

    public virtual ICollection<Useraccount> Useraccounts { get; set; } = new List<Useraccount>();
}
