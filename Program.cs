using System;

namespace McChannelPoints
{

    class Program
    {
        private static string _botName = "joto_is_here";
        private static string _broadcasterName = "joto_is_here";
        private static string _twitchOAuth = "oauth:ta5dgx7v6ktrj4jgv5n5tuzm9s14dg";
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

  


   
