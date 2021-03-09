using UnityEngine;

namespace DragonReactor.Components.NuclearDevice
{
    public abstract class NuclearDevicePlugin
    {
        public NuclearDevicePlugin()
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
            get { return (Texture2D)Resources.Load("Icons/80_Thrusters"); }
        }
        public virtual float MaxDamage
        {
            get { return 3800f; }
        }
        public virtual float Range
        {
            get { return 4000f; }
        }
        public virtual float FuelBurnRate
        {
            get { return 6f; }
        }
        public virtual float TurnRate
        {
            get { return .12f; }
        }
        public virtual float IntimidationBonus
        {
            get { return 10f; }
        }
        public virtual float Health
        {
            get { return 200f; }
        }
        public virtual int MarketPrice
        {
            get { return 6750; }
        }
        public virtual int CargoVisualID
        {
            get { return 15; }
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
    }
}
