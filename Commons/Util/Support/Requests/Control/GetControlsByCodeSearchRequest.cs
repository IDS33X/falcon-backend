using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Support.Requests.Control
{
    public class GetControlsByCodeSearchRequest : PaginationRequest
    {
        public int RiskCategoryId { get; set; }
        public string Filter { get; set; }
    }
}
