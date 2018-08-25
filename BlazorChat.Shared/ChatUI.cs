namespace BlazorChat.Shared
{
    public static class ChatUI
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="msg"></param>
        public delegate void MsgHandler(string userName, string msg);
        public static MsgHandler OnMsg;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public delegate void ConnectedHandler(string userName);
        public static ConnectedHandler OnConnected;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public delegate void DisconnectHandler(string userName);
        public static DisconnectHandler OnDisconnect;
    }
}
