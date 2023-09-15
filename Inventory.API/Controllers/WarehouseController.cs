using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Inventory.API.Services.Models.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IMapper mapper, IWarehouseRepository warehouseRepository)
        {
            _mapper = mapper;
            _warehouseRepository = warehouseRepository;
        }

        // GET: api/warehouse
        [HttpGet]
        public async Task<IActionResult> RetriveAllWarehouse(bool isDeleted)
        {
            try
            {
                var warehouses = await _warehouseRepository.GetAllAsync();
                if (isDeleted)
                {
                    warehouses = warehouses.Where(w => w.IsDeleted).ToList();
                }
                else
                {
                    warehouses = warehouses.Where(w => !w.IsDeleted).ToList();
                }

                var records = _mapper.Map<IList<GetWarehouseDTO>>(warehouses);
                return Ok(records);
            }
            catch (System.Exception ex)
            {
                
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // GET: api/warehouse/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailWarehouse(int id)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetDetails(id);
                if (warehouse == null)
                {
                    throw new NotFoundException(nameof(DetailWarehouse), id);
                }
                var warehouseDTO = _mapper.Map<WarehouseDTO>(warehouse);
                return Ok(warehouseDTO);

            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PUT: api/warehouse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditWarehouse(int id, UpdateWarehouseDTO updateWarehouseDTO)
        {
            if (id != updateWarehouseDTO.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var warehouse = await _warehouseRepository.GetAsync(id);
            if (warehouse == null)
            {
                throw new NotFoundException(nameof(EditWarehouse), id);
            }
            
            _mapper.Map(updateWarehouseDTO, warehouse);
            try
            {
                await _warehouseRepository.UpdateAsync(warehouse);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WarehouseExists(id))
                {
                    throw new NotFoundException(nameof(WarehouseExists), id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/warehouse
        [HttpPost]
        public async Task<IActionResult> CreateWarehouse(CreateWarehouseDTO createWarehouseDTO)
        {
            try
            {
                var warehouse = _mapper.Map<Warehouse>(createWarehouseDTO);
                await _warehouseRepository.AddAsync(warehouse);
                return CreatedAtAction(nameof(DetailWarehouse), new {id = warehouse.Id}, warehouse);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PATCH: api/Warehouse/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> DeleteWarehouse(int id)
        {
            try
            {
                var warehouse = await _warehouseRepository.GetAsync(id);
                if (warehouse == null)
                {
                    throw new NotFoundException(nameof(DeleteWarehouse), id);
                }

                await _warehouseRepository.SoftDelete(id);
                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        private async Task<bool> WarehouseExists(int id)
        {
            return await _warehouseRepository.Exists(id);
        }
    }
}