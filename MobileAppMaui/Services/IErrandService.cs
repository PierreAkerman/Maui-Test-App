using MobileAppMaui.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MobileAppMaui.Services
{
    public interface IErrandService
    {
        Task<List<ErrandModel>> GetErrandsByTechnicianIdAsync(string id);
        Task<HttpStatusCode> UpdateErrandStatus(string errandId, ErrandStatus status);
    }
}
