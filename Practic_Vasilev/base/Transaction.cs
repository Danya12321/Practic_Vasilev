using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Transaction
{
    public int IdTransaction { get; set; }

    public int? IdAuto { get; set; }

    public int? IdClient { get; set; }

    public DateOnly? Date { get; set; }

    public decimal? Amount { get; set; }

    public string? Paymentmethod { get; set; }

    public string? Financingdetails { get; set; }

    public virtual Car? IdAutoNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
