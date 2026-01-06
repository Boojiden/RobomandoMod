using BepInEx;
using RobomandoMod.Survivors.Robomando;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using R2API.Networking;
using RobomandoMod.Survivors.Robomando.SkillStates;
using UnityEngine;
using ItemQualities;
using HG.Reflection;
using AncientScepter;
using RobomandoMod.Characters.Survivors.Robomando.Components;

[module: UnverifiableCode]
[assembly: SearchableAttribute.OptIn]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

//rename this namespace
namespace RobomandoMod
{
    //[BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    [BepInDependency(NetworkingAPI.PluginGUID)]
    [BepInDependency("com.rune580.riskofoptions")]
    [BepInDependency("com.weliveinasociety.CustomEmotesAPI", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(ItemQualitiesPlugin.PluginGUID, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency(AncientScepterMain.ModGuid, BepInDependency.DependencyFlags.SoftDependency)]
    public class RobomandoPlugin : BaseUnityPlugin
    {
        // if you do not change this, you are giving permission to deprecate the mod-
        //  please change the names to your own stuff, thanks
        //   this shouldn't even have to be said
        public const string MODUID = "com.rob.RobomandoMod";
        public const string MODNAME = "RobomandoMod";
        public const string MODVERSION = "1.0.0";

        public static bool emotesInstalled = false;
        public static bool qualityInstalled = false;
        public static bool scepterInstalled = false;

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string DEVELOPER_PREFIX = "RAT";

        public static RobomandoPlugin instance;

        void Awake()
        {
            instance = this;

            NetworkingAPI.RegisterMessageType<HackNetMessage>();
            NetworkingAPI.RegisterMessageType<RobomandoCinematicVoiceLines.VoiceLineNetMessage>();

            //easy to use logger
            Log.Init(Logger);

            // used when you want to properly set up language folders
            Modules.ModLanguage.Init();

            emotesInstalled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("com.weliveinasociety.CustomEmotesAPI");
            if (emotesInstalled)
            {
                Log.Debug("EmoteAPI is installed");
            }
            else
            {
                Log.Debug("EmoteAPI is not installed");
            }
            qualityInstalled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(ItemQualitiesPlugin.PluginGUID);
            if (qualityInstalled)
            {
                Log.Debug("ItemQualities is installed");
            }
            else 
            {
                Log.Debug("ItemQualities is not installed");
            }
            scepterInstalled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey(AncientScepterMain.ModGuid);
            if (qualityInstalled)
            {
                Log.Debug("AncientScepter is installed");
            }
            else
            {
                Log.Debug("AncientScepter is not installed");
            }

            // character initialization
            new RobomandoSurvivor().Initialize();

            // make a content pack and add it. this has to be last
            new Modules.ContentPacks().Initialize();
        } 
    }
}
