using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PRUEBA_TECNICA_IMOVS.Models
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public ApiResponse()
        {
        }

        public ApiResponse(bool success, string message, T data = default(T))
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public static ApiResponse<T> SuccessResponse(T data, string message = "Operación exitosa")
        {
            return new ApiResponse<T>(true, message, data);
        }

        public static ApiResponse<T> ErrorResponse(string message)
        {
            return new ApiResponse<T>(false, message);
        }
    }
}