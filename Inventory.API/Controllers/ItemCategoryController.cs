using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventory.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCategoryController : ControllerBase
    {
        private readonly InventoryDbContext _context;

        public ItemCategoryController(InventoryDbContext context)
        {
            _context = context;
        }

        // GET: api/itemCategory
        [HttpGet]
        public async Task<IActionResult> RetriveAllItemCategories()
        {
            try
            {
                var itemCategories = await _context.ItemCategories.ToListAsync();

                if (itemCategories == null || itemCategories.Count == 0) return NotFound();
                return Ok(itemCategories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // GET: api/itemCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailItemCategory(int id)
        {
            try
            {
                var itemCategory = await _context.ItemCategories.FindAsync(id);

                if (itemCategory == null) return NotFound();
                return Ok(itemCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PUT: api/item/5
        [HttpPut("id")]
        public async Task<IActionResult> EditItemCategory(int id, ItemCategory itemCategory)
        {
            if (id != itemCategory.Id) return BadRequest("Invalid Record id");

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemCategoryExists(id))
                {
                    return Conflict("Item Category has been modified by another user");
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        private async Task<bool> ItemCategoryExists(int id)
        {
            return await _context.ItemCategories.AnyAsync(e => e.Id == id);
        }
    }
}