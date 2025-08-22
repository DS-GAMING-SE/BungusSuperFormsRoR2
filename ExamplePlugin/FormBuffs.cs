using RoR2;
using System.Collections.Generic;
using UnityEngine;

namespace ExampleFormsMod
{
    public static class FormBuffs
    {
        // The buff applied by a Form must be a unique buff that isn't used for anything else
        internal static BuffDef bungusFormBuff;

        internal static BuffDef wungusFormBuff;

        // This buff is used for Sonic's Wungus form skill upgrade
        internal static BuffDef wungusBoostBuff;

        internal static void RegisterBuffs()
        {
            bungusFormBuff = AddNewBuff("bdBungusForm",
                Assets.mainAssetBundle.LoadAsset<Sprite>("texBungusBuffIcon"),
                new Color(0.1f, 7f, 0.5f),
                false,
                false);
            wungusFormBuff = AddNewBuff("bdWungusForm",
                Assets.mainAssetBundle.LoadAsset<Sprite>("texWungusBuffIcon"),
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