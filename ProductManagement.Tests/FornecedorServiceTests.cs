using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using ProductManagement.Infrastructure.Repositories;
using Xunit;

namespace ProductManagement.Tests.Services
{
    public class FornecedorServiceTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IFornecedorRepository> _mockFornecedorRepository;
        private readonly FornecedorService _fornecedorService;

        public FornecedorServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            });

            _mapper = config.CreateMapper();
            _mockFornecedorRepository = new Mock<IFornecedorRepository>();
            _fornecedorService = new FornecedorService(_mockFornecedorRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetAllFornecedoresAsync_ReturnsAllFornecedores()
        {
            var fornecedores = new List<Fornecedor>
            {
                new Fornecedor { Id = 1, Descricao = "Fornecedor 1", Cnpj = "123456789"},
                new Fornecedor { Id = 2, Descricao = "Fornecedor 2", Cnpj = "987654321" }
            };

            _mockFornecedorRepository.Setup(repo => repo.ListAsync()).ReturnsAsync(fornecedores);

            var result = await _fornecedorService.ListAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetFornecedorByIdAsync_ReturnsFornecedor_WhenFornecedorExists()
        {
            var fornecedor = new Fornecedor { Id = 1, Descricao = "Fornecedor 1", Cnpj = "123456789" };
            _mockFornecedorRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(fornecedor);

            var result = await _fornecedorService.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task AddFornecedorAsync_AddsFornecedor()
        {
            var fornecedorDto = new FornecedorDTO { Id = 1, Descricao = "Fornecedor 1", Cnpj = "123456789" };
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorDto);

            await _fornecedorService.AddAsync(fornecedorDto);

            _mockFornecedorRepository.Verify(repo => repo.AddAsync(It.IsAny<Fornecedor>()), Times.Once);
        }

    }
}
