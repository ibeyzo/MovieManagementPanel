using Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class EntityValidation
    {
        public void NotNull<TEntity>(TEntity entity) where TEntity : Entity
        {
            if (entity == null)
            {
                throw new Exception("Entity null olamaz");
            }
        }

        public void GreaterThan(int first, int last)
        {
            if (first < last)
            {
                throw new Exception("İlk alan ikinci alandan büyük olamaz");
            }
        }

        public void LowerThan(int first, int last)
        {
            if (first > last)
            {
                throw new Exception("İlk alan ikinci alandan küçük olamaz");
            }
        }
    }
}
