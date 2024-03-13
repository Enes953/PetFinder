using PetFinder.Application.Features.ContactInformations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.ContactInformations.Models
{
    public class ContactInformationListModel
    {
        public IList<ContactInformationListDto> Items { get; set; }

    }
}
