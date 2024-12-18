using CRUDProduto.Infrastructure.Persistence.Services;
using CRUDProduto.Core.Repositories;
using CRUDProduto.Tests.MockData;
using CRUDProduto.Core.Services;
using Moq;

namespace CRUDProduto.Tests.UnitTests.ProdutoUnitTests
{
    public class DeleteProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IProdutoService _produtoService;

        public DeleteProdutoTests()
        {
            _mockProdutoRepository = MockObjects.GetMockProdutoRepository();
            _mockUnitOfWork = MockObjects.GetMockUnitOfWork();

            _mockUnitOfWork.Setup(u => u.Produto).Returns(_mockProdutoRepository.Object);
            _produtoService = new ProdutoService(_mockUnitOfWork.Object);
        }


        [Fact]
        public async Task DeleteProduto_DeveExcluirProdutoComSucesso()
        {
            // Arrange
            var produtoId = Guid.NewGuid();

            _mockProdutoRepository.Setup(repo => repo.DeleteAsync(It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            // Act
            await _produtoService.DeleteProdutoAsync(produtoId);

            // Assert
            _mockProdutoRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
