using CRUDProduto.Core.Common;

namespace CRUDProduto.Core.Entities
{
    public class Produto : BaseEntity
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int IdCategoria { get; private set; }

        public Categoria Categoria { get; set; }

        public Produto(string nome, decimal preco, int idCategoria)
        {
            Nome = nome;
            Preco = preco;
            IdCategoria = idCategoria;
        }

        public void Upate(string nome, decimal preco, int idCategoria)
        {
            Nome = nome;
            Preco = preco;
            IdCategoria = idCategoria;
        }
    }
}
