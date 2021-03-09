namespace DragonReactor.Components.WarpDriveProgram
{
    class DragonWarpDriveProgramVirus : WarpDriveProgramPlugin
    {
        public override string Name => "Dragon WarpDriveProgramVirus";

        public override string Description => "Who knows?";

        public override bool Experimental => true;

        public override int VirusSubtype => Virus.VirusPluginManager.Instance.GetVirusIDFromName("Dragon Virus");

        public override bool IsVirus => true;
    }
}
