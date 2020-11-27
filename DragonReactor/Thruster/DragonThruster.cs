namespace DragonReactor.Thruster
{
    class DragonThruster : ThrusterPlugin
    {
        public override string Name => "Dragon Thruster";

        public override float MaxOutput => 1f;

        public override float MaxPowerUsage_Watts => 400f;
    }
}
