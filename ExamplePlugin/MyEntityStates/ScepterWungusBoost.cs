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
    // Starting with ScepterBoostBase so it has the scepter boost damage effect but doesn't have Power Boosting
    // If you want Power Boosting, start from NewScepterBoost instead
    public class ScepterWungusBoost : SonicTheHedgehog.SkillStates.ScepterBoostBase
    {
        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        protected override BuffDef buff
        {
            get { return FormBuffs.wungusBoostBuff; }
        }

        public override GameObject GetFlashPrefab()
        {
            return AncientScepter.scepterWungusBoostFlash;
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