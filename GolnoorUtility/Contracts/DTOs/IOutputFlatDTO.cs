using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Contracts.DTOs
{
    public interface IOutputFlatDTO<F> : IDTO where F : IOutputFlatDTO
    {
        F Flat { get; set; }
    }

    public interface IOutputFlatDTO : IDTO
    {
        public long Id { get; set; }
        public int Status { get; set; }

    }

}
