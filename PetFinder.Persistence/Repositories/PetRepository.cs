using Core.Persistence.Repositories;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using PetFinder.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Persistence.Repositories
{
    public class PetRepository : EfRepositoryBase<Pet, BaseDbContext>, IPetRepository
    {
        public PetRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
