using AutoMapper;
using CRUDProduto.Core.Dtos;
using CRUDProduto.Core.Entities;
using CRUDProduto.Core.Services;
using CRUDProduto.Application.Interfaces.Services;

namespace CRUDProduto.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        public async Task CreateProdutoAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoService.CreateProdutoAsync(produtoEntity);
        }

        public async Task DeleteProdutoAsync(Guid id)
        {
            await _produtoService.DeleteProdutoAsync(id);
        }

        public async Task UpdateProdutoAsync(ProdutoDTO produto)
        {
            var produtoEntity = _mapper.Map<Produto>(produto);
            await _produtoService.UpdateProdutoAsync(produtoEntity);
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutosAsync()
        {
            var produtos = await _produtoService.GetProdutosAsync();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
        }

        public async Task<ProdutoDTO> GetProdutoByIdAsync(Guid id)
        {
            var produto = await _produtoService.GetProdutoByIdAsync(id);
            return _mapper.Map<ProdutoDTO>(produto);
        }
    }
}
