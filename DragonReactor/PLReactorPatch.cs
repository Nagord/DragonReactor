using System;
using HarmonyLib;

namespace DragonReactor
{
    [HarmonyPatch(typeof(PLReactor), MethodType.Constructor, new Type[] { typeof(EReactorType), typeof(int) })]
    class PLReactorPatch
    {
        static bool Prefix(PLReactor __instance, EReactorType inType, int inLevel)
        {
            if (inType == EReactorType.E_REAC_ID_MAX)
            {
                return true;
            }
            ReactorConstructor.CreateReactor((int)inType, inLevel, __instance);
            return false;
        }
    }
}
