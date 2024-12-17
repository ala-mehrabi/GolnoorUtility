using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Contracts.DTOs
{
    public interface IRecursiveDTO<T>
    {
        List<T> Children { get; set; }
    }
}
