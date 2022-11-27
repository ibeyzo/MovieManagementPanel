using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Movie : Entity
    {

        public string Name { get; set; }

        public int YearOfConstruction { get; set; }

        public List<Projection> Projections { get; set; }

        public Movie()
        {
            Projections = new List<Projection>();
        }
    }
}
