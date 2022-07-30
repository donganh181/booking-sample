using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BookingSample.Business.Hubs
{
    public class SystemEventHub : Hub
    {
        public static string WEB_BOOKING_CHANNEL = "WEB_BOOKING_CHANNEL";
        public static string WEB_CONNECTION_CHANNEL = "WEB_CONNECTION_CHANNEL";
        public static string SYSTEM_BOT = "SYSTEM_BOT";

        public async Task JoinRoom(WebConnection webConnection)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, webConnection.RoomId);
            Console.WriteLine($"{webConnection.WebId} has joined {webConnection.RoomId}");
            await Clients.Group(webConnection.RoomId)
                .SendAsync(WEB_CONNECTION_CHANNEL,
                    SYSTEM_BOT, "Connected On System Success");
        }
    }
}