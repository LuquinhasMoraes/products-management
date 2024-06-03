using ProductManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Repositories
{
    public interface IFornecedorRepository
    {
        Task<Fornecedor> GetByIdAsync(int id);
        Task<IEnumerable<Fornecedor>> ListAsync();
        Task AddAsync(Fornecedor fornecedor);
        Task UpdateAsync(Fornecedor fornecedor);
        Task DeleteAsync(int id);
    }
}
