using Core.Persistence.Paging;
using PetFinder.Application.Features.Pets.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Pets.Models
{
    public class PetListModel:BasePageableModel
    {
        public IList<PetListDto> Items { get; set; }
    }
}
