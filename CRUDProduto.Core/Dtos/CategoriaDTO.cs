namespace CRUDProduto.Core.Dtos
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string? Nome { get; set; }
        public ICollection<ProdutoDTO>? Produtos { get; set; }
    }
}
