using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<ProdutoDTO> GetByIdAsync(int id);
        Task<IEnumerable<ProdutoDTO>> ListAsync(string descricao = null, int page = 1, int pageSize = 10);
        Task AddAsync(ProdutoDTO produto);
        Task UpdateAsync(ProdutoDTO produto);
        Task DeleteAsync(int id);
    }
}
