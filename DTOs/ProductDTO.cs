namespace MyAplication.DTOs
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }

        public string NameProduct { get; set; } = null!;

        public int PriseProduct { get; set; }

        public int StockProduct { get; set; } = 50;
    }
}
