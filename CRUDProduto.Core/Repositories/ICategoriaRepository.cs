﻿using Microsoft.EntityFrameworkCore.Query;
using CRUDProduto.Core.Entities;
using System.Linq.Expressions;

namespace CRUDProduto.Core.Repositories
{
    public interface ICategoriaRepository : IRepositoryBase<Categoria>
    {
        Task<IEnumerable<Categoria?>> GetCategoriasAsync(Expression<Func<Categoria, bool>> consulta, Func<IQueryable<Categoria>, IIncludableQueryable<Categoria, object>>? include = null, bool tracking = false);
        Task<Categoria?> GetCategoriaByIdAsync(Guid id);
        Task CreateCategoriaAsync(Categoria categoria);
        void UpdateCategoria(Categoria categoria);
        Task DeleteAsync(Guid id);
    }
}
