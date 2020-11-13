using Newtonsoft.Json;
using WebSocketSharp;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Bson;
using Newtonsoft;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace McChannelPoints
{
    class Subcon
    {
        public string TwitchID = "118542232";
        public string TwitchOath = "ilo3sj0v34g0x8sljrzdq5de81lm2j";
        public Subcon()
        {
            
           using (var ws = new WebSocket("wss://pubsub-edge.twitch.tv"))
            {
                ws.OnMessage += (sender, ef) =>
                {
                    var jsItem = (JObject)JsonConvert.DeserializeObject(ef.Data);
                    Console.WriteLine(ws);
                    Console.WriteLine(jsItem);
                    if (jsItem.Property("type") != null)
                    {
                        switch (jsItem.Property("type").Value.ToString())
                        {
                            case "PONG":
                                // We're still connected
                                // queue next ping
                                break;
                        }
                    }
                };

                ws.OnOpen += (sender, args) =>
                {
                    ws.Send(JsonConvert.SerializeObject(new
                    {
                        type = "LISTEN",
                        data = new
                        {
                            topics = new[] {
                        $"channel-points-channel-v1.{TwitchID}",
                        $"channel-bits-events-v2.{TwitchID}",
                        $"channel-subscribe-events-v1.{TwitchID}"
                    },
                            auth_token = TwitchOath
                        }
                    }));
                    ws.Send(JsonConvert.SerializeObject(new
                    {
                        type = "PING"
                    }));
                };

                ws.Connect();
                
                Console.ReadLine();
                
            }
        }
    }
}
