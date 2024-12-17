using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolnoorUtility.Contracts.Entities
{
    public interface IRecursiveEntity<T>
    {
        ICollection<T> SubEntities { get; set; }
        long? ParentId { get; set; }
        T Parent { get; set; }
    }


}
