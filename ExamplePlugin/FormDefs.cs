using BepInEx;
using R2API;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using SonicTheHedgehog.Modules;
using HedgehogUtils.Forms;
using System;
using EntityStates;
using System.Collections.Generic;
using ExampleFormsMod.MyEntityStates;

[assembly: HG.Reflection.SearchableAttribute.OptIn] // This line is required to make the SystemInitializer attribute run (see bottom of this file)
namespace ExampleFormsMod
{
    public static class FormDefs
    {
        public static FormDef bungusSuperFormDef;
        public static FormDef wungusSuperFormDef;

        public static void Initialize()
        {
            bungusSuperFormDef = Forms.CreateFormDef(
                // Name token of the form. This is an internal name and won't be seen by players
                // The actual name that players will see will be assigned in the Language.cs file
                ExampleFormsPlugin.Prefix + "BUNGUS_SUPER_FORM",

                // The buff that will be applied when transformed. This should be a unique buff used only for this form
                FormBuffs.bungusFormBuff,

                // Duration of the form in seconds. If 0 or less, the form will not have a timer
                30,

                // Whether the form requires having certain items to transform. These items will be defined later
                true,

                // Whether the items needed for this form can be shared between players, allowing players to transform if all items are collected but split up amongst players
                false,

                // Whether all the items needed to transform will be consumed on use
                false,

                // The number of times a player is allowed to transform into this form per stage. If 0 or less, there is no limit
                1,

                // Whether players are invincible while transformed
                false,

                // Whether players can fly while transformed
                false,

                // Whether Sonic will have his Super Sonic animations while in this form
                // This includes "flying" in his idles and movement, as well as other animations made under the assumption that his quills are pointing up
                false,

                // The entity state that handles the Form itself. Used on the SonicForms state machine
                new SerializableEntityStateType(typeof(MyEntityStates.BungusState)),

                // The entity state for the transforming animation. Used on the Body state machine
                new SerializableEntityStateType(typeof(MyEntityStates.TransformationAnimation)),

                // A dictionary containing the material and mesh swaps for characters who have a unique change in appearance when transforming
                /*new Dictionary<string, RenderReplacements>
                {
                    { "DS_GAMING_SONIC_THE_HEDGEHOG_BODY_DEFAULT_SKIN_NAME", new RenderReplacements { material = Materials.CreateHopooMaterial("matSuperSonic"), mesh = Assets.mainAssetBundle.LoadAsset<GameObject>("SuperSonicMesh").GetComponent<SkinnedMeshRenderer>().sharedMesh } },
                    { "DS_GAMING_SONIC_THE_HEDGEHOG_BODY_MASTERY_SKIN_NAME", new RenderReplacements { material = Materials.CreateHopooMaterial("matSuperMetalSonic"), mesh = null } }
                };*/
                null,

                // The type of FormHandler used to keep track of this form.
                // Put FormHandler here unless you need to custom make a formhandler, usually for extra specific transforming requirements that aren't covered normally
                typeof(FormHandler),

                // What is allowed to transform into this form? Body names refer to the internal name of the survivor/enemy
                // Be sure to check the names because they often aren't the same as the real name of the character
                new AllowedBodyList { whitelist = false, bodyNames = Array.Empty<string>() },

                // The default key bind for transforming into this form
                KeyCode.B
            );


            wungusSuperFormDef = Forms.CreateFormDef(
                // Name token of the form. This is an internal name and won't be seen by players
                ExampleFormsPlugin.Prefix + "WUNGUS_SUPER_FORM",

                // The buff that will be applied when transformed. This should be a unique buff used only for this form
                FormBuffs.wungusFormBuff,

                // Duration of the form in seconds. If 0 or less, the form will not have a timer
                30,

                // Whether the form requires having certain items to transform. These items will be defined later
                true,

                // Whether the items needed for this form can be shared between players, allowing players to transform if all items are collected but split up amongst players
                false,

                // Whether all the items needed to transform will be consumed on use
                false,

                // The number of times a player is allowed to transform into this form per stage. If 0 or less, there is no limit
                1,

                // Whether players are invincible while transformed
                false,

                // Whether players can fly while transformed
                true,

                // Whether Sonic will have his Super Sonic animations while in this form
                // This includes "flying" in his idles and movement, as well as other animations made under the assumption that his quills are pointing up
                true,

                // The entity state that handles the Form itself. Used on the SonicForms state machine
                new SerializableEntityStateType(typeof(MyEntityStates.WungusState)),

                // The entity state for the transforming animation. Used on the Body state machine
                new SerializableEntityStateType(), // Invalid entity state like this means there won't be a transformation animation

                // A dictionary containing the material and mesh swaps for characters who have a unique change in appearance when transforming
                new Dictionary<string, RenderReplacements>
                {
                    { "DS_GAMING_SONIC_THE_HEDGEHOG_BODY_DEFAULT_SKIN_NAME", new RenderReplacements { material = null, mesh = SonicTheHedgehog.Modules.Assets.superSonicMesh } }
                },

                // The type of FormHandler used to keep track of this form
                // Put FormHandler here unless you need to custom make a formhandler, usually for extra specific transforming requirements that aren't covered normally
                typeof(FormHandler),

                // What is allowed to transform into this form? Body names refer to the internal name of the survivor/enemy
                // Be sure to check the names because they often aren't the same as the real name of the character
                new AllowedBodyList { whitelist = false, bodyNames = Array.Empty<string>() },

                // The default key bind for transforming into this form
                KeyCode.B
            );
            FormCatalog.AddFormDefs(new FormDef[]
            {
                bungusSuperFormDef,
                wungusSuperFormDef
            });
        }

        // We need to define what items we are going to use for our forms AFTER all the items have been loaded
        // The SystemInitializer will automatically run this function as soon as the ItemCatalog is initialized, meaning all items have been loaded and their itemIndexes are finalized
        [SystemInitializer(typeof(ItemCatalog))]
        public static void InitializeFormItemRequirements()
        {
            bungusSuperFormDef.neededItems = new NeededItem[] { new NeededItem { item = RoR2Content.Items.Mushroom.itemIndex, count = 7 } };
            wungusSuperFormDef.neededItems = new NeededItem[] { new NeededItem { item = DLC1Content.Items.MushroomVoid.itemIndex, count = 7 } };
        }
    }

}
