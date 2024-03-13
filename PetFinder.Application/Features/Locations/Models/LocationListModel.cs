using Core.Persistence.Paging;
using PetFinder.Application.Features.Locations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Locations.Models
{
    public class LocationListModel:BasePageableModel
    {
        public IList<LocationListDto> Items { get; set; }

    }
}
