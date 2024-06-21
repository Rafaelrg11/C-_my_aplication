using System;
using System.Collections.Generic;

namespace MyAplication.models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? NameProduct { get; set; }

    public int PriseProduct { get; set; }

    public int StockProduct { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();
}
