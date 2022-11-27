using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Projection : Entity
    {

        public int MovieId { get; set; }

        public int SaloonId { get; set; }

        public int ProjectionYear { get; set; }

        public Movie Movie { get; set; }

        public Saloon Saloon { get; set; }
    }
}
