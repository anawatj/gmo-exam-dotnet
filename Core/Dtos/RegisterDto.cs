﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public  class RegisterDto
    {
        public string UserName { get; set; }
        public int? UserGroupID { get; set; }
    }
}