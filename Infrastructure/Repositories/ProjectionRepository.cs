using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectionRepository : EfRepositoryBase<ApplicationDbContext, Projection>, IRepository<Projection>
    {
        public ProjectionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
