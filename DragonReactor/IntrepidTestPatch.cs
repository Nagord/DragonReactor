using HarmonyLib;
using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace DragonReactor
{
    /*[HarmonyPatch(typeof(PLIntrepidInfo), "SetupShipStats")]
    class IntrepidTestPatch
    {
        static void Postfix(PLIntrepidInfo __instance)
        {
            __instance.MyStats.AddShipComponent(PluginReactor.CreateReactor(15, 0), -1, ESlotType.E_COMP_NONE);
        }
    }*/
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
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ReactorPluginManager.CreateReactor(15, 0), -1, ESlotType.E_COMP_NONE);
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
