using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Contracts.DTOs
{
    public interface IMultilanguageDTO<T> : IDTO where T: ITranslatorDTO 
    {
        public List<T> Translates { get; set; }
    }
    public interface ITranslatorDTO : IDTO
    {
        long LanguageId { get; set; }
        int Status { get; set; }

    }

}
