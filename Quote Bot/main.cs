using System;
using System.IO;

using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;


namespace TwitchBot
{
    public static class FISH
    {
        static public string FIIIIIIIISH()
        {
            return "kinda weird... \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣀⣀⣀⠀⠀ \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⡴⠶⠞⠛⠋⠉⠉⠉⠉⠛⠷ \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⡤⠶⠞⠛⠛⠉⠀⠀⠀⠀⠀⠀⣀⣤⣴⣶⣶⣶ \n⠀⠀⠀⠀⠀⠀⢀⠜⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⣠⣤⣾⡋⠀⠈⠻⢿⣿ \n⠀⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀⠀⢀⣴⣶⣾⣿⣿⣿⣿⣿⣿⣿⠖⣶⣤⣀⣿ \n⠀⠀⠀⠀⢀⠊⠀⠀⠀⠀⠀⠀⠀⠙⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣀⣿⣿⣿⣿ \n⠀⠀⢀⠌⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⢸⠀⠀⠀⢀⣤⣄⣀⣀⣀⣀⣠⣤⣤⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠘⢄⠀⠀⠘⠿⠿⠿⠿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠀⠀⠈⠒⠤⣀⣀⣀⣀⣀⣀⣀⣀⣀⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠉⠛⠛⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿ \n⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠛⠛⠛";
        }
    }

    public static class QuoteList
    {
        static int quoteAmount;
        static int convertedNumber;

        static string quote;
        static string file = "Quotes.quotes";
        static string[] messageParts;

        static bool errorCheck;
        static string errorMessage;

        static public void CheckConvertedNumber(int convertedNumber, int quoteAmount)
        {
            if (convertedNumber < 1 || convertedNumber > quoteAmount)
            {
                errorMessage = "There's no quote #" + convertedNumber;
                errorCheck = true;
            }
            return;
        }
        //************************************************//
        static public int CalculateQuoteAmount()
        {
            using (StreamReader reader = new StreamReader(file))
            {
                quoteAmount = 0;
                while (reader.ReadLine() != null)
                {
                    quoteAmount++;
                }
            }
            return quoteAmount;
        }
        //************************************************//
        static public void CheckFileExists()
        {
            if (!File.Exists(file))
            {
                File.Create(file);
                errorMessage = "There are no quotes!";
                errorCheck = true;
            }
            return;
        }
        //************************************************//
        static public int CheckNumber(string number)
        {
            try
            {
                convertedNumber = int.Parse(number);
            }
            catch (SystemException)
            {
                errorMessage = "That's not a number!";
                errorCheck = true;
                return convertedNumber;
            }

            convertedNumber = int.Parse(number);

            try 
            { 
                if (convertedNumber.GetType() != typeof(int)) { } 
            }
            catch (SystemException)
            { 
                errorMessage = "That's not a number!";
                errorCheck = true;
            }

            if (convertedNumber.GetType() != typeof(int))
            {
                errorMessage = "That's not a number!";
                errorCheck = true;
            }

            return convertedNumber;
        }
        //************************************************//
        static public void CheckFileEmpty()
        {
            using (StreamReader reader = new StreamReader(file))
            {
                if (reader.ReadLine() == null)
                {
                    errorMessage = "There are no quotes!";
                    errorCheck = true;
                }
            }
            return;
        }

        //************************************************//
        //************************************************//
        static public string AddQuote(ChatMessage message)
        {
            errorCheck = false;

            quote = message.Message.Replace("!addquote ", "");

            CheckFileEmpty();
            quoteAmount = CalculateQuoteAmount();
            if (errorCheck) { return errorMessage; }

            using (StreamWriter writer = File.AppendText(file))
            {
                if (!File.Exists(file))
                {
                    File.Create(file);
                }

                writer.WriteLine(quote);
            }

            return "Added quote : " + quote + " | (" + (quoteAmount + 1) + "/" + (quoteAmount + 1) + ")";
        }
        //************************************************//
        static public string ReadRandomQuote()
        {
            errorCheck = false;

            Random randomVariable = new Random();
            int randomNum;

            CheckFileEmpty();
            CheckFileExists();
            quoteAmount = CalculateQuoteAmount();
            if (errorCheck) { return errorMessage; }

            randomNum = randomVariable.Next(quoteAmount);

            using (StreamReader reader = new StreamReader(file))
            {
                for (int i = 0; i < (randomNum + 1); i++)
                {
                    quote = reader.ReadLine() + " | (" + (randomNum + 1) + "/" + quoteAmount + ")";
                }
            }
            return quote;
        }
        //************************************************//
        public static string ReadSpecificQuote(ChatMessage message)
        {
            errorCheck = false;

            messageParts = message.Message.Split(" ", 3);

            CheckFileExists();
            CheckFileEmpty();
            convertedNumber = CheckNumber(messageParts[1]);
            quoteAmount = CalculateQuoteAmount();
            CheckConvertedNumber(convertedNumber, quoteAmount);
            if (errorCheck) { return errorMessage; }

            using (StreamReader reader = new StreamReader(file))
            {
                int CurrentQuote = 0;
                for (int i = 0; i < convertedNumber; i++)
                {
                    CurrentQuote++;
                    quote = reader.ReadLine() + " | (" + CurrentQuote + "/" + quoteAmount + ")";
                }
            }
            return quote;
        }
        //************************************************//
        public static string DeleteQuote(ChatMessage message)
        {
            string[] quoteArray;

            errorCheck = false;
            messageParts = message.Message.Split(" ", 3);

            CheckFileExists();
            CheckFileEmpty();
            convertedNumber = CheckNumber(messageParts[1]);
            quoteAmount = CalculateQuoteAmount();
            CheckConvertedNumber(convertedNumber, quoteAmount);
            if (errorCheck) { return errorMessage; }

            quoteArray = File.ReadAllLines(file);
            quoteArray[convertedNumber - 1] = null;

            File.WriteAllText(file, null);

            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (string s in quoteArray)
                {
                    if (s != null)
                    {
                        writer.WriteLine(s);
                    }
                }
            }
            return "Deleted quote #" + convertedNumber;
        }
        //************************************************//
        public static string ReplaceQuote(ChatMessage message)
        {
            string[] quoteArray;

            errorCheck = false;
            messageParts = message.Message.Split(" ", 3);

            CheckFileExists();
            CheckFileEmpty();
            convertedNumber = CheckNumber(messageParts[1]);
            quoteAmount = CalculateQuoteAmount();
            CheckConvertedNumber(convertedNumber, quoteAmount);

            if (errorCheck) {return errorMessage;}

            quoteArray = File.ReadAllLines(file);
            quoteArray[convertedNumber - 1] = messageParts[2];

            File.WriteAllText(file, null);

            using (StreamWriter writer = new StreamWriter(file))
            {
                foreach (string s in quoteArray)
                {
                    if (s != messageParts[2])
                    {
                        writer.WriteLine(s);
                    }
                    else {
                        writer.WriteLine(messageParts[2]);
                    }
                }
                return "Edited quote #" + messageParts[1];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            Console.ReadLine();
        }
    }
    class Bot
    {
        TwitchClient client;
        string twitchChannel = "channel"; //channel should be changed to whatever channel you want the bot to join.

        public Bot()
        {
            ConnectionCredentials credentials = new ConnectionCredentials("botName", "authKey");
            //botName should be changed to the twitch account name of your bot, and
            //authkey should be changed to your bots authentication key, which can be generated using twitchtokengenerator.com

            if (twitchChannel == "channel")
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Please change variables twitchChannel, botName, authKey in the code!");
                return;
            }


            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };
            WebSocketClient customClient = new WebSocketClient(clientOptions);
            client = new TwitchClient(customClient);
            client.Initialize(credentials, twitchChannel);

            client.OnLog += Client_OnLog;
            client.OnJoinedChannel += Client_OnJoinedChannel;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.OnConnected += Client_OnConnected;

            client.Connect();
        }

        //commands
        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {

            if (e.ChatMessage.IsModerator || e.ChatMessage.IsBroadcaster)
            {
                if (e.ChatMessage.Message.StartsWith("!addquote "))
                {
                    client.SendMessage(twitchChannel, QuoteList.AddQuote(e.ChatMessage));
                }
                else if (e.ChatMessage.Message.StartsWith("!deletequote "))
                {
                    client.SendMessage(twitchChannel, QuoteList.DeleteQuote(e.ChatMessage));
                }
                else if (e.ChatMessage.Message.StartsWith("!editquote "))
                {
                    client.SendMessage(twitchChannel, QuoteList.ReplaceQuote(e.ChatMessage));
                }
            }

            if (e.ChatMessage.IsVip || e.ChatMessage.IsModerator || e.ChatMessage.IsBroadcaster)
            {
                if (e.ChatMessage.Message.StartsWith("!readquote "))
                {
                    client.SendMessage(twitchChannel, QuoteList.ReadSpecificQuote(e.ChatMessage));
                }

                switch (e.ChatMessage.Message)
                {
                    case "!weird":
                        client.SendMessage(twitchChannel, FISH.FIIIIIIIISH());
                        break;
                }
            }


            //regular user commands
            switch (e.ChatMessage.Message)
            {
                case "!quote":
                    client.SendMessage(twitchChannel, QuoteList.ReadRandomQuote());
                    break;
                case "id":
                    client.SendMessage(twitchChannel, e.ChatMessage.UserId);
                    break;
            }
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            Console.WriteLine($"{e.DateTime.ToString()}: {e.BotUsername} - {e.Data}");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {         
            Console.WriteLine($"Connected to {e.AutoJoinChannel}");
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            client.SendMessage(e.Channel, "Joined " + twitchChannel + " | Bot version 0.0");
        }
    }
}