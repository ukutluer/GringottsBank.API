using System;
using System.Collections.Generic;
using System.Text;

namespace GringottsBank.Core.Entities.Base
{
    public class BaseGringottsBankApiResponse
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Body { get; set; }
    }
}
