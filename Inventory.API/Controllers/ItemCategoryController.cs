using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Inventory.API.Services.Models;
using Inventory.API.Services.Models.ItemCategory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = false)]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IItemCategoriesRepository _itemCategoriesRepository;

        public ItemCategoryController(IMapper mapper, IItemCategoriesRepository itemCategoriesRepository)
        {
            _mapper = mapper;
            _itemCategoriesRepository = itemCategoriesRepository;
        }

        // GET: api/itemCategory
        [HttpGet("GetAll")]
        public async Task<IActionResult> RetriveAllItemCategories(bool isDeleted)
        {
            try
            {
                var itemCategories = await _itemCategoriesRepository.GetAllAsync();

                if (isDeleted)
                {
                    itemCategories = itemCategories.Where(ic => ic.IsDeleted).ToList();
                }
                else
                {
                    itemCategories = itemCategories.Where(ic => !ic.IsDeleted).ToList();
                }
                
                var records = _mapper.Map<List<GetItemCategoryDTO>>(itemCategories);
                return Ok(records);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // GET: api/ItemCategory/Paging
        [HttpGet]
        public async Task<IActionResult> GetPagedItemCategory([FromQuery] QueryParameters queryParameters)
        {
            var pagedItemCategoriesResult = await _itemCategoriesRepository.GetAllAsync<GetItemCategoryDTO>(queryParameters);
            return Ok(pagedItemCategoriesResult);
        }

        // GET: api/itemCategory/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailItemCategory(int id)
        {
            try
            {
                var itemCategory = await _itemCategoriesRepository.GetDetails(id);
                
                if (itemCategory == null)
                {
                    return NotFound();
                }
                var itemCategoryDTO = _mapper.Map<ItemCategoryDTO>(itemCategory);
                return Ok(itemCategoryDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PUT: api/item/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditItemCategory(int id, UpdateItemCategoryDTO updateItemCategoryDTO)
        {
            if (id != updateItemCategoryDTO.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var itemCategory = await _itemCategoriesRepository.GetAsync(id);
            if (itemCategory == null)
            {
                throw new NotFoundException(nameof(EditItemCategory), id);
            }

            _mapper.Map(updateItemCategoryDTO, itemCategory);
            try
            {
                await _itemCategoriesRepository.UpdateAsync(itemCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ItemCategoryExists(id))
                {
                    throw new NotFoundException(nameof(ItemCategoryExists), id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/ItemCategory
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateItemCategory(CreateItemCategoryDTO createItemCategoryDTO)
        {
            var itemCategory = _mapper.Map<ItemCategory>(createItemCategoryDTO);
            await _itemCategoriesRepository.AddAsync(itemCategory);
            return CreatedAtAction("DetailItemCategory", new {id = itemCategory.Id }, itemCategory);
        }

        // DELETE: api/itemcategories/5
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteItemCategory(int id)
        {
            var itemCategory = await _itemCategoriesRepository.GetAsync(id);
            if (itemCategory == null)
            {
                throw new NotFoundException(nameof(DeleteItemCategory), id);
            }
            await _itemCategoriesRepository.SoftDeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> ItemCategoryExists(int id)
        {
            return await _itemCategoriesRepository.Exists(id);
        }
    }
}