namespace DragonReactor.Components.Virus
{
    class DragonVirus : VirusPlugin
    {
        public override string Name => "Dragon Virus";

        public override string Description => "disabled EM sensors";

        public override bool Experimental => true;

        public override void FinalLateAddStats(PLVirus InVirus)
        {
            InVirus.ShipStats.EMDetection = 0;
        }
    }
}
