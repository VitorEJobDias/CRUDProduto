using CRUDProduto.Core.Repositories;
using CRUDProduto.Core.Services;
using CRUDProduto.Core.Entities;

namespace CRUDProduto.Infrastructure.Persistence.Services
{
    internal class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Produto?>> GetProdutosAsync() =>
            await _unitOfWork.Produto.GetProdutosAsync();

        public async Task<Produto?> GetProdutoByIdAsync(Guid id) =>
            await _unitOfWork.Produto.GetProdutoByIdAsync(id);

        public async Task CreateProdutoAsync(Produto produto)
        {
            await _unitOfWork.Produto.CreateProdutoAsync(produto);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProdutoAsync(Guid id)
        {
            await _unitOfWork.Produto.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateProdutoAsync(Produto produto)
        {
            _unitOfWork.Produto.UpdateProduto(produto);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
