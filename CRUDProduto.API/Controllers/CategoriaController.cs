using CRUDProduto.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using CRUDProduto.Core.Dtos;

namespace CRUDProduto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriaAppService;
        public CategoriaController(ICategoriaAppService categoriaAppService)
        {
            _categoriaAppService = categoriaAppService;
        }

        [Route("GetAllCategoriasAsync")]
        [HttpGet]
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
    }
}
