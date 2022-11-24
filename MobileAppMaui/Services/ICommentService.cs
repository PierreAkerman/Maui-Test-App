using MobileAppMaui.Models;

namespace MobileAppMaui.Services
{
    public interface ICommentService
    {
        Task SaveCommentAsync(CreateErrandCommentModel comment);
    }
}