namespace CRUDProduto.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProdutoRepository Produto { get; }
        ICategoriaRepository Categoria { get; }

        Task<int> SaveChangesAsync();
    }
}
