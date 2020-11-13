using System;

namespace McChannelPoints
{

    class Program
    {
        private static string _botName = "joto_is_here";
        private static string _broadcasterName = "joto_is_here";
        private static string _twitchOAuth = "oauth:nv302ng19xbh8why4do4bwjhtsgzlc";
        static void Main(string[] args)
        {
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, _botName, _twitchOAuth, _broadcasterName);
            Subcon sub = new Subcon();
            

            var pinger = new Pinger(client);
            pinger.Start();

            while (true)
            {
                var message = client.ReadMessage();
                Console.WriteLine($"Message: {message}");
            }
        }





    }
}

  


   
