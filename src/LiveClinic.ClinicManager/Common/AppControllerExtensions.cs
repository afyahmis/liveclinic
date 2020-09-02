using System;
using System.Runtime.CompilerServices;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LiveClinic.ClinicManager.Common
{
    public static class AppControllerExtensions
    {
        public static IActionResult ServeResult<T>(this ControllerBase controller, Result<T> result,string message="")
        {
            if (result.IsSuccess)
            {
                if (null == result.Value)
                    return controller.NotFound(message);

                return controller.Ok(result.Value);
            }

            if(result.IsFailure)
                throw new Exception(result.Error);
            
            throw new Exception("Unknown error occured");
        }
        
        public static IActionResult ServeResultStatus(this ControllerBase controller, Result result)
        {
            if (result.IsSuccess)
            {
                return controller.Ok();
            }

            if(result.IsFailure)
                throw new Exception(result.Error);
            
            throw new Exception("Unknown error occured");
        }
        
        public static IActionResult ServeError(this ControllerBase controller,Exception e,string error="")
        {
            Log.Error(e, error);
            return controller.StatusCode(500, $"{error} {e.Message}");
        }

    }
}