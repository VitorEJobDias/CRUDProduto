using CRUDProduto.Core.Dtos;

namespace CRUDProduto.Application.Interfaces.Services
{
    public interface IProdutoAppService
    {
        Task CreateProdutoAsync(ProdutoDTO produto);
        Task DeleteProdutoAsync(Guid id);
        Task UpdateProdutoAsync(ProdutoDTO produto);
        Task<IEnumerable<ProdutoDTO>> GetProdutosAsync();
        Task<ProdutoDTO> GetProdutoByIdAsync(Guid id);
    }
}
