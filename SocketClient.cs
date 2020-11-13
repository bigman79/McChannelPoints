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
        public string TwitchOath = "oj8pip257e3d79ujyymfqum7m7rfz1"
        private Thread sender;
        public void SocketPinger(We)
        {
            socket = this.socket;
            new Thread(new ThreadStart(Run)) { IsBackground = true }.Start();
            
        }


        public SocketClient(IrcClient client)
        {

            socket = new WebSocket("wss://pubsub-edge.twitch.tv");
            socket.OnOpen += SocketConnect;
            socket.OnMessage += SocketMessage;
            socket.Connect();


        }

        public void SocketConnect(object sender, EventArgs e)
        {
            socket.Send("{\"type\": \"PING\"}");
            socket.Send($"{{\"type\": \"LISTEN\", \"nonce\": \"ChannelPoints\", \"dara\": [\"channel-points-channel-v1.{TwitchID}\",\"channel-bits-event-v2.{TwitchID}\",\"channel-subscribe-events-v1.{TwitchID}\"],\"auth_token\": \"{TwitchOath}\"}}}}");
            new SocketPinger(socket);
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




