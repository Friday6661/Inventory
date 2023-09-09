// using Inventory.API.Data;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;

// namespace Inventory.API.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ItemsController : ControllerBase
//     {
//         private readonly InventoryDbContext _context;

//         public ItemsController(InventoryDbContext context)
//         {
//             _context = context;
//         }

//         // Get: api/Items
//         [HttpGet]
//         public async Task<IActionResult> RetriveAllItems()
//         {
//             try
//             {
//                 var items = await _context.Items.Where(i => i.IsDeleted != true).ToListAsync();

//                 if (items == null || items.Count == 0) return NotFound();
//                 return Ok(items);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Errors: {ex.Message}");
//             }
//         }

//         // Get: api/Item/5
//         [HttpGet("{id}")]
//         public async Task<IActionResult> DetailItem(int id)
//         {
//             try
//             {
//                 var item = await _context.Items.FindAsync(id);
                
//                 if (item == null) return NotFound();
//                 return Ok(item);
//             }
//             catch (Exception ex)
//             {
//                 return StatusCode(500, $"Errors: {ex.Message}");
//             }
//         }

//         // PUT: api/Item/5
//         [HttpPut("{id}")]
//         public async Task<IActionResult> EditItem(int id, Item item)
//         {
//             if (id != item.Id)
//             {
//                 return BadRequest("Invalid Record Id");
//             }
//             _context.Entry(item).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!ItemExists(id))
//                 {
//                     return Conflict("Item has been modified by another user. Please refresh and try again.");
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//             return NoContent();
//         }

//         // POST: api/Items
//         [HttpPost]
//         public async Task<IActionResult> CreateItem(Item item)
//         {
//             _context.Items.Add(item);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("DetailItem", new { id = item.Id }, item);
//         }

//         [HttpPatch]
//         public async Task<IActionResult> SoftDeleteItem(int id, [FromBody] SoftDeleteRequest softDeleteRequest)
//         {
//             try
//             {
//                 var item = await _context.Items.FindAsync(id);

//                 if (item == null) return NotFound();
//                 item.IsDeleted = softDeleteRequest.IsDeleted;
//                 await _context.SaveChangesAsync();
//                 return NoContent();
//             }
//             catch (System.Exception)
//             {
                
//                 throw;
//             }
//         }

//         private bool ItemExists(int id)
//         {
//             return _context.Items.Any(e => e.Id == id);
//         }
//     }

//     public class SoftDeleteRequest
//     {
//         public bool IsDeleted { get; set; }
//     }
// }