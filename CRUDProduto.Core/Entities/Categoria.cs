using CRUDProduto.Core.Common;

namespace CRUDProduto.Core.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; private set; }

        public IReadOnlyCollection<Produto> Produtos => _produtos;
        private readonly List<Produto> _produtos;

        public Categoria(string nome)
        {
            Nome = nome;
            _produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            if (produto == null) throw new ArgumentNullException(nameof(produto));
            _produtos.Add(produto);
        }
    }
}
