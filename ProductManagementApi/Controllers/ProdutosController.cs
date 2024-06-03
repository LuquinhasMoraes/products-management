using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Services;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _produtoService.GetByIdAsync(id);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }

    [HttpGet]
    public async Task<IActionResult> List([FromQuery] string descricao, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var produtos = await _produtoService.ListAsync(descricao, page, pageSize);
        return Ok(produtos);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ProdutoDTO produtoDto)
    {
        await _produtoService.AddAsync(produtoDto);
        return CreatedAtAction(nameof(GetById), new { id = produtoDto.Id }, produtoDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProdutoDTO produtoDto)
    {
        if (id != produtoDto.Id)
        {
            return BadRequest();
        }

        await _produtoService.UpdateAsync(produtoDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _produtoService.DeleteAsync(id);
        return NoContent();
    }
}
