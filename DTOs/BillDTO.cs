namespace MyAplication.DTOs
{
    public class BillDTO
    {
        public int IdSale { get; set; }

        public int QuantityProduct { get; set; }

        public int IdProductBill { get; set; } 

    }
    public class BillDTO2 : BillDTO
    {
        public int TpriceProduct { get; set; }

        public int? TotalSale { get; set; }
    }
}
