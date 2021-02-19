using PulsarPluginLoader;

namespace DragonReactor
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.5.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Text";

        public override string Name => "DragonReactor";

        public override string HarmonyIdentifier()
        {
            return "Dragon.DragonReactor";
        }
    }
}
/*
To Be Completed:
Distress - Will not be added until requested
FB Recipe - Will not be added until requested.
Biscuit Bomb - Will not be added until requested.
Cloak - Will not be added until requested.
*/