﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Support.Requests.Control
{
    public class GetControlsByUserRequest : PaginationRequest
    {
        public int UserId { get; set; }
    }
}