using RimWorld;
using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;
using Verse.Sound;

namespace LaserWeapons
{
    public class CompExtraDamage : ThingComp
    {
        public CompProperties_ExtraDamage compProp;
        public string damageDef;
        public int damageAmount;
        public float chanceToProc;
        public int count;
        public override void Initialize(CompProperties vprops)
        {
            base.Initialize(vprops);
            this.compProp = (vprops as CompProperties_ExtraDamage);
            if (this.compProp != null)
            {
                this.damageDef = this.compProp.damageDef;
                this.damageAmount = this.compProp.damageAmount;
                this.chanceToProc = this.compProp.chanceToProc;
            }
            else
            {
                Log.Warning("Could not find a CompProperties_ExtraDamage for CompExtraDamage.");
                this.count = 9876;
            }
        }
        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look<int>(ref this.count, "count", 1, false);
        }
    }
}
