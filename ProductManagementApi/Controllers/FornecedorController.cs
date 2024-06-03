using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorService _fornecedorService;

        public FornecedorController(FornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _fornecedorService.GetByIdAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var fornecedores = await _fornecedorService.ListAsync();
            return Ok(fornecedores);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FornecedorDTO fornecedorDto)
        {
            await _fornecedorService.AddAsync(fornecedorDto);
            return CreatedAtAction(nameof(GetById), new { id = fornecedorDto.Id }, fornecedorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FornecedorDTO fornecedorDto)
        {
            if (id != fornecedorDto.Id)
            {
                return BadRequest();
            }

            await _fornecedorService.UpdateAsync(fornecedorDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fornecedorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
