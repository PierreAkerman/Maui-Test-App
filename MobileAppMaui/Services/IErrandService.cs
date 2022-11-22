﻿using MobileAppMaui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppMaui.Services
{
    public interface IErrandService
    {
        Task<ErrandModel> GetOneErrandAsync(string id);
        Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id);
    }
}
