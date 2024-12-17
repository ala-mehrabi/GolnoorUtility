using GolnoorUtility.ApiResponses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.Exeptions
{
    public class ResponseCodeExeption : Exception
    {
        public ResponseCodes ResponseCode { get; set; }

        public ResponseCodeExeption(ResponseCodes responseCode, string message)
            : base(message)
        {
            ResponseCode = responseCode;
        }
    }
}
