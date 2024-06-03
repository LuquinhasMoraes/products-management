using ProductManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Repositories
{
    public interface IProdutoRepository
    {
        Task<Produto> GetByIdAsync(int id);
        Task<IEnumerable<Produto>> ListAsync(string descricao = null, int page = 1, int pageSize = 10);
        Task AddAsync(Produto produto);
        Task UpdateAsync(Produto produto);
        Task DeleteAsync(int id);
    }
}
