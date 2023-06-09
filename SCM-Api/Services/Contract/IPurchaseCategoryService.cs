﻿using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IPurchaseCategoryService
    {
        Task<PurchaseCategory?> GetItemAvailabilityById(byte PurchaseCategoryId);

        Task<IEnumerable<PurchaseCategoryModel>> GetItemAvailabilityList();
    }
}
