﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Contracts.V1.Responses
{
    public class WishListBookResponse : Response
    {
        public SimpleBookResponse Book { get; set; }
    }
}
