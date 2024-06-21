using MyAplication.models;
using Microsoft.EntityFrameworkCore;
using MyAplication.DTOs;

namespace MyAplication.Operation
{
    public class BillOperation
    {
        public NewDbContext _context;

        public BillOperation(NewDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bill>> GetBills()
        {
            var bill = await _context.Bills.AsNoTracking().ToListAsync();
            
            return bill;
        }
        
        public async Task<Bill> GetBill(int IdBill)
        {
            var result = await _context.Bills.FindAsync(IdBill);

            return result;
        }

        public async Task<Bill> CreateBill(Bill bill)
        {
            var result = await _context.Bills.AddAsync(bill);

            await _context.SaveChangesAsync();

            return bill;
        }

        public async Task<bool> UpdateBill(BillDTO billdto)
        {
            Bill? bill = await _context.Bills.FindAsync(billdto.IdSale);
            if (bill != null) 
            {
                bill.IdProductBill = billdto.IdProductBill;
                bill.QuantityProduct = billdto.QuantityProduct;

                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<bool> DeleteBill(int id)
        {
            var result = await _context.Bills.FindAsync(id);
            if(result == null)
            {
                return false;
            }
            _context.Bills.Remove(result);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
