using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Customerreview
{
    public int Reviewid { get; set; }

    public int? IdClient { get; set; }

    public int? IdAuto { get; set; }

    public int? IdTransaction { get; set; }

    public DateOnly? Date { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public virtual Car? IdAutoNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
