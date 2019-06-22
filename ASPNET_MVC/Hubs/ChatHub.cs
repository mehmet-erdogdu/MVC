using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ASPNET_MVC.Hubs
{
    public class ChatHub : Hub
    {
        public void SendMessage(string name, string message)
        {
            Clients.Others.GetMessageOther(name, message);
            Clients.Caller.GetMessageCaller(message);
            // others.doWork()=ben hariç caller.doWork()=sadece bana users("Memo").doWork()=sadece memoya
            //Clients.All.hello();
        }
    }
}