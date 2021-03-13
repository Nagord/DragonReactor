using DragonReactor.Components.CaptainsChair;
using DragonReactor.Components.Extractor;
using DragonReactor.Components.Hull;
using DragonReactor.Components.InertiaThruster;
using DragonReactor.Components.ManeuverThruster;
using DragonReactor.Components.Missile;
using DragonReactor.Components.MissionShipComponent;
using DragonReactor.Components.NuclearDevice;
using DragonReactor.Components.Reactor;
using DragonReactor.Components.Shield;
using DragonReactor.Components.Thruster;
using DragonReactor.Components.Virus;
using DragonReactor.Components.WarpDrive;
using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace DragonReactor
{
    class Commands : IChatCommand
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
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ShieldPluginManager.CreateShield(ShieldPluginManager.Instance.GetShieldIDFromName("Dragon Shield"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(HullPluginManager.CreateHull(HullPluginManager.Instance.GetHullIDFromName("Dragon Hull"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(WarpDrivePluginManager.CreateWarpDrive(WarpDrivePluginManager.Instance.GetWarpDriveIDFromName("Dragon WarpDrive"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ThrusterPluginManager.CreateThruster(ThrusterPluginManager.Instance.GetThrusterIDFromName("Dragon Thruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(InertiaThrusterPluginManager.CreateInertiaThruster(InertiaThrusterPluginManager.Instance.GetInertiaThrusterIDFromName("Dragon InertiaThruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ManeuverThrusterPluginManager.CreateManeuverThruster(ManeuverThrusterPluginManager.Instance.GetManeuverThrusterIDFromName("Dragon ManeuverThruster"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(CaptainsChairPluginManager.CreateCaptainsChair(CaptainsChairPluginManager.Instance.GetCaptainsChairIDFromName("Dragon CaptainsChair"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(new Components.MegaTurret.DragonMegaTurret(0, 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(ExtractorPluginManager.CreateExtractor(ExtractorPluginManager.Instance.GetExtractorIDFromName("Dragon Extractor"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(MissilePluginManager.CreateMissile(MissilePluginManager.Instance.GetMissileIDFromName("Dragon Missile"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(NuclearDevicePluginManager.CreateNuclearDevice(NuclearDevicePluginManager.Instance.GetNuclearDeviceIDFromName("Dragon NuclearDevice"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(new Components.Turret.DragonTurret(0, 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(new Components.HullPlating.DragonHullPlating(0, 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(MissionShipComponentPluginManager.CreateMissionShipComponent(MissionShipComponentPluginManager.Instance.GetMissionShipComponentIDFromName("Dragon MissionShipComponent"), 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(new Components.AutoTurret.DragonAutoTurret(0, 0), -1, ESlotType.E_COMP_NONE);
                    PLNetworkManager.Instance.MyLocalPawn.CurrentShip.MyStats.AddShipComponent(VirusPluginManager.CreateVirus(VirusPluginManager.Instance.GetVirusIDFromName("Dragon Virus"), 0), -1, ESlotType.E_COMP_CARGO);
                    break;
                case "addtoinv":
                    Items.ItemPluginManager.Instance.GetItemIDsFromName("Slime", out int Main, out int Sub);
                    PLNetworkManager.Instance.LocalPlayer.MyInventory.UpdateItem(PLServer.Instance.PawnInvItemIDCounter++, Main, Sub, 0, -1);
                    Items.ItemPluginManager.Instance.GetItemIDsFromName("Pizza", out Main, out Sub);
                    PLNetworkManager.Instance.LocalPlayer.MyInventory.UpdateItem(PLServer.Instance.PawnInvItemIDCounter++, Main, Sub, 0, -1);
                    break;
                case "dbg":
                    Items.ItemPluginManager.Instance.GetItemIDsFromName("Pizza", out Main, out Sub);
                    PLPawnItem item = Items.ItemPluginManager.CreatePawnItem(Main, Sub, 0);
                    PLPawnItem.GetPawnInfoFromHash((int)item.getHash(), out uint maintype, out uint subtype, out uint level);
                    Messaging.Notification($"{maintype}, {subtype}, {level}");

                    Items.ItemPluginManager.Instance.GetItemIDsFromName("Slime", out Main, out Sub);
                    item = Items.ItemPluginManager.CreatePawnItem(Main, Sub, 0);
                    PLPawnItem.GetPawnInfoFromHash((int)item.getHash(), out maintype, out subtype, out level);
                    Messaging.Notification($"{maintype}, {subtype}, {level}");
                    break;
                case "tdbg":
                    Global.DebugLogging = !Global.DebugLogging;
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
