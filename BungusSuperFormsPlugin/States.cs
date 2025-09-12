using System.Collections.Generic;
using System;
using BungusSuperFormsMod.MyEntityStates;

namespace BungusSuperFormsMod
{
    public static class States
    {
        internal static void RegisterStates()
        {
            // ALL new entity states you create MUST be put here for multiplayer to function
            Internal.Content.AddEntityState(typeof(BungusState));
            Internal.Content.AddEntityState(typeof(WungusState));
            Internal.Content.AddEntityState(typeof(TransformationAnimation));

            if (BungusSuperFormsPlugin.sonicModLoaded)
            {
                RegisterSonicStates();

                if (BungusSuperFormsPlugin.ancientScepterLoaded)
                {
                    RegisterScepterStates();
                }
            }
        }

        internal static void RegisterSonicStates()
        {
            Internal.Content.AddEntityState(typeof(WungusBoost));
        }

        internal static void RegisterScepterStates()
        {
            Internal.Content.AddEntityState(typeof(ScepterWungusBoost));
        }
    }
}