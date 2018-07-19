namespace BlazorClient.Models
{
    public class ChatMessage
    {
        public User user { get; set; }
        public string message { get; set; }
    }


    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
    }
}