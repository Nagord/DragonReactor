using HarmonyLib;

namespace DragonReactor
{
    [HarmonyPatch(typeof(PLIntrepidInfo), "SetupShipStats")]
    class IntrepidTestPatch
    {
        static void Postfix(PLIntrepidInfo __instance)
        {
            __instance.MyStats.AddShipComponent(ReactorConstructor.CreateReactor(15, 0), -1, ESlotType.E_COMP_NONE);
        }
    }
}
