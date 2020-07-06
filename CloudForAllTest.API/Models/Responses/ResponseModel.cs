using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudForAllTest.API.Models
{
    public class ResponseModel
    {
        public int HttpResponse { get; set; }
        public object Response { get; set; }
        public string ErrorResponse { get; set; }
    }
}
