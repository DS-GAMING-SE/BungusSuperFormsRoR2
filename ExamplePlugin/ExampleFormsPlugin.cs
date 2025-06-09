using BepInEx;
using R2API;
using HedgehogUtils;
using RoR2;
using SonicTheHedgehog.Modules;
using System.Reflection;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ExampleFormsMod
{
    // This is an example plugin that can be put in
    // BepInEx/plugins/ExampleFormsMod/ExampleFormsMod.dll to test out.

    // All Sonic related forms are built using the HedgehogUtils mod
    [BepInDependency(HedgehogUtilsPlugin.PluginGUID)]

    // Having Sonic as a soft dependency means that our mod will load after the Sonic mod. This is important since we need to use stuff from the Sonic mod to make the..
    // ..Sonic specific transformation effects, like the new skill upgrades
    [BepInDependency("com.ds_gaming.SonicTheHedgehog", BepInDependency.DependencyFlags.SoftDependency)]

    // This one is because we use a .language file for language tokens
    // More info in https://risk-of-thunder.github.io/R2Wiki/Mod-Creation/Assets/Localization/
    [BepInDependency(LanguageAPI.PluginGUID)]

    // This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    // This is the main declaration of our plugin class.
    // BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    // BaseUnityPlugin itself inherits from MonoBehaviour,
    // so you can use this as a reference for what you can declare and use in your plugin class
    // More information in the Unity Docs: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class ExampleFormsPlugin : BaseUnityPlugin
    {
        // The Plugin GUID should be a unique ID for this plugin,
        // which is human readable (as it is used in places like the config).
        // If we see this PluginGUID as it is on thunderstore,
        // we will deprecate this mod.
        // Change the PluginAuthor, Prefix, and the PluginName !
        public const string PluginGUID = "com.ds_gaming.BungusSuperForm";
        public const string PluginAuthor = "ds_gaming";
        public const string PluginName = "BungusSuperForm";
        public const string PluginVersion = "1.0.0";

        public const string Prefix = "DS_GAMING_EXAMPLE_FORMS_";

        // The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            // Init our logging class so that we can properly log for debugging
            Internal.Log.Init(Logger);

            Assets.Initialize();

            FormBuffs.RegisterBuffs();

            FormDefs.Initialize();

            SkillDefs.Initialize();

            Stats.Initialize();

            Language.Initialize();

            OnHooks.Initialize();

            new Internal.ContentPacks().Initialize();
        }
    }
}
