using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int YearOfConstruction { get; set; }
    }
}
