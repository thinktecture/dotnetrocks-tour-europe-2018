using System;

namespace Serverless
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Message { get; set; }
    }
}
