using System.Collections.Generic;
using System;
using ExampleFormsMod.MyEntityStates;

namespace ExampleFormsMod
{
    public static class States
    {
        internal static void RegisterStates()
        {
            // ALL new entity states you create MUST be put here for multiplayer to function
            Internal.Content.AddEntityState(typeof(BungusState));
            Internal.Content.AddEntityState(typeof(WungusState));
            Internal.Content.AddEntityState(typeof(TransformationAnimation));

            if (ExampleFormsPlugin.sonicModLoaded)
            {
                RegisterSonicStates();

                if (ExampleFormsPlugin.ancientScepterLoaded)
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