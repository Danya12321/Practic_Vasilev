using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Testdrive
{
    public int IdTestdrive { get; set; }

    public int? IdAuto { get; set; }

    public int? IdClient { get; set; }

    public DateTime? Date { get; set; }

    public int? Duration { get; set; }

    public string? Feedback { get; set; }

    public virtual Car? IdAutoNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }
}
