using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.ApiResponses
{
    public class DynamicDTO
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsHide { get; set; }

        public bool IsEditable { get; set; }
    }
}
