using AutoMapper;
using ProductManagement.Application.DTOs;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services
{
    public class FornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }

        public async Task<FornecedorDTO> GetByIdAsync(int id)
        {
            var fornecedor = await _fornecedorRepository.GetByIdAsync(id);
            return _mapper.Map<FornecedorDTO>(fornecedor);
        }

        public async Task<IEnumerable<FornecedorDTO>> ListAsync()
        {
            var fornecedor = await _fornecedorRepository.ListAsync();
            return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedor);
        }

        public async Task AddAsync(FornecedorDTO fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            await _fornecedorRepository.AddAsync(fornecedor);
        }

        public async Task UpdateAsync(FornecedorDTO fornecedorDto)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);
            
            await _fornecedorRepository.UpdateAsync(fornecedor);
        }

        public async Task DeleteAsync(int id)
        {
            await _fornecedorRepository.DeleteAsync(id);
        }
    }
}
