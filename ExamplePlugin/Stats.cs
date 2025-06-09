using RoR2;
using System;
using UnityEngine;
using R2API;

namespace ExampleFormsMod
{
    public static class Stats
    {
        public static void Initialize()
        {
            RecalculateStatsAPI.GetStatCoefficients += RecalculateStats;
            On.RoR2.CharacterBody.RecalculateStats += RecalcStatAPIDoesntHaveAcceleration;
        }

        public static void RecalculateStats(CharacterBody self, RecalculateStatsAPI.StatHookEventArgs stats)
        {
            #region Bungus Form
            if (self.HasBuff(FormBuffs.bungusFormBuff))
            {
                stats.moveSpeedReductionMultAdd += 0.5f;
                stats.armorAdd += 200;
                stats.healthMultAdd += 1;
                if (self.inventory)
                {
                    stats.damageMultAdd += (0.06f * self.inventory.GetItemCount(RoR2Content.Items.Mushroom));
                }
            }
            #endregion

            #region Wungus Form
            if (self.HasBuff(FormBuffs.wungusFormBuff))
            {
                stats.sprintSpeedAdd += 0.5f;
                stats.healthMultAdd += 1;
                if (self.inventory)
                {
                    stats.damageMultAdd += (0.04f * self.inventory.GetItemCount(DLC1Content.Items.MushroomVoid));
                }
            }

            if (self.HasBuff(FormBuffs.wungusBoostBuff))
            {
                // Boost's speed increases are done in a very particular way so there is a method created for converting normal percentages to Boost's weird calculation
                // Part of the speed boost given by boost is an increase to base movement speed instead of all being an increase to the movement speed multiplier
                // This makes the boost's speed increase stronger if you already have other movement speed increases, so boost doesn't become obsolete with other movement speed items
                HedgehogUtils.Boost.BoostLogic.BoostStats(self, stats, 0.65f);
            }
            #endregion
        }

        private static void RecalcStatAPIDoesntHaveAcceleration(On.RoR2.CharacterBody.orig_RecalculateStats orig, CharacterBody self)
        {
            orig(self); // Increasing acceleration stat is pretty important for forms that fly. RecalculateStatsAPI can't do acceleration so it has to be done in a hook like this
            if (self.HasBuff(FormBuffs.wungusFormBuff))
            {
                self.acceleration *= 3;
            }
        }
    }
}