using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.ApiResponses
{
    public enum ResponseCodes
    {
        succeed = 200,
        DownloadLink = 220,
        DataAndDownloadLink = 230,
        Unauthorized = 401,
        Forbidden = 403,
        InputError = 510,
        DBError = 560,
        HasChild = 561,
        HasRelation = 562,
        DuplicateData = 563,
        NotFoundData = 564,
        SMSError = 580,
        Error = 500,
        ContentError = 520,
        ErrorInFile = 530,
        LoopData = 565,
        LicenceError = 570,
        FileISDeActive=580,
        FileIsArchive=585,
        WeightIsNullOrZero=623,
        CodeInTheInvoice=624,
        CodeInTheInquiry = 625,
    }
    public class ApiResult<T> : ApiResult
    {
        public T Data { get; set; }
    }
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int ResponseCode { get; set; }
        public Dictionary<string, object> Detail { get; set; } = new Dictionary<string, object>();
    }

    public class GroupingData<K, V>
    {
        public K Key { get; set; }
        public V Value { get; set; }
    }
}
