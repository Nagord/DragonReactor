using UnityEngine;

namespace DragonReactor.Components.Reactor
{
    public abstract class ReactorPlugin
    {
        public ReactorPlugin()
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
        public virtual Texture2D IconTexture
        {
            get { return (Texture2D)Resources.Load("Icons/28_Reactor"); }
        }
        public virtual float EnergyOutputMax
        {
            get { return 15000f; }
        }
        public virtual float EnergySignatureAmount
        {
            get { return 18f; }
        }
        public virtual float MaxTemp
        {
            get { return 1800f; }
        }
        public virtual float EmergencyCooldownTime
        {
            get { return 20f; }
        }
        public virtual float HeatOutput
        {
            get { return 1f; }
        }
        public virtual int MarketPrice
        {
            get { return 2100; }
        }
        public virtual int CargoVisualID
        {
            get { return 11; }
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
        public virtual void ReactorPowerCode(PLReactor ReactorInstance)
        {
        }
    }
}
