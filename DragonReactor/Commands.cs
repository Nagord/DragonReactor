using PulsarPluginLoader.Chat.Commands.CommandRouter;
using PulsarPluginLoader.Utilities;

namespace ContentMod
{
    class Commands : ChatCommand
    {
        public override string[] CommandAliases()
        {
            return new string[] { "compmod" };
        }

        public override string Description()
        {
            return "runs subcommands. addtoship, addtoinv, dbg, tbdg";
        }

        public override void Execute(string arguments)
        {
            string[] args = arguments.Split(' ');
            switch (args[0].ToLower())
            {
                default:
                    Messaging.Notification("Wrong subcommand");
                    break;
                case "tdbg":
                    Global.DebugLogging = !Global.DebugLogging;
                    PLXMLOptionsIO.Instance.CurrentOptions.SetStringValue("DragonReactortdbg", Global.DebugLogging.ToString());
                    break;
            }
        }

        public override string[] UsageExamples()
        {
            return new string[] { $"{CommandAliases()[0]} [subcommand]" };
        }
    }
}
