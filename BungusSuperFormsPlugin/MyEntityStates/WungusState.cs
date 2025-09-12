using EntityStates;
using RoR2;
using RoR2.Audio;
using HedgehogUtils.Forms;
using System;
using System.Reflection;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace BungusSuperFormsMod.MyEntityStates
{
    public class WungusState : HedgehogUtils.Forms.EntityStates.FormStateBase
    {
        private TemporaryOverlayInstance temporaryOverlay;

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
        }
    }
}