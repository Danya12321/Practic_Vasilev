using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Useraccount
{
    public int Userid { get; set; }

    public string? Username { get; set; }

    public string? Passwordhash { get; set; }

    public int? Roleid { get; set; }

    public bool? Isactive { get; set; }

    public int? Employeeid { get; set; }

    public int? Clientid { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Role? Role { get; set; }
}
