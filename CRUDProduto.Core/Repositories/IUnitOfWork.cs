namespace CRUDProduto.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        Task<int> SaveChangesAsync();
    }
}
