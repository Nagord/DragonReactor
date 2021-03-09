﻿using UnityEngine;

namespace DragonReactor.Components.InertiaThruster
{
    public abstract class InertiaThrusterPlugin
    {
        public InertiaThrusterPlugin()
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
            get { return (Texture2D)Resources.Load("Icons/81_Thrusters"); }
        }
        public virtual float MaxOutput
        {
            get { return .4f; }
        }
        public virtual float MaxPowerUsage_Watts
        {
            get { return 2600f; }
        }
        public virtual int MarketPrice
        {
            get { return 2600; }
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