using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Chempions
{
    public class NotificationHub : Hub
    {
        public async Task SendNotificationDel(int productId)
        {
            await Clients.All.SendAsync("ProductDeleted", productId);
        }
    }
}
