using CRUDProduto.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using CRUDProduto.Core.Dtos;

namespace CRUDProduto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [Route("GetAllProdutosAsync")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetAllProdutosAsync()
        {
            try
            {
                return Ok(await _produtoAppService.GetProdutosAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao buscar todos os produtos!");
            }
        }
    }
}
