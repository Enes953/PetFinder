using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Domain.Entities
{
    public class Pet:Entity
    {
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string RewardInformation { get; set; }

        // İlişkili sınıflar
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int ContactInformationId { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }

        public ICollection<PetImageFile> PetImageFiles { get; set; }
    }
}
