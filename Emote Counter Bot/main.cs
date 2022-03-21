using System;
using System.Diagnostics;
using System.IO;
using TwitchLib.Api.Core.Models.Undocumented.ClipChat;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;


namespace OOOOvsMMMM
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            Console.ReadLine();
        }
    }

    public static class FishCount {
        public static string file = "ooooCount.txt";
        public static string userMessage;
        public static string userId;
        public static string userName;

        public static int oooo;
        public static int mmmm;

        static string[] globalInfo = new string[3];
        static string[] userInfo = new string[3];
        static string[] quoteArray;

        public static void Initialize()
        {
            if (!File.Exists(file)) {
                using (var f = File.Create(file)) { }
                using (StreamWriter writer = new StreamWriter(file)) { writer.WriteLine("Global-0-0"); }
                return;
            }
        }


        public static void UpdateList()
        {


            bool globalWritten = false;
            bool userWritten = false;

            using (StreamReader reader = new StreamReader(file)) { globalInfo = reader.ReadLine().Split("-", 3); }

            quoteArray = File.ReadAllLines(file);
            File.WriteAllText(file, null);



            foreach (string s in quoteArray)
            {
                if (s.StartsWith(userId))
                {
                    userInfo = s.Split("-", 3);
                }

            }

            using (StreamWriter writer = new StreamWriter(file))
            {
                {
                    foreach (string s in quoteArray)
                    {
                        if (!globalWritten || !userWritten)
                        {
                            if (s.StartsWith("Global"))
                            {
                                writer.WriteLine("Global-" + (oooo + Convert.ToInt32(globalInfo[1])) + "-" + (mmmm + Convert.ToInt16(globalInfo[2])));
                            }
                            else if (s.StartsWith(userId))
                            {
                                writer.WriteLine(userId + "-" + (oooo + Convert.ToInt32(userInfo[1])) + "-" + (mmmm + Convert.ToInt16(userInfo[2])));
                            }
                            else
                            {
                                writer.WriteLine(s);
                            }
                        }
                        else
                        {
                            writer.WriteLine(s);
                        }
                    }
                    return;
                }

            }
        }
        public static void CheckIfUserExists()
        {
            string[] quoteArray = File.ReadAllLines(file);
            bool userExists = false;

            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (string s in quoteArray)
                {
                    if (s.StartsWith(userId))
                    {
                        userExists = true;
                    }
                    writer.WriteLine(s);
                }

                if (!userExists)
                {
                    writer.WriteLine(userId + "-0-0");
                }
            }
            return;
        }
        public static void CheckWhichFish(ChatMessage chatMessage)
        {
            userMessage = chatMessage.Message;
            userId = chatMessage.UserId;
            userName = chatMessage.DisplayName;


            if (userMessage.Contains("OOOO") && userMessage.Contains("MMMM"))
            {
                Console.WriteLine(DateTime.Now + userName + ": "+ userMessage + " | 1 1");
                oooo = 1;
                mmmm = 1;
                CheckIfUserExists();
                UpdateList();
            }
            else if (userMessage.Contains("OOOO"))
            {
                Console.WriteLine(DateTime.Now + userName + ": " + userMessage + " | 1 0");
                oooo = 1;
                mmmm = 0;
                CheckIfUserExists();
                UpdateList();
            }
            else if (userMessage.Contains("MMMM"))
            {
                Console.WriteLine(DateTime.Now + userName + ": " + userMessage + " | 0 1");
                oooo = 0;
                mmmm = 1;
                CheckIfUserExists();
                UpdateList();
            }

            return;
        }

        public static string CheckUserFishUsage(ChatMessage chatMessage)
        {
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine(DateTime.Now + " | " + chatMessage.UserId + "-" + chatMessage.DisplayName + ": " + chatMessage.Message);
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");


            quoteArray = File.ReadAllLines(file);
            userId = chatMessage.UserId;
            float ooooPercent;
            float mmmmPercent;
            bool stopReading = false;

            foreach (string s in quoteArray)
            {
                if (s.StartsWith(userId))
                {
                    userInfo = s.Split("-", 3);
                    stopReading = true;
                }
                if (stopReading)
                {
                    break;
                }

            }
            if (!stopReading)
            {
                ooooPercent = 0;
                mmmmPercent = 0;
                userInfo[1] = "0";
                userInfo[2] = "0";
            }
            else
            {
                ooooPercent = float.Parse(userInfo[1]) / (float.Parse(userInfo[1]) + float.Parse(userInfo[2])) * 100;
                mmmmPercent = float.Parse(userInfo[2]) / (float.Parse(userInfo[1]) + float.Parse(userInfo[2])) * 100;
            }


            if (ooooPercent != ooooPercent)
            {
                ooooPercent = 0;
            }
            if (mmmmPercent != mmmmPercent)
            {
                mmmmPercent = 0;
            }

            return "@" + chatMessage.DisplayName + " has used OOOO " + userInfo[1] + " times (" + Math.Round(ooooPercent, 1) + "%) and MMMM " + userInfo[2] + " times (" + Math.Round(mmmmPercent, 1) + "%)";
        }

        public static string CheckGlobalFishUsage(ChatMessage chatMessage)
        {
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine(DateTime.Now + " | " + chatMessage.UserId + "-" + chatMessage.DisplayName + ": " + chatMessage.Message);
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
            Console.WriteLine("COMMAND USED OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");

            quoteArray = File.ReadAllLines(file);
            float ooooPercent;
            float mmmmPercent;
            bool stopReading = false;

            foreach (string s in quoteArray)
            {
                if (s.StartsWith("Global"))
                {
                    globalInfo = s.Split("-", 3);
                    stopReading = true;
                }
                if (stopReading)
                {
                    break;
                }

            }

            ooooPercent = float.Parse(globalInfo[1]) / (float.Parse(globalInfo[1]) + float.Parse(globalInfo[2])) * 100;
            mmmmPercent = float.Parse(globalInfo[2]) / (float.Parse(globalInfo[1]) + float.Parse(globalInfo[2])) * 100;


            return "OOOO has been used " + globalInfo[1] + " times (" + Math.Round(ooooPercent, 1) + "%) and MMMM " + globalInfo[2] + " times (" + Math.Round(mmmmPercent, 1) + "%)";
        }
    }

    class Bot
    {
        TwitchClient client;
        string twitchChannel = "channel"; //change this to whatever channel you want your bot to join

        public Bot()
        {
            
            ConnectionCredentials credentials = new ConnectionCredentials("botName", "oAuth"); //change this to your bots name and its oAuth key
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)

            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, twitchChannel);

            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnConnected += Client_OnConnected;

            FishCount.Initialize();
            client.Connect();
        }

        //Commands
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {         

            switch (e.ChatMessage.Message)
            {
                
                case "!fishbalance":
                    client.SendMessage(twitchChannel, FishCount.CheckUserFishUsage(e.ChatMessage));               
                    break;
                case "!fishglobal":
                    client.SendMessage(twitchChannel, FishCount.CheckGlobalFishUsage(e.ChatMessage));
                    break;

                /*case "!test":
                    if (test)
                    {
                        client.SendMessage(twitchChannel, ("0"));
                        test = false;
                    }
                    else
                    {
                        client.SendMessage(twitchChannel, ("1"));
                        test = true;
                    }
                    break;*/
            }

            FishCount.CheckWhichFish(e.ChatMessage);
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }



    }
}
