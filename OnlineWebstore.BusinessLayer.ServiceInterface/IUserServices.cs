﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebstore.BusinessLayer.ServiceInterface
{
    public interface IUserServices
    {
        int Authenticate(string userName, string word);
    }
}
