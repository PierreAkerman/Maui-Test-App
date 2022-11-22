using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public interface ITechnicianService
    {
        Task<IEnumerable<TechnicianModel>> GetAllTechnicians();
    }
}
