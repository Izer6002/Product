using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product.Context;
using Product.Models;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductContext db;

        public ProductController(ProductContext db)
        {
            this.db = db;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            return await this.db.Product.ToListAsync();
        }

        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductModel>> GetById(int ID)
        {
            ProductModel product = await this.db.Product.FirstOrDefaultAsync(x => x.ID == ID);

            if (product == null)
            {
                return NotFound();
            }

            return new ObjectResult(product);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<ProductModel>> Create(ProductModel product)
        {
            if (product == null)
                return this.BadRequest();

            db.Product.Add(product);

            await this.db.SaveChangesAsync();

            return Ok(product);
        }


    }
}
