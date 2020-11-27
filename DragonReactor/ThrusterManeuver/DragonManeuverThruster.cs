namespace DragonReactor.ManeuverThruster
{
    class DragonManeuverThruster : ManeuverThrusterPlugin
    {
        public override string Name => "Dragon ManeuverThruster";

        public override float MaxOutput => 1f;

        public override float MaxPowerUsage_Watts => 400f;
    }
}
