using System;
using System.Collections.Generic;
using System.Text;

namespace eCourse.Models.Helpers
{
    public class ApiException : Exception
    {
        public ApiException(string message, System.Net.HttpStatusCode? httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        public System.Net.HttpStatusCode? HttpStatusCode { get; set; }
    }
}
