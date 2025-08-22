# Bungus/Wungus Super Forms

This mod adds two Super forms usable by any survivors. 
### Bungus
The Bungus form can be activated once per stage if you have 7 or more Bustling Fungus. The form comes with the following effects...
- Increases damage by 6% for each Bustling Fungus you own
- Increases max health by 100%
- Increases armor by 200
- Decreases movement speed by 25%
### Wungus
The Wungus form can be activated once per stage if you have 7 or more Weeping Fungus. The form comes with the following effects...
- Increases damage by 4% for each Weeping Fungus you own
- Increases max health by 100%
- Increases sprinting speed by 50%
- For Sonic the Hedgehog, his Boost skill is upgraded to Weeping Boost, which has unique purple visual effects and does not drain the boost meter

This mod is built off of [HedgehogUtils'](https://github.com/DS-GAMING-SE/HedgehogUtils) Forms API. This mod goes over all the basics for making a Super form, such as creating necessary [EntityStates](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/tree/master/ExamplePlugin/MyEntityStates) and [Buffs](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/blob/master/ExamplePlugin/FormBuffs.cs), creating the [FormDef,](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/blob/master/ExamplePlugin/FormDefs.cs) and creating [skill](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/blob/master/ExamplePlugin/SkillDefs.cs) [upgrades](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/tree/master/ExamplePlugin/MyEntityStates/WungusBoost.cs) [for](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/blob/master/ExamplePlugin/SkillReplacer.cs) [Sonic's](https://github.com/DS-GAMING-SE/Sonic) skills if the [Sonic mod](https://thunderstore.io/package/ds_gaming/SonicTheHedgehog) is also being used (Also including support for Sonic's [Ancient Scepter](https://github.com/DS-GAMING-SE/HedgehogUtilsExampleForms/blob/master/ExamplePlugin/AncientScepter.cs) upgrade). This mod is meant to be used as a reference for anyone wanting to make their own Super forms. Feel free to copy this repository and use it as a base for your own Super form mods.