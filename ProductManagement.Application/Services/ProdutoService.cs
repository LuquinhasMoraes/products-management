using AutoMapper;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> GetByIdAsync(int id)
        {
            var produto = await _produtoRepository.GetByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }

        public async Task<IEnumerable<ProdutoDTO>> ListAsync(string descricao, int page, int pageSize)
        {
            var produtos = await _produtoRepository.ListAsync(descricao, page, pageSize);
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task AddAsync(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("Data de fabricação não pode ser maior ou igual à data de validade.");
            }

            await _produtoRepository.AddAsync(produto);
        }

        public async Task UpdateAsync(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            // Validações
            if (produto.DataFabricacao >= produto.DataValidade)
            {
                throw new ArgumentException("Data de fabricação não pode ser maior ou igual à data de validade.");
            }

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(int id)
        {
            await _produtoRepository.DeleteAsync(id);
        }
    }
}
