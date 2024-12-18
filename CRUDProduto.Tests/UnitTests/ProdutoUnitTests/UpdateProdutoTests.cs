using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Repositories;
using CRUDProduto.Core.Services;
using CRUDProduto.Infrastructure.Persistence.Services;
using CRUDProduto.Tests.MockData;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDProduto.Tests.UnitTests.ProdutoUnitTests
{
    public class UpdateProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IProdutoService _produtoService;

        public UpdateProdutoTests()
        {
            _mockProdutoRepository = MockObjects.GetMockProdutoRepository();
            _mockUnitOfWork = MockObjects.GetMockUnitOfWork();

            _mockUnitOfWork.Setup(u => u.Produto).Returns(_mockProdutoRepository.Object);
            _produtoService = new ProdutoService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task UpdateProduto_DeveAtualizarProdutoComSucesso()
        {
            // Arrange
            var idCategoria = Guid.NewGuid();
            var produto = new Produto("Produto Teste", 100.0m, idCategoria);

            _mockProdutoRepository.Setup(repo => repo.CreateProdutoAsync(It.IsAny<Produto>()))
                .Returns(Task.CompletedTask);  

            _mockProdutoRepository.Setup(repo => repo.UpdateProduto(It.IsAny<Produto>())).Verifiable();

            // Act
            await _produtoService.UpdateProdutoAsync(produto);

            // Assert
            _mockProdutoRepository.Verify(repo => repo.UpdateProduto(It.IsAny<Produto>()), Times.Once);
        }
    }
}
