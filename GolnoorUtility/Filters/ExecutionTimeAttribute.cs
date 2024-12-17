using GolnoorUtility.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GolnoorUtility.Filters
{
    public class ExecutionTimeAttribute : ActionFilterAttribute
    {
        Stopwatch watch;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            watch = Stopwatch.StartNew();
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            if (context.Result is ObjectResult)
            {
                var Result = (context.Result as ObjectResult);
                if (Result.Value is ApiResult)
                {
                    var Temp = (Result.Value as ApiResult);
                    (Temp.Detail as Dictionary<string, object>).Add("ExecutionTime", elapsedMs);
                    Result.Value = Temp;
                }
            }
            base.OnActionExecuted(context);
        }
        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;
        //    if (context.Result is ObjectResult)
        //    {
        //        var Result = (context.Result as ObjectResult);
        //        if (Result.Value is ApiResult)
        //        {
        //            var Temp = (Result.Value as ApiResult);
        //            (Temp.Detail as Dictionary<string, object>).Add("ExecutionTime", elapsedMs);
        //            Result.Value = Temp;
        //        }  
        //    }

        //    base.OnResultExecuting(context);
        //}
    }
}
