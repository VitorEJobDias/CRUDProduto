using CRUDProduto.Core.Repositories;

namespace CRUDProduto.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CRUDProdutoContext _context;
        private IProdutoRepository _produtoRepository;
        private ICategoriaRepository _categoriaRepository;

        public UnitOfWork(CRUDProdutoContext context)
        {
            _context = context;
        }

        public ICategoriaRepository Categoria
        {
            get
            {
                if (_categoriaRepository == null)
                {
                    _categoriaRepository = new CategoriaRepository(_context);
                }
                return _categoriaRepository;
            }
        }

        public IProdutoRepository Produto
        {
            get
            {
                if( _produtoRepository == null)
                {
                    _produtoRepository = new ProdutoRepository(_context);
                }
                return _produtoRepository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
