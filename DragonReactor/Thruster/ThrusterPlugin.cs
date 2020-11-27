﻿namespace DragonReactor
{
    public abstract class ThrusterPlugin
    {
        public ThrusterPlugin()
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
        public virtual float MaxOutput
        {
            get { return .115f; }
        }
        public virtual float MaxPowerUsage_Watts
        {
            get { return 1200f; }
        }
        public virtual int MarketPrice
        {
            get { return 1800; }
        }
        public virtual int CargoVisualID
        {
            get { return 8; }
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