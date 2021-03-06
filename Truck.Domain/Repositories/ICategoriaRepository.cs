﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Truck.Domain.Entities;

namespace Truck.Domain.Repositories
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<IEnumerable<Categoria>> GetAllWithVeiculosAsync();
    }
}
