using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICrudWithEntityFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleItemsController : ControllerBase
    {
        private static List<SaleItems> items = new List<SaleItems> {
                new SaleItems
                {
                    Id = 1,
                    Title = "Fjallraven - Foldsack No. 1 Backpack, Fits 15 Laptops",
                    Price = 109.95,
                    Category = "men's clothing",
                    Description = "Your perfect pack for everyday use and walks in the forest. Stash your laptop (up to 15 inches) in the padded sleeve, your everyday",
                },
                new SaleItems
                {
                    Id = 2,
                    Title = "Mens Casual Premium Slim Fit T-Shirts ",
                    Price = 22.3,
                    Category = "men's clothing",
                    Description = "Slim-fitting style, contrast raglan long sleeve, three-button henley placket, light weight & soft fabric for breathable and comfortable wearing. And Solid stitched shirts with round neck made for durability and a great fit for casual fashion wear and diehard baseball fans. The Henley style round neckline includes a three-button placket.",
                }
            };
        private readonly DataContext dataContext;

        public SaleItemsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<SaleItems>>> Get()
        {
            return Ok(await dataContext.SaleItems.ToListAsync() );
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItems>> Get(int id)
        {
            var item = await dataContext.SaleItems.FindAsync(id);
            if(item == null)
            {
                return BadRequest("Item not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<SaleItems>>> AddItem(SaleItems saleItems)
        {
            dataContext.SaleItems.Add(saleItems);
            dataContext.SaveChanges();
            return Ok(await dataContext.SaleItems.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SaleItems>>> UpdateItem(SaleItems request)
        {
            var dbItem = await dataContext.SaleItems.FindAsync(request.Id);
                
            if (dbItem == null)
            {
                return BadRequest("Item not found");
            }
            dbItem.Title = request.Title;
            dbItem.Price = request.Price;
            dbItem.Category = request.Category;
            dbItem.Description = request.Description;

            await dataContext.SaveChangesAsync();

            return Ok(await dataContext.SaleItems.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SaleItems>>> Delete(int id)
        {
            var dbItem = await dataContext.SaleItems.FindAsync(id);
            if (dbItem == null)
            {
                return BadRequest("Item not found");
            }
            dataContext.SaleItems.Remove(dbItem);
            await dataContext.SaveChangesAsync();
            return Ok(await dataContext.SaleItems.ToListAsync());
        }
    }
}
