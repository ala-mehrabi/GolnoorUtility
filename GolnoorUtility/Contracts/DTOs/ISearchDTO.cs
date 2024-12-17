using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Contracts.DTOs
{
    public interface ISearchDTO
    {
       public long Id { get; set; }
       public int Limit { get; set; }
        public int Offset { get; set; }
    }

}
