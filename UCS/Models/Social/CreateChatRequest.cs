using DbProvider.Models;

namespace ChatApp.Models.Social
{
    public class CreateChatRequest
    {
        public string Name { get; set; }
        public ChatType ChatType { get; set; }
    }
}
