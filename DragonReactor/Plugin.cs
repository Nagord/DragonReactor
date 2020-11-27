using PulsarPluginLoader;

namespace DragonReactor
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.4.0";

        public override string Author => "Dragon";

        public override string LongDescription => "Text";

        public override string Name => "DragonReactor";

        public override string HarmonyIdentifier()
        {
            return "Dragon.DragonReactor";
        }
    }
}
