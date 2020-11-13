using System;

namespace McChannelPoints
{

    class Program
    {
        private static string _botName = "joto_is_here";
        private static string _broadcasterName = "joto_is_here";
        private static string _twitchOAuth = "oauth:2lt3uyl8a4cvccjkntnsmfqsuim4vk";
        static void Main(string[] args)
        {
            IrcClient client = new IrcClient("irc.twitch.tv", 6667, _botName, _twitchOAuth, _broadcasterName);


            var pinger = new Pinger(client);
            pinger.Start();

            while (true)
            { 
                var message = client.ReadMessage();
                Console.WriteLine($"Message: {message}");
            }
        }

        
    
    
    
    }}


   
