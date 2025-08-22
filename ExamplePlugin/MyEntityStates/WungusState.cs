using EntityStates;
using RoR2;
using RoR2.Audio;
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
            Util.PlaySound("Play_item_void_critGlasses", base.gameObject);
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

            if (sprintingOverlayApplied) // If you have the outline from sprinting, remove it when the form ends
            {
                RemoveOverlay(ref sprintingOverlay);
            } // Feel free to delete this scetion about the sprinting overlay if you're making your own form

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

            if (base.characterBody.isSprinting) // Adds an outline around you when you're sprinting
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
            } // Feel free to delete this scetion about the sprinting overlay if you're making your own form
        }
    }
}