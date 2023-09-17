using AutoMapper;
using Inventory.API.Data;
using Inventory.API.Services.Contracts;
using Inventory.API.Services.Exceptions;
using Inventory.API.Services.Models;
using Inventory.API.Services.Models.Supplier;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = false)]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;

        public SupplierController(IMapper mapper, ISupplierRepository supplierRepository)
        {
            _mapper = mapper;
            _supplierRepository = supplierRepository;
        }

        // GET: api/supplier
        [HttpGet("GetAll")]
        public async Task<IActionResult> RetriveAllSuppliers(bool isDeleted)
        {
            try
            {
                var suppliers = await _supplierRepository.GetAllAsync();
                if (isDeleted)
                {
                    suppliers = suppliers.Where(s => s.IsDeleted).ToList();
                }
                else
                {
                    suppliers = suppliers.Where(s => !s.IsDeleted).ToList();
                }

                var records = _mapper.Map<List<GetSupplierDTO>>(suppliers);
                return Ok(records);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // GET: api/suppliers/Paging
        [HttpGet]
        public async Task<IActionResult> GetPagedSuppliers(QueryParameters queryParameters)
        {
            var pagedSuppliersResult = await _supplierRepository.GetAllAsync<GetSupplierDTO>(queryParameters);
            return Ok(pagedSuppliersResult);
        }

        // GET: api/suppliers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> DetailSupplier(int id)
        {
            try
            {
                var supplier = await _supplierRepository.GetDetails(id);
                if (supplier == null)
                {
                    throw new NotFoundException(nameof(DetailSupplier), id);
                }
                var supplierDTO = _mapper.Map<SupplierDTO>(supplier);
                return Ok(supplierDTO);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Errors: {ex.Message}");
            }
        }

        // PUT: api/suppliers/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditSupplier(int id, UpdateSupplierDTO updateSupplierDTO)
        {
            if (id != updateSupplierDTO.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            var supplier = await _supplierRepository.GetAsync(id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(EditSupplier), id);
            }

            _mapper.Map(updateSupplierDTO, supplier);
            try
            {
                await _supplierRepository.UpdateAsync(supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await SupplierExists(id))
                {
                    throw new NotFoundException(nameof(SupplierExists), id);
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST: api/suppliers/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDTO createSupplierDTO)
        {
            var supplier = _mapper.Map<Supplier>(createSupplierDTO);
            await _supplierRepository.AddAsync(supplier);
            return CreatedAtAction("DetailSupplier", new {id = supplier.Id}, supplier);
        }

        // DELETE: api/suppliers/5
        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = _supplierRepository.GetAsync(id);
            if (supplier == null)
            {
                throw new NotFoundException(nameof(DeleteSupplier), id);
            }
            await _supplierRepository.SoftDeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> SupplierExists(int id)
        {
            return await _supplierRepository.Exists(id);
        }
    }
}