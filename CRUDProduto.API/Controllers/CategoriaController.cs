using CRUDProduto.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using CRUDProduto.Core.Dtos;

namespace CRUDProduto.API.Controllers
{
    [SwaggerTag("Requisições relacionadas a categorias.")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;
        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [SwaggerOperation(Summary = "Retorna todas as categorias", Description = "Esta chamada tem por finalidade retornar todas as categorias de produtos cadastradas no banco de dados.")]
        [HttpGet("GetAllCategoriasAsync")]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetAllCategoriasAsync()
        {
            try
            {
                return Ok(await _categoriaAppService.GetCategoriasAsync());
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao buscar todas as categorias!");
            }
        }

        [SwaggerOperation(Summary = "Cadastrar categorias", Description = "Esta chamada tem por finalidade cadastrar uma categoria no banco de dados.")]
        [HttpPost("CreateCategoria")]
        public async Task<ActionResult> CreateCategoriaAsync(CategoriaDTO categoriaDTO)
        {
            try
            {
                await _categoriaAppService.CreateCategoriaAsync(categoriaDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Ocorreu um erro ao cadastrar a categoria!");
            }
        }
    }
}
