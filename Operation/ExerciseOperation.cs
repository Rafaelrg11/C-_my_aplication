using Microsoft.EntityFrameworkCore;
using MyAplication.DTOs;
using MyAplication.models;

namespace MyAplication.Operation
{
    public class ExerciseOperation
    {
        public NewDbContext _context;

        public ExerciseOperation(NewDbContext db)
        {
            _context = db;
        }

        public async Task<List<Product>> GetProducts()
        {
            var product = await _context.Products.AsNoTracking().ToListAsync(); ;

            return product;
        }

        public async Task<Product> GetProduct(int Idproduct)
        {
            var result = await _context.Products.FindAsync(Idproduct);

            return result;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _context.Products.AddAsync(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> UpdateProduct(ProductDTO productdto)
        {
            Product? product = await _context.Products.FindAsync(productdto.IdProduct);
            if (product != null)
            {
                product.NameProduct = productdto.NameProduct;
                product.StockProduct = productdto.StockProduct;
                product.PriseProduct = productdto.PriseProduct;

                await _context.SaveChangesAsync();
            }

            return true;
        }
        public async Task<bool> UpdateProduct(Product productdto)
        {
            Product? product = await _context.Products.FindAsync(productdto.IdProduct);
            if (product != null)
            {
                product.NameProduct = productdto.NameProduct;
                product.StockProduct = productdto.StockProduct;
                product.PriseProduct = productdto.PriseProduct;

                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            _context.Products.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
