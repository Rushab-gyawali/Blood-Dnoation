﻿using BDMS.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS.Repository.Repository.Error
{
    public interface IErrorRepo
    {
    ErrorLogsCommon Details(string id, string User);
    }
}
