using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Client
{
    public int IdClient { get; set; }

    public string? Lastname { get; set; }

    public string? Firstname { get; set; }

    public string? Middlename { get; set; }

    public string? Contactinfo { get; set; }

    public int? Useraccountid { get; set; }

    public virtual ICollection<Customerreview> Customerreviews { get; set; } = new List<Customerreview>();

    public virtual ICollection<Testdrive> Testdrives { get; set; } = new List<Testdrive>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<Useraccount> Useraccounts { get; set; } = new List<Useraccount>();
}
