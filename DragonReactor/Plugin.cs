using PulsarPluginLoader;

namespace ContentMod
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.6.2";

        public override string Author => "Dragon";

        public override string LongDescription => "Text";

        public override string Name => "ContentMod";

        public override string HarmonyIdentifier()
        {
            return "Dragon.ContentMod";
        }
    }
}
/*
To Be Completed:
Distress - Will not be added until requested
FB Recipe - Will not be added until requested.
Biscuit Bomb - Will not be added until requested.
Cloak - Will not be added until requested.
P.T. Module - To DO.
*/