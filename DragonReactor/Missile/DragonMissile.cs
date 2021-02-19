namespace DragonReactor.Missile
{
    class DragonMissile : MissilePlugin
    {
        public override string Name => "Dragon Missile";

        public override float Damage => 1000f;

        public override float Speed => 15f;

        public override EDamageType DamageType => EDamageType.E_PHASE;

        public override int MissileRefillPrice => 1;

        public override int AmmoCapacity => 60;

        public override int PrefabID => 0;
    }
}
