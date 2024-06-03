using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ProductManagementDbContext _context;

        public ProdutoRepository(ProductManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id && p.Situacao);
        }

        public async Task<IEnumerable<Produto>> ListAsync(string descricao = null, int page = 1, int pageSize = 10)
        {
            var query = _context.Produtos.AsQueryable();

            query = query.Where(p => p.Situacao == true);

            if (!string.IsNullOrWhiteSpace(descricao))
            {
                query = query.Where(p => p.Descricao.Contains(descricao) && p.Situacao == true);
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task AddAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var produto = await GetByIdAsync(id);
            if (produto != null)
            {
                produto.Situacao = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
