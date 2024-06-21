using Microsoft.AspNetCore.Mvc;
using MyAplication.DTOs;
using MyAplication.models;
using MyAplication.Operation;

namespace MyAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private ExerciseOperation _opeProducts;

        private BillOperation _ope;

        public BillController(BillOperation op, ExerciseOperation ope)
        {
            _ope = op;

            _opeProducts = ope;
        }

        [HttpGet("GetBills")]
        public async Task<IActionResult> GetBills()
        {
            var operation = await _ope.GetBills();

            return Ok(operation);
        }

        [HttpGet("GetBill/{id}")]
        public async Task<IActionResult> GetBill(int id)
        {
            var operation = await _ope.GetBill(id);

            return Ok(operation);
        }

        [HttpPost("AddBill")]
        public async Task<IActionResult> CreateBill([FromBody] BillDTO billdto)
        {
            var opeProduct = await _opeProducts.GetProduct(billdto.IdProductBill);

            Bill result = new Bill()
            {
                TpriceProduct = opeProduct.PriseProduct,
                TotalSale = opeProduct.PriseProduct * billdto.QuantityProduct,
                IdSale = billdto.IdSale,
                IdProductBill = billdto.IdProductBill,
                QuantityProduct = billdto.QuantityProduct,
            };           

            opeProduct.StockProduct = opeProduct.StockProduct - billdto.QuantityProduct;
            
            if (opeProduct.StockProduct <= 0)
            {
                return BadRequest("Sapo Hpta te vas a acabar todo, masca mondá.");
            }

            await _opeProducts.UpdateProduct(opeProduct);

            var operation = await _ope.CreateBill(result);

            BillDTO2 result2 = new BillDTO2()
            {

                TpriceProduct = opeProduct.PriseProduct,
                TotalSale = opeProduct.PriseProduct * billdto.QuantityProduct,
                IdSale = billdto.IdSale,
                IdProductBill = billdto.IdProductBill,
                QuantityProduct = billdto.QuantityProduct,

            };
            
            return Ok(result2);
        }

        [HttpPut("UpdateBill/{id}")]
        public async Task<bool> UpdateBill(BillDTO billdto)
        {
            bool result = await _ope.UpdateBill(billdto);


            return result;
        }

        [HttpDelete("DeleteBill/{id}")]
        public async Task<bool> DeleteBill(int id)
        {
            bool result = await _ope.DeleteBill(id);

            return result;
        }

    }
}
