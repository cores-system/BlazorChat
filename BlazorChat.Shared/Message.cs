namespace BlazorChat.Shared
{
    public class Message
    {
        public Message(string username, string msg, bool mine)
        {
            Username = username;
            Msg = msg;
            Mine = mine;
        }

        public string Username { get; set; }
        public string Msg { get; set; }
        public bool Mine { get; set; }

        /// <summary>
        /// Determine CSS classes to use for message div
        /// </summary>
        public string CSS
        {
            get
            {
                return Mine ? "sent" : "received";
            }
        }
    }
}
