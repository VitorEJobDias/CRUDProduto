using CRUDProduto.Core.Common;

namespace CRUDProduto.Core.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public Guid IdCategoria { get; private set; }

        public Categoria Categoria { get; private set; }

        public Produto(string nome, decimal preco, Guid idCategoria)
        {
            Nome = nome;
            Preco = preco;
            IdCategoria = idCategoria;
        }

        public void Update(string nome, decimal preco, Guid idCategoria)
        {
            Nome = nome;
            Preco = preco;
            IdCategoria = idCategoria;
        }
    }
}
