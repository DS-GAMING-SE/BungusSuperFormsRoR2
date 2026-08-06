using RoR2;
using System;
using UnityEngine;
using System.IO;
using R2API;
using UnityEngine.AddressableAssets;
using System.Reflection;
using HedgehogUtils;
using RoR2.ContentManagement;

namespace BungusSuperFormsMod
{
    public static class Assets
    {
        // CHANGE THIS
        private const string assetbundleName = "bungussuperformsbundle";
        //change this to your project's name if/when you've renamed it
        private const string dllName = "BungusSuperFormsMod.dll";

        internal static AssetBundle mainAssetBundle;

        public static GameObject bungusAura;
        public static Material bungusSuperFormOverlay;
        public static Material bungusOutlineOverlay;

        public static GameObject wungusAura;
        public static Material wungusSuperFormOverlay;
        public static Material wungusOutlineOverlay;

        public static GameObject wungusBoostFlash;
        public static GameObject wungusBoostAura;
        public static void Initialize()
        {
            LoadAssetBundle();
            CreateMaterials();
            CreateAuras();
        }

        // The assetbundle will contain assets made/imported through Unity, such as images, meshes, prefabs, etc.
        // Put any assets you make in the AssetBundle folder in the Unity project for it to be included in the assetbundle
        // Use the AssetBundle Browser found in the Window menu to build the asset bundle. By default, it will be built to UnityProject/SonicFormsExample/AssetBundles/StandaloneWindows
        // The file for the asset bundle needs to be put in the same folder as the dll when trying to run the mod
        // You can change the default location the assetbundle will be placed when it's built so you won't have to manually move the file every time
        internal static void LoadAssetBundle()
        {
            try
            {
                if (mainAssetBundle == null)
                {
                    mainAssetBundle = AssetBundle.LoadFromFile(Assembly.GetExecutingAssembly().Location.Replace(dllName, assetbundleName));
                }
            }
            catch (Exception e)
            {
                Log.Error("Failed to load assetbundle. Make sure your assetbundle name is setup correctly\n" + e);
                return;
            }
        }

        public static void CreateMaterials()
        {
            // Here i'm copying and slightly modifying existing RoR2 materials to make overlays that will be put on survivors when transformed
            // If you're interested in knowing how to find good RoR2 shaders, look into AssetRipper and Addressable Asset Keys
            // If you're interested in making materials from scratch using RoR2 shaders, look into stubbed shaders and shader swapper
            bungusSuperFormOverlay = new Material(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/EliteVoid/matEliteVoidOverlay.mat").WaitForCompletion());
            bungusSuperFormOverlay.SetTexture("_RemapTex", Addressables.LoadAssetAsync<Texture>("RoR2/Base/Common/ColorRamps/texRampLoaderSwing.png").WaitForCompletion());
            bungusSuperFormOverlay.SetFloat("_AlphaBoost", 4f);

            // Make sure to say new Material(whatever) here or else you will edit the existing material
            bungusOutlineOverlay = new Material(Addressables.LoadAssetAsync<Material>("RoR2/Base/LunarGolem/matLunarGolemShield.mat").WaitForCompletion()); // Good opaque outline material
            bungusOutlineOverlay.SetColor("_TintColor", new Color(0.25f, 1f, 0.6f, 1));
            bungusOutlineOverlay.SetColor("_EmissionColor", new Color(0.25f, 1f, 0.6f, 0.5f));
            bungusOutlineOverlay.SetFloat("_OffsetAmount", 0.01f); // Larger number = larger outline

            wungusSuperFormOverlay = new Material(Addressables.LoadAssetAsync<Material>("RoR2/DLC1/EliteVoid/matEliteVoidOverlay.mat").WaitForCompletion());

            wungusOutlineOverlay = new Material(bungusOutlineOverlay);
            wungusOutlineOverlay.SetColor("_TintColor", new Color(0.9f, 0.1f, 0.75f, 1));
            wungusOutlineOverlay.SetColor("_EmissionColor", new Color(0.9f, 0.1f, 0.75f, 0.5f));

            // Creating the Wungus form's custom boost vfx using a method from HedgehogUtils

            // A lot of RoR2 vfx uses what is referred to as a "remap" or "ramp" texture, which changes the colors of certain parts of a material based on its opacity
            // If you want multi-colored boost vfx, I suggest looking to those
            // For simpler boost vfx, you can skip the texture stuff and simply provide a color to the CreateBoostFlashEffect method
            wungusBoostAura = HedgehogUtils.Assets.CreateBoostAuraEffect(BungusSuperFormsPlugin.Prefix + "WUNGUS_BOOST_AURA",
                AssetAsyncReferenceManager<Texture>.LoadAsset(new AssetReferenceT<Texture>(RoR2BepInExPack.GameAssetPaths.Version_1_39_0.RoR2_DLC1_VoidSurvivor.texRampVoidSurvivorBase1_png)).WaitForCompletion(),
                new Color(0.9f, 0.1f, 1f));
            wungusBoostFlash = HedgehogUtils.Assets.CreateBoostFlashEffect(BungusSuperFormsPlugin.Prefix + "WUNGUS_BOOST_FLASH",
                AssetAsyncReferenceManager<Texture>.LoadAsset(new AssetReferenceT<Texture>(RoR2BepInExPack.GameAssetPaths.Version_1_39_0.RoR2_DLC1_VoidSurvivor.texRampVoidSurvivorBase1_png)).WaitForCompletion(),
                new Color(0.9f, 0.1f, 1f));
        }

        public static void CreateAuras()
        {
            bungusAura = HedgehogUtils.Assets.CreateSuperAura("BungusAura", new Color(0.1f, 1f, 0.5f));
            AssetAsyncReferenceManager<Texture>.LoadAsset(new AssetReferenceT<Texture>(RoR2BepInExPack.GameAssetPaths.Version_1_39_0.RoR2_DLC1_VoidSurvivor.texRampVoidSurvivorBase1_png)).Completed += (x) =>
            {
                wungusAura = HedgehogUtils.Assets.CreateSuperAura("WungusAura", new Color(0.8f, 0.4f, 0.8f), x.Result);
            };
        }
    }
}