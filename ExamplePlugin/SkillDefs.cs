using RoR2;
using System;
using UnityEngine;
using R2API;
using RoR2.Skills;
using HedgehogUtils.Boost;
using HedgehogUtils.Forms;


namespace ExampleFormsMod
{
    public static class SkillDefs
    {
        public static HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef wungusBoost;

        public static void Initialize()
        {
            // Use HedgehogUtils.CopySkillDef, HedgehogUtils.CopyBoostSkillDef, or SonicTheHedgehog.Modules.SkillDefs.CopyMeleeSkillDef to copy the existing skilldef so you don't accidentally change the original skilldef
            // This is using the CopyBoostSkillDef method to convert Sonic's BoostSkillDef into a RequiresFormBoostSkillDef
            // SkillDefs of the RequiresFormBoostSkillDef type will automatically remove themselves if the character using it is not currently in the given form
            wungusBoost = HedgehogUtils.Helpers.CopyBoostSkillDef<HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef>(SonicTheHedgehog.Modules.Survivors.SonicSkillDefs.boostSkillDef);
            wungusBoost.skillName = ExampleFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            wungusBoost.skillNameToken = ExampleFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            wungusBoost.skillDescriptionToken = ExampleFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_DESCRIPTION";
            wungusBoost.icon = Assets.mainAssetBundle.LoadAsset<Sprite>("texWungusBoostIcon");
            wungusBoost.activationState = new EntityStates.SerializableEntityStateType(typeof(MyEntityStates.WungusBoost));
            wungusBoost.requiredForm = FormDefs.wungusSuperFormDef;
            wungusBoost.boostHUDColor = new Color(1f, 0f, 1f);
        }
    }
}