using System;
using System.Collections.Generic;

namespace MyAplication.models;

public partial class Bill
{
    public int IdSale { get; set; }

    public int IdProductBill { get; set; } 

    public int? QuantityProduct { get; set; }

    public int TpriceProduct { get; set; }

    public int? TotalSale { get; set; }

    public virtual Product? IdProductBillNavigation { get; set; }
}
