namespace CRUDProduto.Core.Dtos
{
    public class ProdutoDTO
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string? Nome { get; private set; }
        public decimal Preco { get; private set; }
        public Guid IdCategoria { get; private set; }
    }
}
