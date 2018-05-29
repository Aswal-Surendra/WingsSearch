using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaniShop.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Response(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

    }
}