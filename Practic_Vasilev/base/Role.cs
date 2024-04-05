using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Role
{
    public int Roleid { get; set; }

    public string? Rolename { get; set; }

    public string? Permissions { get; set; }

    public virtual ICollection<Useraccount> Useraccounts { get; set; } = new List<Useraccount>();
}
