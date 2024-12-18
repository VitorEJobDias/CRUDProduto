using CRUDProduto.Application.Interfaces.Services;
using CRUDProduto.Core.Repositories;
using CRUDProduto.Core.Services;
using Moq;

namespace CRUDProduto.Tests.MockData
{
    public static class MockObjects
    {
        public static Mock<IProdutoRepository> GetMockProdutoRepository()
        {
            return new Mock<IProdutoRepository>();
        }

        public static Mock<ICategoriaRepository> GetMockCategoriaRepository()
        {
            return new Mock<ICategoriaRepository>();
        }

        public static Mock<IUnitOfWork> GetMockUnitOfWork()
        {
            return new Mock<IUnitOfWork>();
        }

        public static Mock<IProdutoService> GetMockProdutoService()
        {
            return new Mock<IProdutoService>();
        }

        public static Mock<ICategoriaService> GetMockCategoriaService()
        {
            return new Mock<ICategoriaService>();
        }

        public static Mock<IProdutoAppService> GetMockProdutoAppService()
        {
            return new Mock<IProdutoAppService>();
        }

        public static Mock<ICategoriaAppService> GetMockCategoriaAppService()
        {
            return new Mock<ICategoriaAppService>();
        }
    }
}
