﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Controllers
{
    [EnableCors("beautypolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        
    }
}
