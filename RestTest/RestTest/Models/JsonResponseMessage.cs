using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestTest.Models
{
    public class JsonResponseMessage
    {
        public JsonResponseMessage(int response_code, string message)
        {
            Response_Code = response_code;
            Message = message;
        }

        public int Response_Code { get; set; }
        public string Message { get; set; }
    }
}