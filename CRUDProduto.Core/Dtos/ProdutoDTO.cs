namespace CRUDProduto.Core.Dtos
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string? Nome { get; set; }
        public decimal Preco { get; set; }
        public Guid IdCategoria { get; set; }
    }
}
