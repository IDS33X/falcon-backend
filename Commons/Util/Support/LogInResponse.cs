using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Dtos;

namespace Util.Support
{
    public class LogInResponse
    {
        public EmployeeDto Employee { get; set; }
        public string Token { get; set; }
    }
}
