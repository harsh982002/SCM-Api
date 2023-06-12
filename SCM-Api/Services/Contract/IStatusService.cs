﻿using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IStatusService
    {
        Task<IEnumerable<StatusModel?>> GetStatusList();

    }
}
