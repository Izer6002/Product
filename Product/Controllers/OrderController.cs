using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Context;
using Product.Models;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ProductContext db;

        public OrderController(ProductContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetAll()
        {
            return await this.db.Order.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int ID)
        {
            OrderModel order = await this.db.Order.FirstOrDefaultAsync(x => x.ID == ID);

            if (order == null)
            {
                return NotFound();
            }

            return new ObjectResult(order);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ProductModel>> Create(OrderModel order)
        {
            if (order == null)
                return this.BadRequest();

            db.Order.Add(order);

            await this.db.SaveChangesAsync();

            return Ok(order);
        }
    }
}
