using EntityStates;
using RoR2;
using RoR2.Audio;
using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace ExampleFormsMod.MyEntityStates
{
    public class BungusState : HedgehogUtils.Forms.EntityStates.FormStateBase
    {
        private TemporaryOverlayInstance temporaryOverlay;

        private TemporaryOverlayInstance notMovingOverlay;
        private bool notMovingOverlayApplied;

        public override void OnEnter()
        {
            base.OnEnter();
            Heal(1f);
            ApplyOverlay(ref temporaryOverlay, Assets.bungusSuperFormOverlay);
            Flash(0.5f);
        }

        public override void OnExit()
        {
            RemoveOverlay(ref temporaryOverlay);

            if (notMovingOverlayApplied) // If you have the outline from not moving, remove it when the form ends
            {
                RemoveOverlay(ref notMovingOverlay);
            } // Feel free to delete this scetion about the not moving overlay if you're making your own form

            Flash(0.5f);
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.characterBody.GetNotMoving()) // Adds an outline around you when you're not moving
            {
                if (!notMovingOverlayApplied)
                {
                    notMovingOverlayApplied = true;
                    ApplyOverlay(ref notMovingOverlay, Assets.bungusOutlineOverlay);
                }
            }
            else
            {
                if (notMovingOverlayApplied)
                {
                    notMovingOverlayApplied = false;
                    RemoveOverlay(ref notMovingOverlay);
                }
            } // Feel free to delete this scetion about the not moving overlay if you're making your own form

        }
    }
}