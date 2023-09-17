using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Inventory.API.Services.Models;
using Inventory.API.Services.Models.Item;
using Inventory.API.Services.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = false)]
    public class ItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemRepository _itemRepository;

        public ItemsController(IMapper mapper, IItemRepository itemRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }

        // Get: api/Items
        [HttpGet("GetAll")]
        public async Task<IActionResult> RetriveAllItems(bool isDeleted)
        {
            try
            {
                var items = await _itemRepository.GetAllAsync();
                if (isDeleted)
                {
                    items = items.Where(i => i.IsDeleted == true).ToList();
                }
                else
                {
                    items = items.Where(i => i.IsDeleted == false).ToList();
                }

                var records = _mapper.Map<List<GetItemDTO>>(items);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedItem([FromQuery] QueryParameters queryParameters)
        {
            var pagedItemsResult = await _itemRepository.GetAllAsync<GetItemDTO>(queryParameters);
            return Ok(pagedItemsResult);
        }

        // Get: api/Item/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailItem(int id)
        {
            try
            {
                var item = await _itemRepository.GetDetails(id);
                if (item == null)
                {
                    throw new NotFoundException(nameof(DetailItem), id);
                }
                
                var itemDTO = _mapper.Map<ItemDTO>(item);
                return Ok(itemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PUT: api/Item/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditItem(int id, UpdateItemDTO updateItemDTO)
        {
            if (id != updateItemDTO.Id)
            {
                return BadRequest("Invalid Record Id");
            }
            
            var item = await _itemRepository.GetAsync(id);
            if (item == null)
            {
                throw new NotFoundException(nameof(EditItem), id);
            }

            _mapper.Map(updateItemDTO, item);
            try
            {
                await _itemRepository.EditItemAsync(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemExists(id))
                {
                    throw new NotFoundException(nameof(ItemExists), id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/Item
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateItem(CreateItemDTO createItemDTO)
        {
            var item = _mapper.Map<Item>(createItemDTO);
            await _itemRepository.AddItemAndUpdateWarehouse(item);
            return CreatedAtAction(nameof(DetailItem), new {id = item.Id}, item);
        }

        // DELETE: api/Item/5
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItem(int id)
        {
            try
            {
                var item = await _itemRepository.GetAsync(id);

                if (item == null)
                {/////
                    throw new NotFoundException(nameof(DeleteItem), id);
                }
                await _itemRepository.SoftDeleteAndUpdateWarehouse(item);
                return NoContent();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        private async Task<bool> ItemExists(int id)
        {
            return await _itemRepository.Exists(id);
        }
    }
}