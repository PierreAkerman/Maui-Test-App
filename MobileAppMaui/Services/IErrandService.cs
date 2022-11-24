using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public interface IErrandService
    {
        Task<ErrandModel> GetErrandByIdAsync(string id);
        Task<IEnumerable<ErrandModel>> GetErrandsFromTechnicianIdAsync(string id);
        Task<HttpStatusCode> UpdateErrandStatus(string errandId, ErrandStatus status);
    }
}
