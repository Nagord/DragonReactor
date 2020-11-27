using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace DragonReactor
{
    class commands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "compmod" };
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
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ReactorPluginManager.CreateReactor(ReactorPluginManager.Instance.GetReactorIDFromName("Dragon Reactor"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ReactorPluginManager.CreateReactor(14, 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ShieldPluginManager.CreateShield(ShieldPluginManager.Instance.GetShieldIDFromName("Dragon Shield"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(HullPluginManager.CreateHull(HullPluginManager.Instance.GetHullIDFromName("Dragon Hull"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(WarpDrivePluginManager.CreateWarpDrive(WarpDrivePluginManager.Instance.GetWarpDriveIDFromName("Dragon WarpDrive"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ThrusterPluginManager.CreateThruster(ThrusterPluginManager.Instance.GetThrusterIDFromName("Dragon Thruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(InertiaThrusterPluginManager.CreateInertiaThruster(InertiaThrusterPluginManager.Instance.GetInertiaThrusterIDFromName("Dragon InertiaThruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ManeuverThrusterPluginManager.CreateManeuverThruster(ManeuverThrusterPluginManager.Instance.GetManeuverThrusterIDFromName("Dragon ManeuverThruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(CaptainsChairPluginManager.CreateCaptainsChair(CaptainsChairPluginManager.Instance.GetCaptainsChairIDFromName("Dragon CaptainsChair"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(new MegaTurret.DragonMegaTurret(0, 0), -1, ESlotType.E_COMP_NONE);
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
