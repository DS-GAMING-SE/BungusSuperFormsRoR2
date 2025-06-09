using EntityStates;
using RoR2;
using RoR2.Audio;
using RoR2.Skills;
using HedgehogUtils.Boost;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace ExampleFormsMod.MyEntityStates
{
    public class WungusBoost : HedgehogUtils.Boost.EntityStates.Boost // If you want to have Sonic's power boosting at high health mechanic, build your skill off of Sonic's NewBoost state
    {
        public override void OnEnter()
        {
            base.OnEnter();
            if (base.modelLocator)
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

        protected override float boostMeterDrain
        {
            get { return 0; }
        }
        protected override float boostStartMeterDrain
        {
            get { return 0; }
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