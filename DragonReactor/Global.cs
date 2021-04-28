using HarmonyLib;

namespace ContentMod
{
    class Global
    {
        public static bool DebugLogging = false;
    }
    [HarmonyPatch(typeof(PLServer), "Start")]
    class loadsettings
    {
        static void Postfix()
        {
            if (bool.TryParse(PLXMLOptionsIO.Instance.CurrentOptions.GetStringValue("DragonReactortdbg"), out bool a))
            {
                Global.DebugLogging = a;
            }
        }
    }
}
