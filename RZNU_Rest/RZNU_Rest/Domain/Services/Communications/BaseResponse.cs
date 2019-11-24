using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.Services.Communications
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public T Resource { get; private set; }

        public BaseResponse(bool success, string message) {
            Success = success;
            Message = message;

        }

        public BaseResponse(T resource) {
            Success = true;
            Message = string.Empty;
            Resource = resource;
        }

        public BaseResponse(string message) {
            Message = message;
            Success = true;
            Resource = default;
        }
    }
}
