using Core.Persistence.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Services.Repositories
{
    public interface IContactInformationRepository:IAsyncRepository<ContactInformation>,IRepository<ContactInformation>
    {
    }
}
