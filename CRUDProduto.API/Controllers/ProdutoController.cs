using CRUDProduto.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using CRUDProduto.Core.Dtos;

namespace CRUDProduto.API.Controllers
{
    [SwaggerTag("Requisições relacionadas a produtos.")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [SwaggerOperation(Summary = "Retorna todos os produtos", Description = "Esta chamada tem por finalidade retornar todos os produtos cadastrados no banco de dados.")]
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



        [SwaggerOperation(Summary = "Cadastrar produto", Description = "Esta chamada tem por finalidade cadastrar um produto no banco de dados.")]
        [Route("CreateProdutoAsync")]
        [HttpPost]
        public async Task<ActionResult> CreateProdutoAsync(ProdutoDTO produtoDTO)
        {
            try
            {
                await _produtoAppService.CreateProdutoAsync(produtoDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar o produto!");
            }
        }
    }
}
