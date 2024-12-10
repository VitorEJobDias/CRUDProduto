using CRUDProduto.Core.Common;

namespace CRUDProduto.Core.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; private set; }

        public Categoria(string nome)
        {
            Nome = nome;
        }
    }
}
