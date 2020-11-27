using System;

namespace McChannelPoints
{

    class Program
    {
        private static string _botName = "joto_is_here";
        private static string _broadcasterName = "joto_is_here";
        private static string _twitchOAuth = "oauth:nrah0bytzjjadzvzpkrodcdz94g4va";
        static void Main(string[] args)
        {
            
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, _botName, _twitchOAuth, _broadcasterName);
            SocketClient socket = new SocketClient();
            ChannelRedemptions channel = new ChannelRedemptions();
           
            var pinger = new Pinger(client);
            pinger.Start();

           
            
            
            while (true)
            {
                var message = client.ReadMessage();
                Console.WriteLine(message);
            }

           
        }





    }
}

  


   
