using Domain.Entities;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SaloonRepository : EfRepositoryBase<ApplicationDbContext, Saloon>, IRepository<Saloon>
    {
        public SaloonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}