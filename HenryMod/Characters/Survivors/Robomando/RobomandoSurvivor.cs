using BepInEx.Configuration;
using HenryMod.Characters.Survivors.Robomando.Content;
using Mono.CompilerServices.SymbolWriter;
using On.RoR2.UI;
using RiskOfOptions;
using RobomandoMod.Characters.Survivors.Robomando.Components;
using RobomandoMod.Characters.Survivors.Robomando.Content;
using RobomandoMod.Characters.Survivors.Robomando.Test;
using RobomandoMod.Modules;
using RobomandoMod.Modules.Characters;
using RobomandoMod.Survivors.Robomando.Components;
using RobomandoMod.Survivors.Robomando.SkillStates;
using RoR2;
using RoR2.Skills;
using RoR2BepInExPack.GameAssetPaths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using static Rewired.InputMapper;

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

        public static AssetBundle VFXBundle;

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
                //material = assetBundle.LoadMaterial("GunMaterial"),
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

            var vfxbundle = Asset.LoadAssetBundle("robomandovfxassets");
            RobomandoAssets.Init(assetBundle, vfxbundle);
            RobomandoBuffs.Init(assetBundle);

            InitializeEntityStateMachines();
            InitializeSkills();
            InitializeSkins();
            InitializeCharacterMaster();

            AdditionalBodySetup();

            AddHooks();

            //gunTransform = characterModelObject.GetComponent<ChildLocator>().FindChild("Gun");
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

            //gunTransform = Locator.FindChild("Gun");

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

            bodyPrefab.AddComponent<RobomandoCinematicVoiceLines>().system = Locator.FindChild("VoiceEffect").GetComponent<ParticleSystem>();
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
                    RobomandoConfig.EnableNewIcons.Value ? assetBundle.LoadAsset<Sprite>("texShootIcon2") : assetBundle.LoadAsset<Sprite>("texShootIcon"),
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
                skillIcon = RobomandoConfig.EnableNewIcons.Value ? assetBundle.LoadAsset<Sprite>("texZapIcon2") : assetBundle.LoadAsset<Sprite>("texZapIcon"),
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
                skillIcon = RobomandoConfig.EnableNewIcons.Value ? assetBundle.LoadAsset<Sprite>("texBombIcon2") : assetBundle.LoadAsset<Sprite>("texBombIcon"),
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
                skillIcon = RobomandoConfig.EnableNewIcons.Value ? assetBundle.LoadAsset<Sprite>("texRollIcon2") : assetBundle.LoadAsset<Sprite>("texRollIcon"),

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
                skillIcon = RobomandoConfig.EnableNewIcons.Value ? assetBundle.LoadAsset<Sprite>("texHackIcon2") : assetBundle.LoadAsset<Sprite>("texHackIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Hack)),
                //setting this to the "weapon2" EntityStateMachine allows us to cast this skill at the same time primary, which is set to the "weapon" EntityStateMachine
                activationStateMachineName = "Body", interruptPriority = EntityStates.InterruptPriority.Skill,

                baseMaxStock = 1,
                baseRechargeInterval = 8f,
                beginSkillCooldownOnSkillEnd = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
            }) ;

            SkillDef specialSkillDef2 = Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = "RobomandoOverwire",
                skillNameToken = ROBO_PREFIX + "SPECIAL_OVERWIRE_NAME",
                skillDescriptionToken = ROBO_PREFIX + "SPECIAL_OVERWIRE_DESCRIPTION",
                keywordTokens = new string[] { survivorTokenPrefix + "KEYWORD_JURY_RIG" },
                skillIcon = assetBundle.LoadAsset<Sprite>("texOverwireIcon"),

                activationState = new EntityStates.SerializableEntityStateType(typeof(Overwire)),
                //setting this to the "weapon2" EntityStateMachine allows us to cast this skill at the same time primary, which is set to the "weapon" EntityStateMachine
                activationStateMachineName = "Body",
                interruptPriority = EntityStates.InterruptPriority.Skill,

                baseMaxStock = 1,
                baseRechargeInterval = 8f,
                beginSkillCooldownOnSkillEnd = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
            });

            Skills.AddSpecialSkills(bodyPrefab, specialSkillDef1);
            if (RobomandoPlugin.scepterInstalled)
            {
                RobomandoScepterIntegration.Init(this, bodyPrefab.GetComponent<SkillLocator>().special.skillFamily, specialSkillDef2);
            }
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

            var skinControllerNew = displayPrefab.AddComponent<ModelSkinController>();
            skinControllerNew.skins = skins.ToArray();
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
            GlobalEventManager.onCharacterDeathGlobal += PlayFunnyDeathSounds;

            On.RoR2.CharacterMaster.OnServerStageBegin += CharacterMaster_OnServerStageBegin;

            TeleporterInteraction.onTeleporterBeginChargingGlobal += (inter) =>
            {
                foreach(var user in LocalUserManager.readOnlyLocalUsersList)
                {
                    var localBody = user.cachedBody;
                    if ((bool)localBody)
                    {
                        RobomandoCinematicVoiceLines.PlayRoboVoice(localBody.gameObject, "Play_Robo_Voice_Boss_Spawned");
                    }
                }
            };

            GlobalEventManager.onCharacterDeathGlobal += (message) =>
            {
                if (!message.victimBody)
                {
                    return;
                }
                var body = message.victimBody;
                RobomandoCinematicVoiceLines.PlayRoboVoice(body.gameObject, "Play_Robo_Voice_Die"); //if robomando dies
                foreach(var user in LocalUserManager.readOnlyLocalUsersList)
                {
                    var localCharBody = user.cachedBody;
                    if (message.victimIsBoss && message.attackerBody.Equals(localCharBody))
                    {
                        if(body.TryGetComponent<CharacterDeathBehavior>(out var death) && death.deathState.typeName.Equals("EntityStates.BrotherMonster.TrueDeathState"))
                        {
                            RobomandoCinematicVoiceLines.PlayRoboVoice(localCharBody.gameObject, "Play_Robo_Voice_Mithrix_Killed");
                        }
                        else
                        {
                            RobomandoCinematicVoiceLines.PlayRoboVoice(localCharBody.gameObject, "Play_Robo_Voice_Boss_Killed");
                        } 
                    }
                    if(message.victimTeamIndex == localCharBody.teamComponent.teamIndex)
                    {
                        RobomandoCinematicVoiceLines.PlayRoboVoice(localCharBody.gameObject, "Play_Robo_Voice_Ally_Dead");
                    }
                }
            };

            GlobalEventManager.onClientDamageNotified += (message) =>
            {
                if(!(message.victim && message.victim.TryGetComponent<CharacterBody>(out var body)))
                {
                    return;
                }
                if (message.hitLowHealth)
                {
                    //method will check if obj is robomando or not
                    RobomandoCinematicVoiceLines.PlayRoboVoice(message.victim, "Play_Robo_Voice_Low_Health");
                    //only local players have body components
                    foreach(var user in LocalUserManager.readOnlyLocalUsersList)
                    {
                        var localCharBody = user.cachedBody;
                        if (localCharBody)
                        {
                            if(body.teamComponent.teamIndex == localCharBody.teamComponent.teamIndex)
                            {
                                RobomandoCinematicVoiceLines.PlayRoboVoice(localCharBody.gameObject, "Play_Robo_Voice_Ally_Danger");
                            }
                        }
                    }
                }
            };

            GlobalEventManager.OnInteractionsGlobal += (interactor, i_interactable, obj) =>
            {
                if (!interactor.TryGetComponent<CharacterBody>(out var body))
                {
                    return;
                }
                if (obj.TryGetComponent<ChestBehavior>(out var behaviour))
                {
                    RobomandoCinematicVoiceLines.PlayRoboVoice(body.gameObject, "Play_Robo_Voice_Chest_Open");
                }
            };

            EquipmentSlot.onServerEquipmentActivated += (slot, index) =>
            {
                RobomandoCinematicVoiceLines.PlayRoboVoice(slot.gameObject, "Play_Robo_Voice_Use_Equip");
            };

            On.RoR2.DirectorCore.TrySpawnObject += DirectorCore_TrySpawnObject;
            
            //RoR2Application.onLoadFinished += LogEvents.PrintSceneNames;

            ObjectivePanelController.ObjectiveTracker.OnRetired += ObjectiveTracker_OnRetired;

            On.RoR2.LunarCoinDef.GrantPickup += LunarCoinDef_GrantPickup;

            if(RobomandoPlugin.emotesInstalled)
            {
                Debug.Log("Call AddSkeleton from survivor script");
                RobomandoAddEmoteSkeleton.AddSkeleton(assetBundle);
            }
            if (RobomandoPlugin.qualityInstalled)
            {
                RobomandoQualityIntegration.Init();
            }
        }

        private GameObject DirectorCore_TrySpawnObject(On.RoR2.DirectorCore.orig_TrySpawnObject orig, DirectorCore self, DirectorSpawnRequest directorSpawnRequest)
        {
            var result = orig(self, directorSpawnRequest);
            if (!(bool)result)
            {
                return result;
            }
            if(directorSpawnRequest != null && (bool)directorSpawnRequest.spawnCard && (bool)directorSpawnRequest.spawnCard.prefab)
            {
                var prefab = directorSpawnRequest.spawnCard.prefab;
                if(!prefab.TryGetComponent<CharacterMaster>(out CharacterMaster master))
                {
                    //Log.Debug("[VoiceHook]: No Master");
                    return result;
                }
                var spawnedIndex = BodyCatalog.FindBodyIndex(master.bodyPrefab);
                if (spawnedIndex.Equals(BodyCatalog.FindBodyIndex(RoR2Content.BodyPrefabs.BrotherBody)))
                {
                    foreach(var user in LocalUserManager.readOnlyLocalUsersList)
                    {
                        var localbody = user.cachedBody;
                        if (localbody != null)
                        {
                            RobomandoCinematicVoiceLines.PlayRoboVoice(localbody.gameObject, "Play_Robo_Voice_Mithrix_Spawn");
                        }
                    }
                }
                else
                {
                    //Log.Debug("[VoiceHook]: Not Mithrix");
                }
            }
            else
            {
                //Log.Debug("[VoiceHook]: No prefab spawn");
            }
            return result;
        }

        private void LunarCoinDef_GrantPickup(On.RoR2.LunarCoinDef.orig_GrantPickup orig, LunarCoinDef self, ref PickupDef.GrantContext context)
        {
            orig(self,ref context);
            if (context.body)
            {
                RobomandoCinematicVoiceLines.PlayRoboVoice(context.body.gameObject, "Play_Robo_Voice_Lunar_Coin");
            }
        }

        private void ObjectiveTracker_OnRetired(ObjectivePanelController.ObjectiveTracker.orig_OnRetired orig, RoR2.UI.ObjectivePanelController.ObjectiveTracker self)
        {
            orig(self);
            if (self is RoR2.UI.ObjectivePanelController.FindTeleporterObjectiveTracker ||
                self is RoR2.UI.ObjectivePanelController.ActivateGoldshoreBeaconTracker)
            {
                return;
            }
            if ((bool)self.owner && (bool)self.owner.currentMaster && (bool)self.owner.currentMaster.bodyInstanceObject)
            {
                RobomandoCinematicVoiceLines.PlayRoboVoice(self.owner.currentMaster.bodyInstanceObject, "Play_Robo_Voice_Objective");
            }
        }

        private void CharacterMaster_OnServerStageBegin(On.RoR2.CharacterMaster.orig_OnServerStageBegin orig, CharacterMaster self, Stage stage)
        {
            orig(self, stage);
            if((bool)self.bodyPrefab && self.bodyPrefab.Equals(bodyPrefab))
            {
                self.StartCoroutine(WaitForPlayerInstantiation(3f, stage));
            }
            
        }

        private IEnumerator WaitForPlayerInstantiation(float duration, Stage stage)
        {
            yield return new WaitForSeconds(duration);
            foreach (var user in LocalUserManager.readOnlyLocalUsersList)
            {
                var localBody = user.cachedBody;
                if ((bool)localBody)
                {

                    if (stage.sceneDef.sceneDefIndex.Equals(SceneCatalog.FindSceneIndex("moon2")))
                    {
                        RobomandoCinematicVoiceLines.PlayRoboVoice(localBody.gameObject, "Play_Robo_Voice_Spawn_Moon");
                        yield break;
                    }
                    

                    var rng = new Xoroshiro128Plus(Run.instance.runRNG.nextUint);
                    if (rng.nextBool)
                    {
                        RobomandoCinematicVoiceLines.PlayRoboVoice(localBody.gameObject, "Play_Robo_Voice_Spawn_Stage");
                    }
                    else
                    {
                        RobomandoCinematicVoiceLines.PlayRoboVoice(localBody.gameObject, "Play_Robo_Voice_Spawn_Party");
                    }
                }
            }
        }

        private void PlayFunnyDeathSounds(DamageReport report)
        {
            //report.victimBody.baseNameToken
            //RoR2.Chat.SendBroadcastChat(new RoR2.Chat.SimpleChatMessage() { baseToken = $"<style=cEvent><color=#307FFF>Victim Name: {report.victimBody.baseNameToken}</color></style>" });
            if (report.victimBody)
            {
                if (report.victimBody.gameObject != null)
                {
                    var name = report.victimBody.baseNameToken;
                    if (name != null && name.Equals("RAT_ROBOMANDO_NAME"))
                    {
                        Util.PlaySound("Play_Robo_Lego_Death_Sound", report.victimBody.gameObject);
                        if (!RobomandoConfig.RoboTalks.Value)
                        {
                            //Util.PlaySound("DeathVoice", report.victimBody.gameObject);
                            TryPlayVoiceLine("Play_Robo_Death_Gasp", report.victimBody.gameObject);
                        }

                    }
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