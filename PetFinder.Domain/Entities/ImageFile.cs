using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Domain.Entities
{
    public class ImageFile:Entity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Storage { get; set; }

    }
}
