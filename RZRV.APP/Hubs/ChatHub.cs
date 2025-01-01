using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RZRV.APP.Data;
using RZRV.APP.Models;
using System.Security.Claims;

namespace RZRV.APP.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string receiverId, string message)
        {
            var senderId = Context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var msg = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Content = message,
                Type = MessageType.Direct
            };

            _context.ChatMessages.Add(msg);
            await _context.SaveChangesAsync();

            msg.CreatedAt = DateTime.UtcNow.ToLocalTime();
            // Send to receiver
            await Clients.User(receiverId).SendAsync("ReceiveMessage", msg);

            // Send back to sender
            await Clients.Caller.SendAsync("ReceiveMessage", msg);
        }
    }
}