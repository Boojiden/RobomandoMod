﻿using BepInEx.Configuration;
using HenryMod.Characters.Survivors.Robomando.Content;
using RiskOfOptions;
using RobomandoMod.Characters.Survivors.Robomando.Components;
using RobomandoMod.Characters.Survivors.Robomando.Content;
using RobomandoMod.Modules;
using RobomandoMod.Modules.Characters;
using RobomandoMod.Survivors.Robomando.Components;
using RobomandoMod.Survivors.Robomando.SkillStates;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace RobomandoMod.Survivors.Robomando
{
    public class RobomandoSurvivor : SurvivorBase<RobomandoSurvivor>
    {
        //used to load the assetbundle for this character. must be unique
        public override string assetBundleName => "robomandobundle"; //if you do not change this, you are giving permission to deprecate the mod

        //the name of the prefab we will create. conventionally ending in "Body". must be unique
        public override string bodyName => "RobomandoBody"; //if you do not change this, you get the point by now

        //name of the ai master for vengeance and goobo. must be unique
        public override string masterName => "RobomandoMonsterMaster"; //if you do not

        //the names of the prefabs you set up in unity that we will use to build your character
        public override string modelPrefabName => "mdlRobomando";
        public override string displayPrefabName => "mdlRobomandoDisplay";

        public const string ROBO_PREFIX = RobomandoPlugin.DEVELOPER_PREFIX + "_ROBOMANDO_";

        public static Transform gunTransform;

        //used when registering your survivor's language tokens
        public override string survivorTokenPrefix => ROBO_PREFIX;
        
        public override BodyInfo bodyInfo => new BodyInfo
        {
            bodyName = bodyName,
            bodyNameToken = ROBO_PREFIX + "NAME",
            subtitleNameToken = ROBO_PREFIX + "SUBTITLE",

            characterPortrait = assetBundle.LoadAsset<Texture>("texRobomandoIcon"),
            bodyColor = new Color(158f / 255f, 165f / 255f, 168f / 255f),
            sortPosition = 100,

            crosshair = Asset.LoadCrosshair("Standard"),
            podPrefab = LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/SurvivorPod"),

            maxHealth = 75f,
            healthRegen = 1.5f,
            armor = 0f,
            moveSpeed = 8.2f,
            jumpCount = 1,
            damage = 15,

            damageGrowth = 3,
        };

        public override CustomRendererInfo[] customRendererInfos => new CustomRendererInfo[]
        {
            new CustomRendererInfo
            {
                childName = "Guy",
            },
            new CustomRendererInfo
            {
                childName = "Gun",
                material = assetBundle.LoadMaterial("GunMaterial"),
            },
            new CustomRendererInfo
            {
                childName = "Crown",
                ignoreOverlays = true,
            },
            new CustomRendererInfo
            {
                childName = "Hat",
                ignoreOverlays = true,
            },
            new CustomRendererInfo
            {
                childName = "TrueCrown",
                ignoreOverlays = true,
            },
            new CustomRendererInfo
            {
                childName = "Cape",
                ignoreOverlays = true,
            },
            new CustomRendererInfo
            {
                childName = "Antenna",
            },
        };

        public override UnlockableDef characterUnlockableDef => RobomandoUnlockables.characterUnlockableDef;
        
        public override ItemDisplaysBase itemDisplays => new RobomandoItemDisplays();

        //set in base classes
        public override AssetBundle assetBundle { get; protected set; }

        public override GameObject bodyPrefab { get; protected set; }
        public override CharacterBody prefabCharacterBody { get; protected set; }
        public override GameObject characterModelObject { get; protected set; }
        public override CharacterModel prefabCharacterModel { get; protected set; }
        public override GameObject displayPrefab { get; protected set; }

        public override void Initialize()
        {
            //uncomment if you have multiple characters
            //ConfigEntry<bool> characterEnabled = Config.CharacterEnableConfig("Survivors", "Robomando");

            //if (!characterEnabled.Value)
            //    return;
            base.Initialize();
            ModSettingsManager.SetModIcon(assetBundle.LoadAsset<Sprite>("texRobomandoModIcon"));
            ModSettingsManager.SetModDescription("robo man doe");
        }

        public override void InitializeCharacter()
        {
            //need the character unlockable before you initialize the survivordef
            RobomandoUnlockables.Init();

            base.InitializeCharacter();

            RobomandoConfig.Init();
            RobomandoStates.Init();
            RobomandoTokens.Init();

            RobomandoAssets.Init(assetBundle);
            RobomandoBuffs.Init(assetBundle);

            InitializeEntityStateMachines();
            InitializeSkills();
            InitializeSkins();
            InitializeCharacterMaster();

            AdditionalBodySetup();

            AddHooks();

            gunTransform = characterModelObject.GetComponent<ChildLocator>().FindChild("Gun");
        }

        protected override void InitializeDisplayPrefab()
        {
            displayPrefab = Prefabs.CreateDisplayPrefab(assetBundle, displayPrefabName, bodyPrefab);
            displayPrefab.AddComponent<DisplayAnimationEvent>();
        }

        private void AdditionalBodySetup()
        {
            AddHitboxes();
            bodyPrefab.AddComponent<RobomandoWeaponComponent>();
            Log.Debug("Adding HackIndicator");
            bodyPrefab.AddComponent<HackIndicatorScan>().Init();
            var Locator = prefabCharacterModel.GetComponent<ChildLocator>();

            gunTransform = Locator.FindChild("Gun");

            var test = Locator.gameObject;

            var antenna = Locator.FindChildGameObject(Locator.FindChildIndex("Antenna")).transform.parent.gameObject;
            var dBone = antenna.AddComponent<DynamicBone>();

            dBone.m_Root = antenna.transform.GetChild(1).GetChild(0);
            dBone.m_Exclusions = new List<Transform>() { dBone.m_Root.GetChild(0).GetChild(0)};

            var Locator2 = displayPrefab.GetComponent<CharacterModel>().GetComponent<ChildLocator>();
            var antenna2 = Locator2.FindChildGameObject(Locator2.FindChildIndex("Antenna")).transform.parent.gameObject;
            var dBone2 = antenna2.AddComponent<DynamicBone>();

            dBone2.m_Root = antenna2.transform.GetChild(1).GetChild(0);
            dBone2.m_Exclusions = new List<Transform>() { dBone2.m_Root.GetChild(0).GetChild(0)};
            //bodyPrefab.AddComponent<HuntressTrackerComopnent>();
            //anything else here
        }

        public void AddHitboxes()
        {
            //example of how to create a HitBoxGroup. see summary for more details
            //Prefabs.SetupHitBoxGroup(characterModelObject, "SwordGroup", "SwordHitbox");
        }

        public override void InitializeEntityStateMachines() 
        {
            //clear existing state machines from your cloned body (probably commando)
            //omit all this if you want to just keep theirs
            Prefabs.ClearEntityStateMachines(bodyPrefab);

            //the main "Body" state machine has some special properties
            Prefabs.AddMainEntityStateMachine(bodyPrefab, "Body", typeof(EntityStates.GenericCharacterMain), typeof(EntityStates.SpawnTeleporterState));
            //if you set up a custom main characterstate, set it up here
                //don't forget to register custom entitystates in your RobomandoStates.cs

            Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon");
            Prefabs.AddEntityStateMachine(bodyPrefab, "LeftArm");
            //Prefabs.AddEntityStateMachine(bodyPrefab, "Weapon2");
        }

        #region skills
        public override void InitializeSkills()
        {
            //remove the genericskills from the commando body we cloned
            Skills.ClearGenericSkills(bodyPrefab);
            //add our own
            //AddPassiveSkill();
            AddPrimarySkills();
            AddSecondarySkills();
            AddUtiitySkills();
            AddSpecialSkills();
        }

        //skip if you don't have a passive
        //also skip if this is your first look at skills
        private void AddPassiveSkill()
        {
            /*
            //option 1. fake passive icon just to describe functionality we will implement elsewhere
            bodyPrefab.GetComponent<SkillLocator>().passiveSkill = new SkillLocator.PassiveSkill
            {
                enabled = true,
                skillNameToken = HENRY_PREFIX + "PASSIVE_NAME",
                skillDescriptionToken = HENRY_PREFIX + "PASSIVE_DESCRIPTION",
                keywordToken = "KEYWORD_STUNNING",
                icon = assetBundle.LoadAsset<Sprite>("texPassiveIcon"),
            };

            //option 2. a new SkillFamily for a passive, used if you want multiple selectable passives
            GenericSkill passiveGenericSkill = Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, "PassiveSkill");
            SkillDef passiveSkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoPassive",
                skillNameToken = HENRY_PREFIX + "PASSIVE_NAME",
                skillDescriptionToken = HENRY_PREFIX + "PASSIVE_DESCRIPTION",
                keywordTokens = new string[] { "KEYWORD_AGILE" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texPassiveIcon"),

                //unless you're somehow activating your passive like a skill, none of the following is needed.
                //but that's just me saying things. the tools are here at your disposal to do whatever you like with

                //activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Shoot)),
                //activationStateMachineName = "Weapon1",
                //interruptPriority = EntityStates.InterruptPriority.Skill,

                //baseRechargeInterval = 1f,
                //baseMaxStock = 1,

                //rechargeStock = 1,
                //requiredStock = 1,
                //stockToConsume = 1,

                //resetCooldownTimerOnUse = false,
                //fullRestockOnAssign = true,
                //dontAllowPastMaxStocks = false,
                //mustKeyPress = false,
                //beginSkillCooldownOnSkillEnd = false,

                //isCombatSkill = true,
                //canceledFromSprinting = false,
                //cancelSprintingOnActivation = false,
                //forceSprintDuringState = false,
                

            });
            Skills.AddSkillsToFamily(passiveGenericSkill.skillFamily, passiveSkillDef1);
            */
        }

        //if this is your first look at skilldef creation, take a look at Secondary first
        private void AddPrimarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Primary);

            //the primary skill is created using a constructor for a typical primary
            //it is also a SteppedSkillDef. Custom Skilldefs are very useful for custom behaviors related to casting a skill. see ror2's different skilldefs for reference
            SteppedSkillDef primarySkillDef1 = Skills.CreateSkillDef<SteppedSkillDef>(new SkillDefInfo
                (
                    "RobomandoShoot",
                    ROBO_PREFIX + "PRIMARY_SHOT_NAME",
                    ROBO_PREFIX + "PRIMARY_SHOT_DESCRIPTION",
                    assetBundle.LoadAsset<Sprite>("texShootIcon"),
                    new EntityStates.SerializableEntityStateType(typeof(SkillStates.Shoot)),
                    "Weapon",
                    true
                ));
            //custom Skilldefs can have additional fields that you can set manually
            primarySkillDef1.stepCount = 2;
            primarySkillDef1.stepGraceDuration = 0.5f;

            Skills.AddPrimarySkills(bodyPrefab, primarySkillDef1);
        }

        private void AddSecondarySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Secondary);

            //here is a basic skill def with all fields accounted for
            SkillDef secondarySkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoZap",
                skillNameToken = ROBO_PREFIX + "SECONDARY_ZAP_NAME",
                skillDescriptionToken = ROBO_PREFIX + "SECONDARY_ZAP_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texZapIcon"),
                keywordTokens = new string[] { "KEYWORD_AGILE", "KEYWORD_STUNNING" },
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Zap)),
                activationStateMachineName = "Weapon",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseRechargeInterval = RobomandoStaticValues.zapCooldown,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = false,
                
            });

            SkillDef secondarySkillDef2 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoBomb",
                skillNameToken = ROBO_PREFIX + "SECONDARY_BOMB_NAME",
                skillDescriptionToken = ROBO_PREFIX + "SECONDARY_BOMB_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texBombIcon"),
                keywordTokens = new string[] {},
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.BouncyBomb)),
                activationStateMachineName = "LeftArm",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseRechargeInterval = RobomandoStaticValues.bouncyBombCooldown,
                baseMaxStock = 2,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = true,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = true,
                forceSprintDuringState = false,

            });

            Skills.AddSecondarySkills(bodyPrefab, new SkillDef[] { secondarySkillDef1, secondarySkillDef2});
        }

        private void AddUtiitySkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Utility);

            //here's a skilldef of a typical movement skill.
            SkillDef utilitySkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoRoll",
                skillNameToken = ROBO_PREFIX + "UTILITY_ROLL_NAME",
                skillDescriptionToken = ROBO_PREFIX + "UTILITY_ROLL_DESCRIPTION",
                skillIcon = assetBundle.LoadAsset<Sprite>("texRollIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(Roll)),
                activationStateMachineName = "Body",
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,

                baseRechargeInterval = RobomandoStaticValues.diveCooldown,
                baseMaxStock = 1,

                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,

                resetCooldownTimerOnUse = false,
                fullRestockOnAssign = true,
                dontAllowPastMaxStocks = false,
                mustKeyPress = false,
                beginSkillCooldownOnSkillEnd = false,

                isCombatSkill = false,
                canceledFromSprinting = false,
                cancelSprintingOnActivation = false,
                forceSprintDuringState = true,
            });

            Skills.AddUtilitySkills(bodyPrefab, utilitySkillDef1);
        }

        private void AddSpecialSkills()
        {
            Skills.CreateGenericSkillWithSkillFamily(bodyPrefab, SkillSlot.Special);

            //a basic skill. some fields are omitted and will just have default values
            SkillDef specialSkillDef1 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoHack",
                skillNameToken = ROBO_PREFIX + "SPECIAL_HACK_NAME",
                skillDescriptionToken = ROBO_PREFIX + "SPECIAL_HACK_DESCRIPTION",
                keywordTokens = new string[] { survivorTokenPrefix + "KEYWORD_JURY_RIG" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texHackIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Hack)),
                //setting this to the "weapon2" EntityStateMachine allows us to cast this skill at the same time primary, which is set to the "weapon" EntityStateMachine
                activationStateMachineName = "Body", interruptPriority = EntityStates.InterruptPriority.Skill,

                baseMaxStock = 1,
                baseRechargeInterval = 8f,
                beginSkillCooldownOnSkillEnd = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
            }) ;

            Skills.AddSpecialSkills(bodyPrefab, specialSkillDef1);
        }
        #endregion skills
        
        #region skins
        public override void InitializeSkins()
        {
            ModelSkinController skinController = prefabCharacterModel.gameObject.AddComponent<ModelSkinController>();
            ChildLocator childLocator = prefabCharacterModel.GetComponent<ChildLocator>();

            CharacterModel.RendererInfo[] defaultRendererinfos = prefabCharacterModel.baseRendererInfos;

            List<SkinDef> skins = new List<SkinDef>();
            //index ref: guy, gun, crown, hat, truecrown, cape, antenna
            List<string> defaultMeshReplacements = new List<string>{ null, null, null, null, null, null, null };
            List<string> masteryMeshReplacements = new List<string> { null, null, "meshCrown", null, null, null, null };
            List<string> grandMasteryMeshReplacements = new List<string> { null, null, null, null, "meshTrueCrown", null, null };
            List<string> sodaMeshReplacements = new List<string> { null, null, null, "meshHat", null, null, null };

            #region DefaultSkin
            //this creates a SkinDef with all default fields
            SkinDef defaultSkin = Skins.CreateSkinDef("DEFAULT_SKIN",
                assetBundle.LoadAsset<Sprite>("texMainSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            //these are your Mesh Replacements. The order here is based on your CustomRendererInfos from earlier
            //pass in meshes as they are named in your assetbundle
            //currently not needed as with only 1 skin they will simply take the default meshes
            //uncomment this when you have another skin
            //defaultSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshRobomandoSword",
            //    "meshRobomandoGun",
            //    "meshRobomando");

            //add new skindef to our list of skindefs. this is what we'll be passing to the SkinController

            defaultSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, defaultMeshReplacements.ToArray());

            skins.Add(defaultSkin);


            SkinDef commandoSkin = Skins.CreateSkinDef(ROBO_PREFIX + "COMMANDO_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texCommandoSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            commandoSkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoCommandoMat");
            commandoSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, defaultMeshReplacements.ToArray());
            if (RobomandoConfig.EnableCommandoSkin.Value)
                skins.Add(commandoSkin);




            SkinDef BlueSkin = Skins.CreateSkinDef(ROBO_PREFIX + "BLUE_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texBlueSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);

            BlueSkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoBlueMat");
            BlueSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, defaultMeshReplacements.ToArray());
            if (RobomandoConfig.EnableBlueSkin.Value)
                skins.Add(BlueSkin);



            SkinDef GreenSkin = Skins.CreateSkinDef(ROBO_PREFIX + "GREEN_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texGreenSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject);
            GreenSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, defaultMeshReplacements.ToArray());
            GreenSkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoGreenMat");

            if (RobomandoConfig.EnableGreenSkin.Value)
                skins.Add(GreenSkin);



            SkinDef masterySkin = Modules.Skins.CreateSkinDef(ROBO_PREFIX + "MASTERY_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texProvidenceSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject,
                RobomandoUnlockables.masterySkinUnlockableDef);

            masterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoProvidenceMat");
            masterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("CrownShow");

            if (RobomandoConfig.EnableMasterySkin.Value)
                skins.Add(masterySkin);

            masterySkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, masteryMeshReplacements.ToArray());

            SkinDef grandMasterySkin = Modules.Skins.CreateSkinDef(ROBO_PREFIX + "GRANDMASTERY_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texTrueProvidenceSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject,
                RobomandoUnlockables.grandMasterySkinUnlockableDef);

            grandMasterySkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,grandMasteryMeshReplacements.ToArray());

            grandMasterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoProvidenceMat");
            grandMasterySkin.rendererInfos[4].defaultMaterial = assetBundle.LoadMaterial("TrueCrownMaterial");
            grandMasterySkin.rendererInfos[4].ignoreOverlays = false;
            grandMasterySkin.rendererInfos[5].defaultMaterial = assetBundle.LoadMaterial("CapeMaterial");
            grandMasterySkin.rendererInfos[5].ignoreOverlays = false;

            if (RobomandoConfig.EnableGrandmasterySkin.Value)
                skins.Add(grandMasterySkin);



            SkinDef sodaSkin = Modules.Skins.CreateSkinDef(ROBO_PREFIX + "SODA_SKIN_NAME",
                assetBundle.LoadAsset<Sprite>("texSodaSkin"),
                defaultRendererinfos,
                prefabCharacterModel.gameObject,
                RobomandoUnlockables.sodaSkinUnlockableDef);

            sodaSkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("RobomandoSodaMat");
            sodaSkin.rendererInfos[3].defaultMaterial = assetBundle.LoadMaterial("SodaHatMaterial");

            sodaSkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos, sodaMeshReplacements.ToArray());

            if (RobomandoConfig.EnableSodaSkin.Value)
                skins.Add(sodaSkin);



            for(int i = 1; i < skins.Count; i++)
            {
                var skin = skins[i];
                skin.rendererInfos[6].defaultMaterial = assetBundle.LoadMaterial(skin.rendererInfos[0].defaultMaterial.name);
            }
            #endregion

            //uncomment this when you have a mastery skin
            #region MasterySkin

            ////creating a new skindef as we did before
            //

            ////adding the mesh replacements as above. 
            ////if you don't want to replace the mesh (for example, you only want to replace the material), pass in null so the order is preserved
            //masterySkin.meshReplacements = Modules.Skins.getMeshReplacements(assetBundle, defaultRendererinfos,
            //    "meshRobomandoSwordAlt",
            //    null,//no gun mesh replacement. use same gun mesh
            //    "meshRobomandoAlt");

            ////masterySkin has a new set of RendererInfos (based on default rendererinfos)
            ////you can simply access the RendererInfos' materials and set them to the new materials for your skin.
            //masterySkin.rendererInfos[0].defaultMaterial = assetBundle.LoadMaterial("matRobomandoAlt");
            //masterySkin.rendererInfos[1].defaultMaterial = assetBundle.LoadMaterial("matRobomandoAlt");
            //masterySkin.rendererInfos[2].defaultMaterial = assetBundle.LoadMaterial("matRobomandoAlt");

            ////here's a barebones example of using gameobjectactivations that could probably be streamlined or rewritten entirely, truthfully, but it works
            //masterySkin.gameObjectActivations = new SkinDef.GameObjectActivation[]
            //{
            //    new SkinDef.GameObjectActivation
            //    {
            //        gameObject = childLocator.FindChildGameObject("GunModel"),
            //        shouldActivate = false,
            //    }
            //};
            ////simply find an object on your child locator you want to activate/deactivate and set if you want to activate/deacitvate it with this skin

            //skins.Add(masterySkin);

            #endregion

            skinController.skins = skins.ToArray();
        }
        #endregion skins

        //Character Master is what governs the AI of your character when it is not controlled by a player (artifact of vengeance, goobo)
        public override void InitializeCharacterMaster()
        {
            //you must only do one of these. adding duplicate masters breaks the game.

            //if you're lazy or prototyping you can simply copy the AI of a different character to be used
            Modules.Prefabs.CloneDopplegangerMaster(bodyPrefab, masterName, "Merc");

            //how to set up AI in code
            //RobomandoAI.Init(bodyPrefab, masterName);

            //how to load a master set up in unity, can be an empty gameobject with just AISkillDriver components
            //assetBundle.LoadMaster(bodyPrefab, masterName);
        }

        private void AddHooks()
        {
            R2API.RecalculateStatsAPI.GetStatCoefficients += RecalculateStatsAPI_GetStatCoefficients;
            RoR2.GlobalEventManager.onCharacterDeathGlobal += PlayFunnyDeathSounds;

            if(RobomandoPlugin.emotesInstalled)
            {
                Debug.Log("Call AddSkeleton from survivor script");
                RobomandoAddEmoteSkeleton.AddSkeleton(assetBundle);
            }
        }

        private void PlayFunnyDeathSounds(DamageReport report)
        {
            //report.victimBody.baseNameToken
            //RoR2.Chat.SendBroadcastChat(new RoR2.Chat.SimpleChatMessage() { baseToken = $"<style=cEvent><color=#307FFF>Victim Name: {report.victimBody.baseNameToken}</color></style>" });
            if (report.victimBody.baseNameToken.Equals("RAT_ROBOMANDO_NAME"))
            {
                Util.PlaySound("LegoDeathSound", report.victimBody.gameObject);
                if (!RobomandoConfig.RoboTalks.Value)
                {
                    //Util.PlaySound("DeathVoice", report.victimBody.gameObject);
                    TryPlayVoiceLine("DeathVoice", report.victimBody.gameObject);
                }
                    
            }
        }

        public static void TryPlayVoiceLine(string line, GameObject origin)
        {
            if (RobomandoConfig.RoboTalks.Value)
            {
                Log.Debug($"Tried to play sound {line}.");
                Util.PlaySound(line, origin);
            }
        }

        private void RecalculateStatsAPI_GetStatCoefficients(CharacterBody sender, R2API.RecalculateStatsAPI.StatHookEventArgs args)
        {

            if (sender.HasBuff(RobomandoBuffs.armorBuff))
            {
                args.armorAdd += 300;
            }
        }
    }
}