using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Exeptions
{
    public class ModelStateExeption : Exception
    {
        public ModelStateExeption(ModelStateDictionary modelStateDictionary)
        {
            ModelState = modelStateDictionary;
        }
        public ModelStateDictionary ModelState { get; set; }
    }
}
