using Microsoft.AspNetCore.Mvc;
using MyAplication.Operation;
using MyAplication.DTOs;
using MyAplication.models;

namespace MyAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {         

            private ExerciseOperation _ope;
            public ProductController(ExerciseOperation op)
            {
                _ope = op;
            }


        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var operation = await _ope.GetProducts();
            return Ok(operation);
        }

        [HttpGet("GetProduct/{id}")]
        public async Task<IActionResult> Getproduct(int id)
        {
            var operation = await _ope.GetProduct(id);
            
            return Ok(operation);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productdto)
        {
            Product result = new Product()
            {
                NameProduct = productdto.NameProduct,
                PriseProduct = productdto.PriseProduct,
                StockProduct = productdto.StockProduct,
            };

            var operation = await _ope.CreateProduct(result);

            return Ok(operation);
        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<bool> UpdateProduct(ProductDTO productdto)
        {

            bool result = await _ope.UpdateProduct(productdto);

            return result;
        }


        [HttpDelete("DeleteProduct/{id}")]
        public async Task<bool> DeleteProduct(int id)
        {
            bool result = await _ope.DeleteProduct(id);

            return result;
        }
    }
}
