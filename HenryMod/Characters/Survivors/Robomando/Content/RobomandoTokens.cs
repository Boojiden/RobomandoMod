using System;
using RobomandoMod.Modules;
using RobomandoMod.Survivors.Robomando.Achievements;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoTokens
    {
        public static void Init()
        {
            AddRobomandoTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Robomando.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void ChangeSingleShotText()
        {
            string prefix = RobomandoSurvivor.HENRY_PREFIX;
            Language.SetTemporaryValue(prefix + "PRIMARY_SHOT_DESCRIPTION", Tokens.agilePrefix + $" Shoot for <style=cIsDamage>{100f * RobomandoStaticValues.shootDamageCoefficient}% damage</style>.");
        }

        public static void ChangeZapText()
        {
            string prefix = RobomandoSurvivor.HENRY_PREFIX;
            Language.SetTemporaryValue(prefix + "SECONDARY_ZAP_DESCRIPTION", Tokens.agilePrefix + $" <style=cIsDamage>Stunning.</style> Fire a small, <style=cIsDamage>piercing</style> electric pulse for <style=cIsDamage>{100f * RobomandoStaticValues.zapDamageCoefficient}% damage.");
        }

        public static void AddRobomandoTokens()
        {
            string prefix = RobomandoSurvivor.HENRY_PREFIX;

            string desc = "Your Robomando Model 7 is equipped with all of the tools necessary to salvage any mechanical device encountered in the wild.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > His Hack can co-op machines of any kind, even from a competitor!" + Environment.NewLine + Environment.NewLine
             + "< ! > Please keep in mind that, while your Robomando is equipped with offensive abilities, it is not designed for hostile environments" + Environment.NewLine + Environment.NewLine
             + "< ! > Built for speed, he is faster than most people on his feet, but isn't very durable. Use this speed to your advantage. It is generally more effective to run instead of roll." + Environment.NewLine + Environment.NewLine
             + "< ! > While he himself may have weak damage, items that scale off of damage are generally stronger when used by Robomando. Use his hack to run through stages and quickly gain offensive items." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so it left nothing behind.";
            string outroFailure = "..and so it failed, to no one's particular surprise or excitement.";

            string lore = "I thought the advertisements were bogus at first. I mean, this little toy soldier is able to hack into any mechanical device? It sounded like bullshit." + Environment.NewLine + Environment.NewLine
                + "Well, imagine my shock when the thing hotwired my car and took it for a joyride. Found it two hours later totaled in a ditch. Apparently the thing couldn't reach the steering wheel." + Environment.NewLine + Environment.NewLine
                + "It really just seemed like a toy to me. I hope to God no unaware parents got this little freak for their kids.";

            Language.Add(prefix + "NAME", "Robomando");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "God's Strongest Soldier");
            Language.Add(prefix + "LORE", lore);
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Hero's Disciple");
            Language.Add(prefix + "GRANDMASTERY_SKIN_NAME", "Trophy Taker");
            Language.Add(prefix + "COMMANDO_SKIN_NAME", "Like Father, Like Son");
            Language.Add(prefix + "BLUE_SKIN_NAME", "Soaked");
            Language.Add(prefix + "GREEN_SKIN_NAME", "Goblin");
            Language.Add(prefix + "SODA_SKIN_NAME", "Caffeinated Cretin");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "Robomando passive");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Sample text.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_SHOT_NAME", "Single Fire");
            Language.Add(prefix + "PRIMARY_SHOT_DESCRIPTION", Tokens.agilePrefix + $" Shoot for <style=cIsDamage>{100f * RobomandoStaticValues.shootDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_ZAP_NAME", "De-Escalate");
            Language.Add(prefix + "SECONDARY_ZAP_DESCRIPTION", Tokens.agilePrefix+ $" <style=cIsDamage>Stunning.</style> Fire a small, <style=cIsDamage>piercing</style> electric pulse for <style=cIsDamage>{100f * RobomandoStaticValues.zapDamageCoefficient}% damage.");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_ROLL_NAME", "Evasive Maneuver");
            Language.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Attempt to roll a short distance. <style=cIsUtility>You cannot be hit during the beginning of the roll.</style>");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_HACK_NAME", "Re-Wire");
            Language.Add(prefix + "SPECIAL_HACK_DESCRIPTION", $"<style=cLunarObjective>Jury-Rig. </style>Re-wire a nearby mechanical object, <style=cIsUtility>activating it for free.</style>");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(RobomandoMasteryAchievement.identifier), "Robomando: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(RobomandoMasteryAchievement.identifier), "As Robomando, beat the game or obliterate on Monsoon.");
            Language.Add(Tokens.GetAchievementNameToken(RobomandoGrandMasteryAchievement.identifier), "Robomando: Grandmastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(RobomandoGrandMasteryAchievement.identifier), "As Robomando, beat the game or obliterate on Typhoon or Eclipse (or higher).");
            Language.Add(Tokens.GetAchievementNameToken(RobomandoSodaAchievement.identifier), "Robomando: Caffeine Addict");
            Language.Add(Tokens.GetAchievementDescriptionToken(RobomandoSodaAchievement.identifier), "As Robomando, hack a vending machine.");
            Language.Add(prefix + "KEYWORD_JURY_RIG", "<style=cKeywordName>Jury-Rig</style><style=cSub>Re-wiring a printer will <style=cIsUtility>give you a scrap depending on the rarity of the printer item</style>, but <style=cDeath>destroys the printer.</style></style>");
            #endregion
        }
    }
}
