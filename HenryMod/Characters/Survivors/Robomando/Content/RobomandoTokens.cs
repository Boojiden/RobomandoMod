using System;
using System.Globalization;
using BepInEx;
using System.IO;
using Newtonsoft.Json.Utilities;
using R2API;
using RobomandoMod.Modules;
using RobomandoMod.Survivors.Robomando.Achievements;
using RoR2;
using System.Collections.Generic;
using HG;
using Newtonsoft.Json;
using UnityEngine.Rendering;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoTokens
    {
        public static CultureInfo GRAHH = new CultureInfo("en-US");

        public static Dictionary<string, Dictionary<string, string>> DynamicTextDict;

        public static readonly string[] dynamicTokens = new string[] { 
            RobomandoSurvivor.ROBO_PREFIX + "PRIMARY_SHOT_DESCRIPTION", 
            RobomandoSurvivor.ROBO_PREFIX + "SECONDARY_ZAP_DESCRIPTION", 
            RobomandoSurvivor.ROBO_PREFIX + "SECONDARY_BOMB_DESCRIPTION" 
        };
        public static void Init()
        {
            //AddRobomandoTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Robomando.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
            ///
            GetDynamicTextDict();

            ChangeSingleShotText();
            ChangeZapText();
            ChangeBombText();

            Language.onCurrentLanguageChanged += ChangeSingleShotText;
            Language.onCurrentLanguageChanged += ChangeZapText;
            Language.onCurrentLanguageChanged += ChangeBombText;
        }

        public static void GetDynamicTextDict()
        {
            DynamicTextDict = new Dictionary<string, Dictionary<string, string>>();

            string file = Directory.GetFiles(Paths.PluginPath, "*.language", SearchOption.AllDirectories)[0];
            string fileText = File.ReadAllText(file);

            
            var dict = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(fileText);

            foreach (string key in dict.Keys)
            {
                var savedKey = key;
                if (key.Equals("strings"))
                {
                    savedKey = "default";
                }
                var innerDict = dict[key];
                foreach(var token in dynamicTokens)
                {
                    Dictionary<string, string> langDict;
                    if (!DynamicTextDict.ContainsKey(savedKey))
                    {
                        DynamicTextDict.Add(savedKey, new Dictionary<string, string>());
                    }
                    langDict = DynamicTextDict[savedKey];

                    langDict.Add(token, innerDict[token]);
                }
            }
        }

        public static void ChangeSingleShotText()
        {
            /*
            string prefix = RobomandoSurvivor.ROBO_PREFIX;
            ModLanguage.SetTemporaryValue(prefix + "PRIMARY_SHOT_DESCRIPTION", RoR2.Language.GetString(prefix + "PRIMARY_SHOT_DESCRIPTION", Language.currentLanguageName).FormatWith(GRAHH, RobomandoStaticValues.shootDamageCoefficient));
            */
            SetNewAbilityToken(RobomandoSurvivor.ROBO_PREFIX + "PRIMARY_SHOT_DESCRIPTION", RobomandoStaticValues.shootDamageCoefficient * 100f);
        }

        public static void ChangeZapText()
        {
            /*
            string prefix = RobomandoSurvivor.ROBO_PREFIX;
            ModLanguage.SetTemporaryValue(prefix + "SECONDARY_ZAP_DESCRIPTION", RoR2.Language.GetString(prefix + "SECONDARY_ZAP_DESCRIPTION", Language.currentLanguageName).FormatWith(GRAHH, RobomandoStaticValues.zapDamageCoefficient));
            */
            SetNewAbilityToken(RobomandoSurvivor.ROBO_PREFIX + "SECONDARY_ZAP_DESCRIPTION", RobomandoStaticValues.zapDamageCoefficient * 100f);
        }

        public static void ChangeBombText() 
        {
            /*
            string prefix = RobomandoSurvivor.ROBO_PREFIX;
            ModLanguage.SetTemporaryValue(prefix + "SECONDARY_BOMB_DESCRIPTION", RoR2.Language.GetString(prefix + "SECONDARY_BOMB_DESCRIPTION", Language.currentLanguageName).FormatWith(GRAHH, RobomandoStaticValues.bouncyBombDamageCoefficient));
            */
            SetNewAbilityToken(RobomandoSurvivor.ROBO_PREFIX + "SECONDARY_BOMB_DESCRIPTION", RobomandoStaticValues.bouncyBombDamageCoefficient * 100f);
        }

        private static void SetNewAbilityToken(string token, object param)
        {
            string lang = Language.currentLanguageName;
            if (!DynamicTextDict.ContainsKey(lang))
            {
                lang = "default";
            }
            string localString = DynamicTextDict[lang][token];
            if (localString != null)
            {
                ModLanguage.SetTemporaryValue(token, localString.FormatWith(null, param));
                Log.Debug("Attemping to overlay token {0} with string {1}".FormatWith(null, token, localString));
            }
        }

        public static void AddRobomandoTokens()
        {
            string prefix = RobomandoSurvivor.ROBO_PREFIX;

            string desc = "Your Robomando Model 7 is equipped with all of the tools necessary to salvage any mechanical device encountered in the wild.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > His patented Re-Wire can co-op machines of any kind, even from a competitor!" + Environment.NewLine + Environment.NewLine
             + "< ! > Built for speed, he is faster than most survivors on his feet, but isn't very durable. Use this speed to your advantage. It is generally more effective to run instead of trying to roll." + Environment.NewLine + Environment.NewLine
             + "< ! > While he himself may have weak damage, items that scale off of damage are generally stronger when used by Robomando. Use his re-wire to run through stages and quickly gain offensive items." + Environment.NewLine + Environment.NewLine
             + "< ! > Please keep in mind that, while your Robomando is equipped with offensive abilities, it is not designed for hostile environments" + Environment.NewLine + Environment.NewLine;

            string outro = "..and so it left nothing behind.";
            string outroFailure = "..and so it failed, to no one's particular surprise or excitement.";

            string lore = "I thought the advertisements were bogus at first. I mean, this little toy soldier is able to hack into any mechanical device? It sounded like bullshit." + Environment.NewLine + Environment.NewLine
                + "Well, imagine my shock when the thing hotwired my car and took it for a joyride. Found it two hours later totaled in a ditch. Apparently the thing couldn't reach the steering wheel." + Environment.NewLine + Environment.NewLine
                + "It really just seemed like a toy to me. I hope to God no unaware parents got this little freak for their kids.";

            //RAT_ROBOMANDO_NAME
            ModLanguage.Add(prefix + "NAME", "Robomando");
            ModLanguage.Add(prefix + "DESCRIPTION", desc);
            ModLanguage.Add(prefix + "SUBTITLE", "God's Strongest Soldier");
            ModLanguage.Add(prefix + "LORE", lore);
            ModLanguage.Add(prefix + "OUTRO_FLAVOR", outro);
            ModLanguage.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            ModLanguage.Add(prefix + "MASTERY_SKIN_NAME", "Hero's Disciple");
            ModLanguage.Add(prefix + "GRANDMASTERY_SKIN_NAME", "Trophy Taker");
            ModLanguage.Add(prefix + "COMMANDO_SKIN_NAME", "Like Father, Like Son");
            ModLanguage.Add(prefix + "BLUE_SKIN_NAME", "Soaked");
            ModLanguage.Add(prefix + "GREEN_SKIN_NAME", "Goblin");
            ModLanguage.Add(prefix + "SODA_SKIN_NAME", "Caffeinated Cretin");
            #endregion

            #region Passive
            ModLanguage.Add(prefix + "PASSIVE_NAME", "Robomando passive");
            ModLanguage.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            #endregion

            #region Primary
            ModLanguage.Add(prefix + "PRIMARY_SHOT_NAME", "Single Fire");
            ModLanguage.Add(prefix + "PRIMARY_SHOT_DESCRIPTION", Tokens.agilePrefix + $" Shoot for <style=cIsDamage>{100f * RobomandoStaticValues.shootDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            ModLanguage.Add(prefix + "SECONDARY_ZAP_NAME", "De-Escalate");
            ModLanguage.Add(prefix + "SECONDARY_ZAP_DESCRIPTION", Tokens.agilePrefix+ $" <style=cIsDamage>Stunning.</style> Fire a small, <style=cIsDamage>piercing</style> electric pulse for <style=cIsDamage>{100f * RobomandoStaticValues.zapDamageCoefficient}% damage.");

            ModLanguage.Add(prefix + "SECONDARY_BOMB_NAME", "Bouncy Bomb");
            ModLanguage.Add(prefix + "SECONDARY_BOMB_DESCRIPTION", $"Throw a bomb that bounces off of terrain and explodes on contact for <style=cIsDamage>{100f * RobomandoStaticValues.bouncyBombDamageCoefficient}% damage.</style> Hold up to 2.");
            #endregion

            #region Utility
            ModLanguage.Add(prefix + "UTILITY_ROLL_NAME", "Evasive Maneuver");
            ModLanguage.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Attempt to roll a short distance. <style=cIsUtility>You cannot be hit during the beginning of the roll.</style>");
            #endregion

            #region Special
            ModLanguage.Add(prefix + "SPECIAL_HACK_NAME", "Re-Wire");
            ModLanguage.Add(prefix + "SPECIAL_HACK_DESCRIPTION", $"<style=cLunarObjective>Jury-Rig. </style>Re-wire a nearby mechanical object, <style=cIsUtility>activating it for free.</style>");
            #endregion

            #region Achievements
            ModLanguage.Add(Tokens.GetAchievementNameToken(RobomandoMasteryAchievement.identifier), "Robomando: Mastery");
            ModLanguage.Add(Tokens.GetAchievementDescriptionToken(RobomandoMasteryAchievement.identifier), "As Robomando, beat the game or obliterate on Monsoon.");
            ModLanguage.Add(Tokens.GetAchievementNameToken(RobomandoGrandMasteryAchievement.identifier), "Robomando: Grandmastery");
            ModLanguage.Add(Tokens.GetAchievementDescriptionToken(RobomandoGrandMasteryAchievement.identifier), "As Robomando, beat the game or obliterate on Typhoon or Eclipse (or higher).");
            ModLanguage.Add(Tokens.GetAchievementNameToken(RobomandoSodaAchievement.identifier), "Robomando: Caffeine Addict");
            ModLanguage.Add(Tokens.GetAchievementDescriptionToken(RobomandoSodaAchievement.identifier), "As Robomando, hack a vending machine.");
            ModLanguage.Add(prefix + "KEYWORD_JURY_RIG", "<style=cKeywordName>Jury-Rig</style><style=cSub>Re-wiring a printer will <style=cIsUtility>give you a scrap depending on the rarity of the printer item</style>, but <style=cDeath>destroys the printer.</style></style>");
            #endregion
        }
    }
}
