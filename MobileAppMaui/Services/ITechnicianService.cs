using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppMaui.Data;

namespace MobileAppMaui.Services
{
    public interface ITechnicianService
    {
        Task<IEnumerable<TechnicianModel>> GetAllTechnicians();
    }
}
