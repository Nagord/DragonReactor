using HarmonyLib;
using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace DragonReactor
{
    class commands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "reactor" };
        }

        public string Description()
        {
            return "";
        }

        public bool Execute(string arguments, int SenderID)
        {
            string[] args = arguments.Split(' ');
            switch (args[0].ToLower())
            {
                default:
                    Messaging.Notification("Wrong subcommand");
                    break;
                case "addtoship":
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ReactorPluginManager.CreateReactor(ReactorPluginManager.Instance.GetReactorIDFromName("Dragon Reactor V0.1.0"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ReactorPluginManager.CreateReactor(14, 0), -1, ESlotType.E_COMP_NONE);
                    break;
            }

            return false;
        }

        public bool PublicCommand()
        {
            return false;
        }

        public string UsageExample()
        {
            return "/reactor";
        }
    }
}
