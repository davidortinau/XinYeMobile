﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XinYeMobile.Service
{
    public interface IHttpsClientHandlerService
    {
        HttpMessageHandler GetPlatformMessageHandler();
    }
}
