using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Domain.Entities
{
    public class PetImageFile:ImageFile
    {
        public bool Showcase { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
