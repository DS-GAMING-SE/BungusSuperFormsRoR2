using RoR2;
using System;
using UnityEngine;
using R2API;

namespace ExampleFormsMod
{
    public static class Language
    {
        //maybe go back to what the mod had by default with the separate lang file
        public static void Initialize()
        {
            #region Bungus Form
            // The name of the form
            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "BUNGUS_SUPER_FORM", "Bungus");

            // The name prefix/suffix that will be added when transformed, similar to the names of elites
            // {0} will be replaced with whatever the character's normal name is
            // Eg. "Super {0}" would be Super Sonic
            // If you don't want any name change, comment out the line of code below
            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "BUNGUS_SUPER_FORM_PREFIX", "Bustling {0}");
            #endregion

            #region Wungus Form
            // The name of the form
            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "WUNGUS_SUPER_FORM", "Wungus");

            // The name prefix/suffix that will be added when transformed, similar to the names of elites
            // {0} will be replaced with whatever the character's normal name is
            // Eg. "Super {0}" would be Super Sonic
            // If you don't want any name change, comment out the line of code below
            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "WUNGUS_SUPER_FORM_PREFIX", "Weeping {0}");

            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_NAME", "Weeping Boost");
            LanguageAPI.Add(ExampleFormsPlugin.Prefix + "UTILITY_WUNGUS_BOOST_DESCRIPTION", $"<style=cIsUtility>Move 65% faster</style> than normal.");
            #endregion
        }
    }
}