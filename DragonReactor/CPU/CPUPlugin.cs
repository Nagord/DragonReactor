using UnityEngine;

namespace DragonReactor.CPU
{
    public abstract class CPUPlugin
    {
        public CPUPlugin()
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
        public virtual float Speed
        {
            get { return .7f; }
        }
        public virtual float Defense
        {
            get { return .1f; }
        }
        public virtual Texture2D IconTexture
        {
            get { return (Texture2D)Resources.Load("Icons/62_Processer");  }
        }
        public virtual int SysInstConduit
        {
            get { return -1; }
        }
        
        public virtual int MarketPrice
        {
            get { return 1200; }
        }
        public virtual float MaxPowerUsage_Watts
        {
            get { return 1f; }
        }
        public virtual int CargoVisualID
        {
            get { return 1; }
        }
        public virtual int MaxCompUpgradeLevelBoost
        {
            get { return 0; }
        }
        public virtual int MaxItemUpgradeLevelBoost
        {
            get { return 0; }
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
        public virtual void FinalLateAddStats(PLCPU InCPU)
        {
            
        }
        public virtual void AddStats(PLCPU InCPU)
        {

        }
        public virtual void Tick(PLCPU InCPU)
        {

        }
        public virtual void WhenProgramIsRun(PLWarpDriveProgram inProgram)
        {

        }
        public virtual string GetStatLineRight(PLCPU InCPU)
        {
            return "";
        }
        public virtual string GetStatLineLeft(PLCPU InCPU)
        {
            return "";
        }
    }
}
