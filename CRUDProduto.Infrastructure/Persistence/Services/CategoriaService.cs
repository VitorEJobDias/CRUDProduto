using CRUDProduto.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Services;
using CRUDProduto.Core.Dtos;
using AutoMapper;

namespace CRUDProduto.Infrastructure.Persistence.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task CreateCategoriaAsync(CategoriaDTO categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));

            Categoria categoriaCadastrada = new Categoria(categoria.Nome);

            await _unitOfWork.Categoria.CreateCategoriaAsync(categoriaCadastrada);
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

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasAsync() =>
            _mapper.Map<IEnumerable<CategoriaDTO>>(await _unitOfWork.Categoria.GetCategoriasAsync(c => c.Active, c => c.Include(p => p.Produtos)));
        
        public async Task<CategoriaDTO> GetCategoriaByIdAsync(Guid id) =>
            _mapper.Map<CategoriaDTO>(await _unitOfWork.Categoria.GetCategoriaByIdAsync(id));
    }
}
