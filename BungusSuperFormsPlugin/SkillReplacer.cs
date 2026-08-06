using System.Collections.Generic;
using System;
using BungusSuperFormsMod.MyEntityStates;
using RoR2;
using HedgehogUtils.Forms;
using HedgehogUtils.Boost;
using RoR2.Skills;
using EntityStates;
using UnityEngine;


namespace BungusSuperFormsMod
{
    public class SkillReplacer : MonoBehaviour
    {
        // Skill replacements from super forms are done using a component put on the character you want to have skills replaced
        // We need to define what characters we are going to give this component to AFTER we're sure that the characters have been loaded
        // The SystemInitializer will automatically run this function as soon as the BodyCatalog is initialized, meaning all characters have been loaded and finalized
        [SystemInitializer(typeof(BodyCatalog))]
        internal static void AddSkillReplacerComponent()
        {
            if (BungusSuperFormsPlugin.sonicModLoaded)
            {
                BodyCatalog.FindBodyPrefab("SonicTheHedgehog").AddComponent<SkillReplacer>();
            }
        }

        private FormComponent formComponent;
        private CharacterBody body;

        public void Start()
        {
            formComponent = base.GetComponent<FormComponent>();
            if (formComponent)
            {
                body = base.GetComponent<CharacterBody>();
                formComponent.OnFormChanged += FormChanged;
            }
            else
            {
                Destroy(this);
            }
        }

        public void OnDestroy()
        {
            formComponent.OnFormChanged -= FormChanged;
        }

        public void FormChanged(FormDef previous, FormDef active)
        {
            if (!Util.HasEffectiveAuthority(base.gameObject)) { return; }
            if (active == FormDefs.wungusSuperFormDef)
            {
                SkillOverrides();
            }
            // Removal of Super Upgrade skills is part of the HedgehogUtils.Forms.SkillDefs.RequiresFormSkillDef type of SkillDef
        }

        public void SkillOverrides()
        {
            if (body && body.skillLocator && body.skillLocator.utility)
            {
                if (body.skillLocator.utility.baseSkill == SonicTheHedgehog.Modules.Survivors.SonicTheHedgehogCharacter.boostSkillDef)
                {
                    body.skillLocator.utility.SetSkillOverride(this, SkillDefs.wungusBoost, GenericSkill.SkillOverridePriority.Upgrade);
                }
            }
        }
    }
}