using AutoMapper;
using Moq;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Services;
using ProductManagement.Domain.Entities;
using ProductManagement.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProductManagement.Tests.Services
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly IMapper _mapper;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTests()
        {
            _mockProdutoRepository = new Mock<IProdutoRepository>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Produto, ProdutoDTO>();
                cfg.CreateMap<ProdutoDTO, Produto>();
            });
            _mapper = config.CreateMapper();
            _produtoService = new ProdutoService(_mockProdutoRepository.Object, _mapper);
        }

        [Fact]
        public async Task GetByIdAsync_ReturnsProduto_WhenProdutoExists()
        {
            // Arrange
            int produtoId = 1;
            var produto = new Produto { Id = produtoId, Descricao = "Produto 1", DataFabricacao = DateTime.Now, DataValidade = DateTime.Now.AddDays(30), Situacao = true, FornecedorId = 1 };
            _mockProdutoRepository.Setup(repo => repo.GetByIdAsync(produtoId)).ReturnsAsync(produto);

            // Act
            var result = await _produtoService.GetByIdAsync(produtoId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(produtoId, result.Id);
        }

        [Fact]
        public async Task ListAsync_ReturnsProdutos_WhenProdutosExist()
        {
            // Arrange
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Descricao = "Produto 1", DataFabricacao = DateTime.Now, DataValidade = DateTime.Now.AddDays(30), Situacao = true, FornecedorId = 1 },
                new Produto { Id = 2, Descricao = "Produto 2", DataFabricacao = DateTime.Now, DataValidade = DateTime.Now.AddDays(50), Situacao = true, FornecedorId = 2 }
            };

            _mockProdutoRepository.Setup(repo => repo.ListAsync(null, 1, 10)).ReturnsAsync(produtos);

            // Act
            var result = await _produtoService.ListAsync(null, 1, 10);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(produtos.Count, result.Count());
        }

        [Fact]
        public async Task AddAsync_ThrowsException_OndeDataFabricacaoMaiorOuIgualDataValidade()
        {
            // Arrange
            var produtoDto = new ProdutoDTO { Id = 1, Descricao = "Produto 1", DataFabricacao = DateTime.Now, DataValidade = DateTime.Now.AddDays(-1), Situacao = true, FornecedorId = 1 };

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => _produtoService.AddAsync(produtoDto));
        }

        [Fact]
        public async Task UpdateAsync_ThrowsException_OndeDataFabricacaoMaiorOuIgualDataValidade()
        {
            var produtoDto = new ProdutoDTO { Id = 1, Descricao = "Produto Teste", DataFabricacao = DateTime.Now, DataValidade = DateTime.Now.AddDays(-1) };
            await Assert.ThrowsAsync<Exception>(() => _produtoService.UpdateAsync(produtoDto));
        }

        [Fact]
        public async Task DeleteAsync_RemovesProduto_WhenProdutoExists()
        {
            // Arrange
            int produtoId = 1;
            _mockProdutoRepository.Setup(repo => repo.DeleteAsync(produtoId)).Returns(Task.CompletedTask);

            // Act
            await _produtoService.DeleteAsync(produtoId);

            // Assert
            _mockProdutoRepository.Verify(repo => repo.DeleteAsync(produtoId), Times.Once);
        }
    }
}
