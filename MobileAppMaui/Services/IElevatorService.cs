using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppMaui.Data;

namespace MobileAppMaui.Services
{
    public interface IElevatorService
    {
        Task<IEnumerable<ElevatorDetailsModel>> GetAllElevatorsAsync();
        Task<ElevatorDetailsModel> GetElevatorByIdAsync(string id);
    }
}
