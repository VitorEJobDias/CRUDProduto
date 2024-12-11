using CRUDProduto.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Services;

namespace CRUDProduto.Infrastructure.Persistence.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoriaAsync(Categoria categoria)
        {
            await _unitOfWork.Categoria.CreateCategoriaAsync(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategoriaAsync(Guid id)
        {
            await _unitOfWork.Categoria.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCategoriaAsync(Categoria categoria)
        {
            _unitOfWork.Categoria.UpdateCategoria(categoria);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria?>> GetCategoriasAsync() =>
            await _unitOfWork.Categoria.GetCategoriasAsync(c => c.Active, c => c.Include(p => p.Produtos));

        public async Task<Categoria?> GetCategoriaByIdAsync(Guid id) =>
            await _unitOfWork.Categoria.GetCategoriaByIdAsync(id);
    }
}
