﻿using CRUDProduto.Core.Entities;

namespace CRUDProduto.Core.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<IEnumerable<Categoria?>> GetCategoriasAsync();
        Task<Categoria> GetCategoriaByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
    }
}
