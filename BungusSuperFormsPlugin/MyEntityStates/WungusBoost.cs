using EntityStates;
using RoR2;
using RoR2.Audio;
using RoR2.Skills;
using HedgehogUtils.Boost;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace BungusSuperFormsMod.MyEntityStates
{
    public class WungusBoost : HedgehogUtils.Boost.EntityStates.Boost // If you want to have Sonic's power boosting at high health mechanic, build your skill off of Sonic's NewBoost state
    {
        public override void OnEnter()
        {
            base.OnEnter();
            if (base.modelLocator) // This just makes the character tilt so they're always flat on the ground. Sonic does this in his normal state and all of his Boost states
            {
                modelLocator.normalizeToFloor = true;
            }
        }

        public override void OnExit()
        {
            if (base.modelLocator)
            {
                modelLocator.normalizeToFloor = false;
            }
            base.OnExit();
        }

        protected override BuffDef buff
        {
            get { return FormBuffs.wungusBoostBuff; }
        }

        public override GameObject GetFlashPrefab()
        {
            return Assets.wungusBoostFlash;
        }
        public override GameObject GetAuraPrefab()
        {
            return Assets.wungusBoostAura;
        }

        public override Material GetOverlayMaterial()
        {
            return null;
        }
    }
}