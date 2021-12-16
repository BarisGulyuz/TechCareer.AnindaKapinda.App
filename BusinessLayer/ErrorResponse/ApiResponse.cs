using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ErrorResponse
{
   public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int EntityId { get; set; }
        public ApiResponse(int statusCode, int entityId, string message = null)
        {
            this.StatusCode = statusCode;
            this.EntityId = entityId;
            this.Message = message ?? GetDefaultMessage(statusCode, entityId);
        }
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessage(statusCode, null);
        }

        public ApiResponse()
        {
        }

        private string GetDefaultMessage(int statusCode, int? entityId)
        {
            string errorMessage = string.Empty;
            switch (statusCode)
            {
                case 400:
                    errorMessage = "A Bad Request";
                    break;
                case 401:
                    errorMessage = "Authorize Error";
                    break;
                case 404:
                    errorMessage = "Resource Not Found" + entityId;
                    break;
                case 500:
                    errorMessage = "Server Error";
                    break;
            }
            return errorMessage;
        }
    }
}
