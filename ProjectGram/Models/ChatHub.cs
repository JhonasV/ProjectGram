using Microsoft.AspNetCore.SignalR;

namespace ProjectGram.Models
{
    public class ChatHub : Hub
    {
        public void SendNotification(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.SendAsync("broadcastMessage", name, message);
        }
    }
}