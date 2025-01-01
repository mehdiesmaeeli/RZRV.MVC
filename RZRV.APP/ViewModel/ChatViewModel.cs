using RZRV.APP.Models;

namespace RZRV.APP.ViewModel
{
    public class ChatViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public string CurrentUserId { get; set; }
        public string SelectedUserId { get; set; }

        // Additional useful properties
        public Dictionary<string, int> UnreadMessageCounts { get; set; }
        public Dictionary<string, string> UserStatuses { get; set; }
        public DateTime LastActivity { get; set; }
    }
}
