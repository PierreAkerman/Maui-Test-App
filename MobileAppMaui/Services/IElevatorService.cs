using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public interface IElevatorService
    {
        Task<IEnumerable<ElevatorDetailsModel>> GetAllElevatorsAsync();
        Task<ElevatorDetailsModel> GetElevatorByIdAsync(string id);
    }
}
