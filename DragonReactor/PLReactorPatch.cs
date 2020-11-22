using System;
using HarmonyLib;

namespace DragonReactor
{
    /*[HarmonyPatch(typeof(PLReactor), MethodType.Constructor, new Type[] { typeof(EReactorType), typeof(int) })]
    class PLReactorPatch
    {
        static void Postfix(PLReactor __instance, EReactorType inType, int inLevel)
        {
            ReactorFactory.CreateReactor((int)inType, inLevel, __instance);
        }
    }*/
}
