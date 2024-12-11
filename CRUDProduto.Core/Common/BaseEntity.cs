namespace CRUDProduto.Core.Common
{
    public class BaseEntity
    {
        public Guid Id { get; private set; }
        public bool Active { get; private set; }
        public DateTime Created { get; private set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
            Active = true;
            Created = DateTime.Now;
        }

        public void Delete()
        {
            Active = false;
        }

        protected void SetActive(bool active)
        {
            Active = active;
        }

        protected void SetCreated(DateTime created)
        {
            Created = created;
        }
    }
}
