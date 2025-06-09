using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleFormsMod
{
    public static class FormBuffs
    {
        internal static BuffDef bungusFormBuff;

        internal static BuffDef wungusFormBuff;
        internal static BuffDef wungusBoostBuff;

        internal static void RegisterBuffs()
        {
            bungusFormBuff = AddNewBuff("bdBungusForm",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/CloakSpeed").iconSprite,
                new Color(0.1f, 1f, 0.3f),
                false,
                false);
            wungusFormBuff = AddNewBuff("bdWungusForm",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/CloakSpeed").iconSprite,
                new Color(0.8f, 0.4f, 0.8f),
                false,
                false);
            wungusBoostBuff = AddNewBuff("bdWungusBoost",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/CloakSpeed").iconSprite,
                new Color(0.8f, 0.4f, 0.8f),
                false,
                false);
        }

        // simple helper method
        internal static BuffDef AddNewBuff(string buffName, Sprite buffIcon, Color buffColor, bool canStack, bool isDebuff)
        {
            BuffDef buffDef = ScriptableObject.CreateInstance<BuffDef>();
            buffDef.name = buffName;
            buffDef.buffColor = buffColor;
            buffDef.canStack = canStack;
            buffDef.isDebuff = isDebuff;
            buffDef.eliteDef = null;
            buffDef.iconSprite = buffIcon;

            Internal.Content.AddBuffDef(buffDef);

            return buffDef;
        }
    }
}