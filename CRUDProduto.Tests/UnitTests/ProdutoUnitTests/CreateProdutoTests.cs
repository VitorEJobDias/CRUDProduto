using CRUDProduto.Infrastructure.Persistence.Services;
using CRUDProduto.Core.Repositories;
using CRUDProduto.Tests.MockData;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Services;
using Moq;

namespace CRUDProduto.Tests.UnitTests.ProdutoUnitTests
{
    public class CreateProdutoTests
    {
        private readonly Mock<IProdutoRepository> _mockProdutoRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly IProdutoService _produtoService;

        public CreateProdutoTests()
        {
            _mockProdutoRepository = MockObjects.GetMockProdutoRepository();
            _mockUnitOfWork = MockObjects.GetMockUnitOfWork();

            _mockUnitOfWork.Setup(u => u.Produto).Returns(_mockProdutoRepository.Object);
            _produtoService = new ProdutoService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task CreateProduto_DeveCriarProdutoComSucesso()
        {
            var idCategoria = Guid.NewGuid();
            var produto = new Produto("Produto Teste", 1500.0m, idCategoria);

            _mockProdutoRepository.Setup(repo => repo.CreateProdutoAsync(It.IsAny<Produto>()))
                .Returns(Task.CompletedTask);

            await _produtoService.CreateProdutoAsync(produto);

            _mockProdutoRepository.Verify(repo => repo.CreateProdutoAsync(It.IsAny<Produto>()), Times.Once());
        }
    }
}
