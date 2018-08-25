using BlazorChat.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;

namespace BlazorChat.App.Pages
{
    public class IndexComponent : BlazorComponent, IDisposable
    {
        // flag to indicate chat status
        protected bool chatting = false;

        // name of the user who will be chatting
        protected string myName;


        // on-screen message
        protected string message;

        // new message input
        protected string newMessage;

        // list of messages in chat
        protected List<Message> messages = new List<Message>();

        
        /// <summary>
        /// 
        /// </summary>
        protected void Disconnect()
        {
            chatting = false;
            ChatUI.OnMsg -= OnMsg;
            ChatUI.OnDisconnect -= OnDisconnect;
            ChatUI.OnConnected -= OnConnected;
            ChatUI.OnDisconnect?.Invoke(myName);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() => Disconnect();


        /// <summary>
        /// Start chat client
        /// </summary>
        protected void Chat()
        {
            // check username is valid
            if (string.IsNullOrWhiteSpace(myName))
            {
                message = "Please enter a name";
                return;
            };

            chatting = true;
            ChatUI.OnMsg += OnMsg;
            ChatUI.OnConnected?.Invoke(myName);
            ChatUI.OnConnected += OnConnected;
            ChatUI.OnDisconnect += OnDisconnect;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="msg"></param>
        protected void OnMsg(string userName, string msg)
        {
            messages.Add(new Message(userName, msg, myName != userName));
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected void OnDisconnect(string userName)
        {
            messages.Add(new Message(userName, "OnDisconnect", true));
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        protected void OnConnected(string userName)
        {
            messages.Add(new Message(userName, "OnConnected", true));
            StateHasChanged();
        }


        /// <summary>
        /// 
        /// </summary>
        protected void SendMsg()
        {
            if (chatting && !string.IsNullOrWhiteSpace(newMessage))
            {
                ChatUI.OnMsg?.Invoke(myName, newMessage);
                newMessage = string.Empty;
            }
        }
    }
}