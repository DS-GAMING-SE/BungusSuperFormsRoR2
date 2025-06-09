using RoR2;
using System;
using UnityEngine;
using R2API;
using UnityEngine.Networking;
using HedgehogUtils.Forms;
using ExampleFormsMod.Internal;

namespace ExampleFormsMod
{
    public static class OnHooks
    {
        // Here I put the hooks used to make the Bungus form ignore most knockback
        // You probably won't need the hooks I use and will likely need your own, so this is separated into its own file to be easier to clean out
        public static void Initialize()
        {
            On.RoR2.HealthComponent.TakeDamageForce_DamageInfo_bool_bool += BungusKnockbackImmunity1;
            On.RoR2.HealthComponent.TakeDamageForce_Vector3_bool_bool += BungusKnockbackImmunity2;
        }

        public static void BungusKnockbackImmunity1(On.RoR2.HealthComponent.orig_TakeDamageForce_DamageInfo_bool_bool orig, HealthComponent health, DamageInfo damageInfo, bool alwaysApply, bool disableAirControlUntilCollision)
        {
            if (NetworkServer.active)
            {
                if (Forms.GetIsInForm(health.body, FormDefs.bungusSuperFormDef))
                {
                    return;
                }
            }
            orig(health, damageInfo, alwaysApply, disableAirControlUntilCollision);
        }
        public static void BungusKnockbackImmunity2(On.RoR2.HealthComponent.orig_TakeDamageForce_Vector3_bool_bool orig, HealthComponent health, Vector3 force, bool alwaysApply, bool disableAirControlUntilCollision)
        {
            if (NetworkServer.active)
            {
                if (Forms.GetIsInForm(health.body, FormDefs.bungusSuperFormDef))
                {
                    return;
                }
            }
            orig(health, force, alwaysApply, disableAirControlUntilCollision);
        }
    }
}