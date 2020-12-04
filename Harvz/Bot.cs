using System.IO;

namespace Harvz
{
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
        #endregion

        /// <summary>
        /// Setup the bot.
        /// </summary>
        public static void Main()
        {
            instance.InitializeFiles();
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
    }
}