using UnityEngine;

namespace DragonReactor.Components.WarpDriveProgram
{
    public abstract class WarpDriveProgramPlugin
    {
        public WarpDriveProgramPlugin()
        {
        }
        public virtual string Name
        {
            get { return ""; }
        }
        public virtual string Description
        {
            get { return ""; }
        }
        public virtual int MaxLevelCharges
        {
            get { return 3; }
        }
        public virtual bool IsVirus
        {
            get { return false; }
        }
        public virtual int VirusSubtype
        {
            get { return 0; }
        }
        public virtual string ShortName
        {
            get { return ""; }
        }
        public virtual float ActiveTime
        {
            get { return 15f; }
        }
        public virtual Texture2D IconTexture
        {
            get { return PLGlobal.Instance.ProgramBGTexture;  }
        }
        public virtual int MarketPrice
        {
            get { return 1500; }
        }
        public virtual int CargoVisualID
        {
            get { return 36; }
        }
        public virtual bool CanBeDroppedOnShipDeath
        {
            get { return true; }
        }
        public virtual bool Experimental
        {
            get { return false; }
        }
        public virtual bool Unstable
        {
            get { return false; }
        }
        public virtual bool Contraband
        {
            get { return false; }
        }
        public virtual void FinalLateAddStats(PLWarpDriveProgram InWarpDriveProgram)
        {
            
        }
        public virtual void Execute(PLWarpDriveProgram InWarpDriveProgram)
        {

        }
    }
}
