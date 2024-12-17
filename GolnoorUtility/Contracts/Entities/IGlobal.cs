using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Contracts.Entities
{
    public interface IMultilanguage<T>
    {
        public ICollection<T> Translates { get; set; }
    }
    public interface ITranslator<T>
    {
        public T Entity { get; set; }
        public long EntityId { get; set; }
        public long LanguageId { get; set; }
        //public Language Language { get; set; }
    }
}
