using HarmonyLib;

namespace DragonReactor
{
    [HarmonyPatch(typeof(PLReactor), "CreateReactorFromHash")]
    class HashFix
    {
        static bool Prefix(int inSubType, int inLevel, ref PLShipComponent __result)
        {
            __result = ReactorFactory.CreateReactor(inSubType, inLevel);
            return false;
        }
    }
}
