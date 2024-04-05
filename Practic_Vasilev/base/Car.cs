using System;
using System.Collections.Generic;

namespace Practic_Vasilev.@base;

public partial class Car
{
    public int IdAuto { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public string? Vin { get; set; }

    public string? Color { get; set; }

    public int? Mileage { get; set; }

    public string? Status { get; set; }

    public decimal? Price { get; set; }

    public string? Warranty { get; set; }

    public virtual ICollection<Carservicehistory> Carservicehistories { get; set; } = new List<Carservicehistory>();

    public virtual ICollection<Customerreview> Customerreviews { get; set; } = new List<Customerreview>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();

    public virtual ICollection<Testdrive> Testdrives { get; set; } = new List<Testdrive>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
