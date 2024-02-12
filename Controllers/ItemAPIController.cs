using ElectronicsShop.Data;
using ElectronicsShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    
    
    
    public class ItemAPIController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET ALL
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return Ok(_context.Items);
        }
        
        
        //GET BY ID
        [HttpGet("id", Name ="GetItem")]
        public ActionResult GetItem(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        //CREATE ITEM
        [HttpPost]
        public ActionResult<Item> CreateItem([FromBody] Item item)
        {
            if(_context.Items.FirstOrDefault(x => x.Name.ToLower() == item.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Item arleady exists!");
            }
            if(item == null)
            {
                return BadRequest(item);
            }
            if (item.Id > 0)
            {
                return BadRequest(item);
            }
            Item model = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
            _context.Items.Add(model);
            _context.SaveChanges();

            return CreatedAtRoute("GetItem", new { id = item.Id }, item);
        }
        //DELETE ITEM BY ID
        [HttpDelete]
        public IActionResult DeleteItem(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var item = _context.Items.FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Items.Remove(item);
            _context.SaveChanges();
            return Ok();
        }
        //EDIT ITEM BY ID
        [HttpPut("id", Name = "EditItem")]
        public IActionResult EditItem(int id, [FromBody] Item item)
        {
            if (item == null || id != item.Id)
            {
                return BadRequest(item);
            }
            Item model = new()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };

            _context.Items.Update(model);
            _context.SaveChanges();

            return Ok();
        }
    }
}
