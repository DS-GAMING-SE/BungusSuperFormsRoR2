using RoR2;
using System;
using UnityEngine;
using R2API;
using RoR2.Skills;
using HedgehogUtils.Boost;
using HedgehogUtils.Forms;
using BungusSuperFormsMod.MyEntityStates;
using AncientScepter;


namespace BungusSuperFormsMod
{
    // Everything related to compatibility with the Ancient Scepter mod is in this file
    // The Ancient Scepter upgrades Sonic's utility skill, so it's recommended to make a scepter upgrade for any custom Sonic skills that replace his utility skill
    // If you're not making a custom skill for Sonic's utility skill or any other survivors' scepter upgradeable skill slot, this file and the entire AncientScepter assembly can be removed
    public static class AncientScepter
    {
        public static GameObject scepterWungusBoostFlash;

        public static HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef scepterWungusBoost;

        public static void Initialize()
        {
            scepterWungusBoostFlash = HedgehogUtils.Assets.CreateNewBoostFlash(BungusSuperFormsPlugin.Prefix + "SCEPTER_WUNGUS_BOOST_FLASH", 1.15f, 1.4f,
                new Color(0f, 0f, 0f), // Inner color
                new Color(1f, 0f, 1f), // Middle color
                new Color(1f, 0.8f, 1f), // Outer color
                new Color(1f, 0f, 1f)); // Light
            SonicTheHedgehog.Modules.Assets.AddScepterToBoostFlash(scepterWungusBoostFlash);

            CreateScepterWungusBoost();

            ItemBase<AncientScepterItem>.instance.RegisterScepterSkill(scepterWungusBoost, "SonicTheHedgehog", SkillDefs.wungusBoost);
        }

        private static void CreateScepterWungusBoost()
        {
            // Use HedgehogUtils.CopySkillDef, HedgehogUtils.CopyBoostSkillDef, or SonicTheHedgehog.Modules.SkillDefs.CopyMeleeSkillDef to copy the existing skilldef so you don't accidentally change the original skilldef
            // This is using the CopyBoostSkillDef method to convert Sonic's BoostSkillDef into a RequiresFormBoostSkillDef
            // SkillDefs of the RequiresFormBoostSkillDef type will automatically remove themselves if the character using it is not currently in the given form
            scepterWungusBoost = HedgehogUtils.Helpers.CopyBoostSkillDef<HedgehogUtils.Boost.SkillDefs.RequiresFormBoostSkillDef>(SkillDefs.wungusBoost);
            scepterWungusBoost.skillName = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            scepterWungusBoost.skillNameToken = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME";
            scepterWungusBoost.skillDescriptionToken = BungusSuperFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_DESCRIPTION";
            scepterWungusBoost.icon = Assets.mainAssetBundle.LoadAsset<Sprite>("texWungusBoostIcon");
            scepterWungusBoost.requiredForm = FormDefs.wungusSuperFormDef;
            scepterWungusBoost.activationState = new EntityStates.SerializableEntityStateType(typeof(MyEntityStates.ScepterWungusBoost));
        }
    }
}