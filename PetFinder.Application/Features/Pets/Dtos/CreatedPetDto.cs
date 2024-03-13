using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.Pets.Dtos
{
    public class CreatedPetDto
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string RewardInformation { get; set; }

        public int LocationId { get; set; }
        public int ContactInformationId { get; set; }
    }
}
