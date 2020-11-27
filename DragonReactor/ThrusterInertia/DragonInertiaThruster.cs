namespace DragonReactor.InertiaThruster
{
    class DragonInertiaThruster : InertiaThrusterPlugin
    {
        public override string Name => "Dragon InertiaThruster";

        public override float MaxOutput => 1f;

        public override float MaxPowerUsage_Watts => 400f;
    }
}
