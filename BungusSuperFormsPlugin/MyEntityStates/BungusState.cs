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
        private GameObject aura;
        public override void OnEnter()
        {
            base.OnEnter();
            Heal(1f);
            ApplyOverlay(ref temporaryOverlay, Assets.bungusSuperFormOverlay);
            Flash(0.5f);
            Transform chest = base.FindModelChild("Chest");
            if (chest)
            {
                this.aura = GameObject.Instantiate<GameObject>(Assets.bungusAura, chest);
            }
        }

        public override void OnExit()
        {
            RemoveOverlay(ref temporaryOverlay);
            Flash(0.5f);
            if (aura) Destroy(aura);
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }
    }
}