using System;
using System.Collections.Generic;
using WebSocketSharp.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using System.Text;
using System.Threading;

namespace McChannelPoints
{


    class SocketClient
    {
        WebSocket socket;
        public string TwitchID = "118542232";
        public string TwitchOath = "ilo3sj0v34g0x8sljrzdq5de81lm2j";
        
        public void SocketPinger(WebSocket socket)
        {
            socket = this.socket;
            new Thread(new ThreadStart(Run)) { IsBackground = true }.Start();
            
        }


        public SocketClient()
        {

            socket = new WebSocket("wss://pubsub-edge.twitch.tv");
            socket.OnOpen += SocketConnect;
            socket.OnMessage += SocketMessage;
            socket.Connect();
            SocketPinger(socket);
            
        }

        public void SocketConnect(object sender, EventArgs e)
        {
            socket.Send("{\"type\": \"PING\"}");
            socket.Send($"{{\"type\": \"LISTEN\", \"nonce\": \"ChannelPoints\", \"data\": {{\"topics\": [\"channel-points-channel-v1.{TwitchID}\",\"channel-bits-event-v2.{TwitchID}\",\"channel-subscribe-events-v1.{TwitchID}\"],\"auth_token\": \"{TwitchOath}\"}}}}");
            
        }

        public void SocketMessage(object sender, MessageEventArgs e)
        {
            try
            {
                string json = e.Data.Replace("\"{", "{").Replace("\\", string.Empty);

            }
            catch {
            }
        }

        private void Run()
        {
            while (true)
            {
                try
                {
                    socket.Send("{\"type\": \"PING\"}");
                    Thread.Sleep(300000);
                }
                catch
                {

                }


            }




        }







    }
}




