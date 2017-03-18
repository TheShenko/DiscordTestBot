using Discord;
using Discord.Commands;
using System;

namespace TestBot
{
    public class DiscordBot
    {
        DiscordClient client;
        CommandService commands;

        public DiscordBot()
        {
            client = new DiscordClient(input =>
            {
                input.LogLevel = LogSeverity.Info;
                input.LogHandler = Log;
            });

            client.UsingCommands(input =>
            {
                input.PrefixChar = '%';
                input.AllowMentionPrefix = true;
            });

            commands = client.GetService<CommandService>();
            commands.CreateCommand("test").Do(async (e) =>
            {
                await e.Channel.SendMessage("I'M A TEST");
            });

            commands.CreateCommand("cat").Do(async (e) =>
            {
                await e.Channel.SendFile("cat.png");
            });

            commands.CreateCommand("himaddie").Do(async (e) =>
            {
                await e.Channel.SendMessage("@713 Espurrs in a Trenchcoat#2577 hi"); 
            });

            client.ExecuteAndWait(async () =>
            {
                await client.Connect("Mjc3MjY0MTk1MTM1ODY0ODMy.C64qeQ.8v5tBJGOauyIJmv4XrP_pz16RXw", TokenType.Bot);
            });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}