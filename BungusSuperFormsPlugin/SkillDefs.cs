using RoR2;
using System;
using UnityEngine;
using R2API;
using RoR2.Skills;
using HedgehogUtils.Boost;
using HedgehogUtils.Forms;


namespace BungusSuperFormsMod
{
    public static class SkillDefs
    {
        public static HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef wungusBoost;

        public static void Initialize()
        {
            if (BungusSuperFormsPlugin.sonicModLoaded)
            {
                CreateSonicWungusBoost();
            }
        }

        private static void CreateSonicWungusBoost()
        {
            // Use HedgehogUtils.CopySkillDef, HedgehogUtils.CopyBoostSkillDef, or SonicTheHedgehog.Modules.SkillDefs.CopyMeleeSkillDef to copy the existing skilldef so you don't accidentally change the original skilldef
            // This is using the CopyBoostSkillDef method to convert Sonic's BoostSkillDef into a RequiresFormBoostSkillDef
            // SkillDefs of the RequiresFormSkillDef or RequiresFormBoostSkillDef type will automatically remove themselves if the character using it is not currently in the given form
            wungusBoost = HedgehogUtils.Helpers.CopyBoostSkillDef<HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef>(SonicTheHedgehog.Modules.Survivors.SonicSkillDefs.boostSkillDef);
            wungusBoost.skillName = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            wungusBoost.skillNameToken = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            wungusBoost.skillDescriptionToken = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_DESCRIPTION";
            wungusBoost.icon = Assets.mainAssetBundle.LoadAsset<Sprite>("texWungusBoostIcon");
            wungusBoost.activationState = new EntityStates.SerializableEntityStateType(typeof(MyEntityStates.WungusBoost));
            wungusBoost.requiredForm = FormDefs.wungusSuperFormDef;
            wungusBoost.boostHUDColor = new Color(0.8f, 0.4f, 0.8f);

            if (BungusSuperFormsPlugin.ancientScepterLoaded)
            {
                AncientScepter.Initialize();
            }
        }
    }
}