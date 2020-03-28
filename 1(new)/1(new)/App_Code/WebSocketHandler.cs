using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace _1_new_.App_Code
{
    public class WebSocketHandler : IHttpHandler
    {
        WebSocket socket;
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
                context.AcceptWebSocketRequest(WebSocketRequest);
            else
                context.Response.WriteFile("WSPage.html");
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            socket = context.WebSocket;
            string s = await Receive();
            await Send(s);
            int i = 0;
            while (socket.State == WebSocketState.Open)
            {
                System.Threading.Thread.Sleep(1000);
                await Send("[" + (i++).ToString() + "]");
            }

        }

        private async Task<string> Receive()
        {
            string rc = null;
            var buffer = new ArraySegment<byte>(new byte[512]);
            var result = await socket.ReceiveAsync(buffer, CancellationToken.None);
            rc = System.Text.Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
            return rc;
        }

        private async Task Send(string s)
        {
            var sendbuffer = new ArraySegment<byte>(System.Text.Encoding.UTF8.GetBytes("Ответ: " + s));
            await socket.SendAsync(sendbuffer, System.Net.WebSockets.WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}