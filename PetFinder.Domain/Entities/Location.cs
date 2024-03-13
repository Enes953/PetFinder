using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Domain.Entities
{
    public class Location:Entity
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        // İlişkili sınıf
        public virtual ICollection<Pet> Pets { get; set; }
    }
}
