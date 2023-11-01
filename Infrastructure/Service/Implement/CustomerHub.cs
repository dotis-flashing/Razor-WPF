using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Service.Implement;

public class CustomerHub : Hub, ICustomerHub
{
    public async Task SendMessage(string user, string message)
    {
        // Gửi tin nhắn đến tất cả các kết nối khách hàng (các máy khách đang kết nối đến hub này)
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public override async Task OnConnectedAsync()
    {
        // Xử lý khi một kết nối khách hàng được thiết lập
        // Ví dụ: Gửi tin nhắn chào mừng khi một khách hàng mới kết nối
        await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        // Xử lý khi một kết nối khách hàng bị ngắt
        // Ví dụ: Gửi tin nhắn thông báo khi khách hàng ngắt kết nối
        await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}
