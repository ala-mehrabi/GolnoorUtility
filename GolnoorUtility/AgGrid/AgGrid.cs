using System;
using System.Collections.Generic;
using System.Text;

namespace GolnoorUtility.AgGrid
{
    public class ColumnInfo
    {
        public string ColumnName { get; set; }
        public string ColumnType { get; set; }
        public bool IsString { get; set; }
    }
    public class RequestModel
    {
        public int StartRow { get; set; }
        public int EndRow { get; set; }
        public int aaaa { get; set; }
        public List<ColumnVO> RowGroupCols { get; set; }
        public List<ColumnVO> ValueCols { get; set; }
        public List<ColumnVO> PivotCols { get; set; }
        public bool PivotMode { get; set; }
        public List<object> GroupKeys { get; set; }
        public Dictionary<string, FilterModel> FilterModel { get; set; }
        public List<ColumnOrder> SortModel { get; set; }
    }

    public class FilterModel
    {
        public string FilterType { get; set; }
        public string Type { get; set; }
        public string Operator { get; set; }
        public object Filter { get; set; }
        public object FilterTo { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<string> values { get; set; }

        public condition Condition1 { get; set; }
        public condition Condition2 { get; set; }

    }
    public class condition
    {
        public string FilterType { get; set; }
        public string Type { get; set; }
        public object Filter { get; set; }
        public object FilterTo { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public List<string> values { get; set; }

    }
    public enum Option
    {
        equals = 0,
        notEqual = 1,
        contains = 2,
        notContains = 3,
        startsWith = 4,
        endsWith = 5,
        lessThan = 6,
        lessThanOrEqual = 7,
        greaterThan = 8,
        greaterThanOrEqual = 9,
        inRange = 10,
        empty = 11,
    }
    public class ColumnOrder
    {
        public string sort { get; set; }
        public string colId { get; set; }

    }
    public class ColumnVO
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Field { get; set; }
        public string AggFunc { get; set; }
    }

}
