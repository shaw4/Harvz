using System;
using System.IO;
using System.Threading.Tasks;
using Discord.WebSocket;
using Newtonsoft.Json.Linq;

namespace Harvz
{
    /// <summary>
    /// Bot entry structure.
    /// </summary>
    internal struct Bot
    {
        #region Variables
        /// <summary>
        /// Instance to this structure and its functions.
        /// </summary>
        private static readonly Bot instance = new();

        /// <summary>
        /// File name for the config.
        /// </summary>
        private const string config = "config.json";

        /// <summary>
        /// A <see cref="DiscordSocketClient"/> instance, created at <see cref="InitializeBot"/>.
        /// </summary>
        private DiscordSocketClient client;
        #endregion

        /// <summary>
        /// Setup the bot.
        /// </summary>
        public static async Task Main()
        {
            instance.InitializeFiles();
            // ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
            await instance.InitializeBot();
            await Task.Delay(-1); // ! << Never exit
            instance.client.Dispose();
        }

        /// <summary>
        /// Get the instance to the bot.
        /// </summary>
        /// <returns>The instance.</returns>
        public static Bot GetInstance() => instance;

        /// <summary>
        /// Setup all required files.
        /// </summary>
        private readonly void InitializeFiles()
        {
            if (File.Exists(config)) return;
            File.Create(config).Close();
            File.WriteAllText(config, "{\"token\": \"Your token here.\"}");
        }

        /// <summary>
        /// Initialize the bot.
        /// </summary>
        private async Task InitializeBot()
        {
            Console.WriteLine("<!> Bot starting");
            var content = JObject.Parse(File.ReadAllText(config));
            client = new DiscordSocketClient();
            await client.LoginAsync(0, content["token"].ToString());
            await client.StartAsync();
            Console.WriteLine("<!> Bot started!");
        }
    }
}