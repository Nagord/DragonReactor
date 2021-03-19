using UnityEngine;

namespace DragonReactor.Components.Virus
{
    public abstract class VirusPlugin
    {
        public VirusPlugin()
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
        public virtual int InfectionTimeLimitMs
        {
            get { return 40000; }
        }
        public virtual Texture2D IconTexture
        {
            get { return PLGlobal.Instance.VirusBGTexture;  }
        }
        public virtual int MarketPrice
        {
            get { return 0; }
        }
        public virtual int CargoVisualID
        {
            get { return 1; }
        }
        public virtual bool CanBeDroppedOnShipDeath
        {
            get { return false; }
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
        public virtual void FinalLateAddStats(PLVirus InVirus)
        {
            
        }
    }
}
