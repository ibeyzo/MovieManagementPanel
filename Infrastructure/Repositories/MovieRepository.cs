using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepositoryBase<ApplicationDbContext, Movie>, IRepository<Movie>
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
