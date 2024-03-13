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
    public class PetImageFileRepository : EfRepositoryBase<PetImageFile, BaseDbContext>, IPetImageFileRepository
    {
        public PetImageFileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
