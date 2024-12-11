using AutoMapper;
using CRUDProduto.Core.Dtos;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Services;

namespace CRUDProduto.Application.Services
{
    public class CategoriaAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaService _categoriaService;

        public CategoriaAppService(IMapper mapper, ICategoriaService categoriaService)
        {
            _mapper = mapper;
            _categoriaService = categoriaService;
        }

        public async Task CreateCategoriaAsync(CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null) throw new ArgumentNullException(nameof(categoriaDto));

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaService.CreateCategoriaAsync(categoria);
        }

        public async Task DeleteCategoriaAsync(Guid id)
        {
            await _categoriaService.DeleteCategoriaAsync(id);
        }

        public async Task UpdateCategoriaAsync(CategoriaDTO categoriaDto)
        {
            if (categoriaDto == null) throw new ArgumentNullException(nameof(categoriaDto));

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            await _categoriaService.UpdateCategoriaAsync(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategoriasAsync()
        {
            var categorias = await _categoriaService.GetCategoriasAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public async Task<CategoriaDTO> GetCategoriaByIdAsync(Guid id)
        {
            var categoria = await _categoriaService.GetCategoriaByIdAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }
    }
}
