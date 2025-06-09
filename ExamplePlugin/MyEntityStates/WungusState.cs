using EntityStates;
using RoR2;
using RoR2.Audio;
using SonicTheHedgehog.Components;
using HedgehogUtils.Forms;
using System;
using System.Reflection;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ExampleFormsMod.MyEntityStates
{
    public class WungusState : HedgehogUtils.Forms.EntityStates.FormStateBase
    {
        private TemporaryOverlayInstance temporaryOverlay;

        private TemporaryOverlayInstance sprintingOverlay;
        private bool sprintingOverlayApplied;

        protected HedgehogUtils.Boost.BoostLogic boostLogic;

        public override void OnEnter()
        {
            base.OnEnter();
            Util.PlaySound("Play_voidman_m2_shoot", base.gameObject);
            Heal(1f);
            ApplyOverlay(ref temporaryOverlay, Assets.wungusSuperFormOverlay);
            Flash(0.5f);

            // This keeps the boost meter maxed and makes it look like the infinity symbol
            boostLogic = base.GetComponent<HedgehogUtils.Boost.BoostLogic>();
            if (boostLogic)
            {
                boostLogic.alwaysMaxBoost = true;
            }
        }

        public override void OnExit()
        {
            RemoveOverlay(ref temporaryOverlay);
            if (sprintingOverlayApplied)
            {
                RemoveOverlay(ref sprintingOverlay);
            }
            Flash(0.5f);

            // Remember to remove infinite boost when exiting
            if (boostLogic)
            {
                boostLogic.alwaysMaxBoost = false;
            }
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (base.characterBody.isSprinting)
            {
                if (!sprintingOverlayApplied)
                {
                    sprintingOverlayApplied = true;
                    ApplyOverlay(ref sprintingOverlay, Assets.wungusOutlineOverlay);
                }
            }
            else
            {
                if (sprintingOverlayApplied)
                {
                    sprintingOverlayApplied = false;
                    RemoveOverlay(ref sprintingOverlay);
                }
            }
        }
    }
}