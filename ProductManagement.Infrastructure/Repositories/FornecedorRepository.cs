using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ProductManagementDbContext _context;

        public FornecedorRepository(ProductManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Fornecedor> GetByIdAsync(int id)
        {
            return await _context.Fornecedores.FindAsync(id);
        }

        public async Task<IEnumerable<Fornecedor>> ListAsync()
        {
            return await _context.Fornecedores.ToListAsync();
        }

        public async Task AddAsync(Fornecedor fornecedor)
        {
            await _context.Fornecedores.AddAsync(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Fornecedor fornecedor)
        {
            _context.Fornecedores.Update(fornecedor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var fornecedor = await GetByIdAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
