using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Saloon : Entity
    {
        public string Name { get; set; }

        public List<Projection> Projections { get; set; }

        public Saloon()
        {
            Projections = new List<Projection>();
        }
    }
}
