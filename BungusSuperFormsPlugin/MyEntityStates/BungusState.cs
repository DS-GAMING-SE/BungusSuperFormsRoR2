using EntityStates;
using RoR2;
using RoR2.Audio;
using System;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BungusSuperFormsMod.MyEntityStates
{
    public class BungusState : HedgehogUtils.Forms.EntityStates.FormStateBase
    {
        private TemporaryOverlayInstance temporaryOverlay;
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
            Flash(0.5f);
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}