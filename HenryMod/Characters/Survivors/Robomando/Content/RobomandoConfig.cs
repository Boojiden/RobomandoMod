using BepInEx.Configuration;
using RobomandoMod.Modules;
using RiskOfOptions;
using RiskOfOptions.Options;
using RiskOfOptions.OptionConfigs;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoConfig
    {
        public static ConfigEntry<bool> allowStatTweaks;

        public static ConfigEntry<bool> RoboTalks;

        public static ConfigEntry<bool> EnableCommandoSkin;
        public static ConfigEntry<bool> EnableBlueSkin;
        public static ConfigEntry<bool> EnableGreenSkin;
        public static ConfigEntry<bool> EnableMasterySkin;
        public static ConfigEntry<bool> EnableGrandmasterySkin;
        public static ConfigEntry<bool> EnableSodaSkin;

        public static ConfigEntry<float> SingleShotDamageReplacement;
        public static ConfigEntry<float> SingleShotCoefficientReplacement;

        public static ConfigEntry<float> ZapDamageReplacement;
        public static ConfigEntry<float> ZapCoefficientReplacement;
        public static ConfigEntry<float> ZapCooldownReplacement;

        public static ConfigEntry<float> DiveCooldownReplacement;
        public static ConfigEntry<float> DiveCrashReplacement;

        public static ConfigEntry<float> HackCooldownReplacement;
        public static ConfigEntry<float> HackFailCooldownReplacement;
        public static ConfigEntry<float> HackDurationReplacement;

        public static bool allowStatTweaksOnLaunch;

        public static void ApplySingleShotChange()
        {
            if(!CheckIfShouldApplyConfigStats())
            {
                return;
            }
            RobomandoStaticValues.shootDamageCoefficient = SingleShotDamageReplacement.Value / 100f;
            RobomandoStaticValues.shootProcCoefficient = SingleShotCoefficientReplacement.Value;
            RobomandoTokens.ChangeSingleShotText();
        }

        public static void ApplyZapChange()
        {
            if (!CheckIfShouldApplyConfigStats())
            {
                return;
            }
            RobomandoStaticValues.zapDamageCoefficient = ZapDamageReplacement.Value / 100f;
            RobomandoStaticValues.zapProcCoefficient = ZapCoefficientReplacement.Value;
            RobomandoStaticValues.zapCooldown = ZapCooldownReplacement.Value;
            RobomandoTokens.ChangeZapText();
        }

        public static void ApplyDiveChanges()
        {
            if (!CheckIfShouldApplyConfigStats())
            {
                return;
            }
            RobomandoStaticValues.diveCooldown = DiveCooldownReplacement.Value;
            RobomandoStaticValues.diveCrashTime = DiveCrashReplacement.Value;
        }

        public static void ApplyHackChanges()
        {
            if (!CheckIfShouldApplyConfigStats())
            {
                return;
            }
            RobomandoStaticValues.hackTime = HackDurationReplacement.Value;
            RobomandoStaticValues.successfullHackCooldown = HackCooldownReplacement.Value;
            RobomandoStaticValues.unsuccessfullHackCooldown = HackFailCooldownReplacement.Value;
        }

        private static bool CheckIfStatsDisabled()
        {
            return !allowStatTweaks.Value;
        }

        private static bool CheckIfShouldApplyConfigStats()
        {
            return allowStatTweaksOnLaunch;
        }

        public static void Init()
        {
            string section = "Audio";
            RoboTalks = Config.BindAndOptions(
                section,
                "Robomando Talks",
                true,
                "Whether or not Robomando will talk.");
            ModSettingsManager.AddOption(new CheckBoxOption(RoboTalks));

            string nonPercentFormatString = "{0:0}";
            string durationFormatString = "{0:0}s";
            string duration2SigFigFormatString = "{0:0.00}s";

            allowStatTweaks = Config.MyConfig.Bind<bool>("Abilities", "Allow Ability Stat Modifiers", false, "Allow for the editing of Robomando's ability stats. Uncheck if you plan on playing multiplayer, since configs are as of yet unsynced.");
            allowStatTweaksOnLaunch = allowStatTweaks.Value;
            ModSettingsManager.AddOption(new CheckBoxOption(allowStatTweaks, true));

            SingleShotDamageReplacement = Config.MyConfig.Bind<float>("Abilities", "Single Shot Damage", 100, "Sets the damage of Single Shot.");
            ModSettingsManager.AddOption(new SliderOption(SingleShotDamageReplacement, new SliderConfig{ min = 10, max = 300, checkIfDisabled = CheckIfStatsDisabled }));
            SingleShotCoefficientReplacement = Config.MyConfig.Bind<float>("Abilities", "Single Shot Proc Coefficient", 1, "Sets the proc coefficient of Single Shot.");
            ModSettingsManager.AddOption(new SliderOption(SingleShotCoefficientReplacement, new SliderConfig { min = 0, max = 10, FormatString = nonPercentFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            ApplySingleShotChange();

            ZapDamageReplacement = Config.MyConfig.Bind<float>("Abilities", "De-Escalate Shot Damage", 300, "Sets the damage of De-Escalate.");
            ModSettingsManager.AddOption(new SliderOption(ZapDamageReplacement, new SliderConfig { min = 100, max = 1000, checkIfDisabled = CheckIfStatsDisabled }));
            ZapCoefficientReplacement = Config.MyConfig.Bind<float>("Abilities", "Zap Proc Coefficient", 3, "Sets the proc coefficient of De-Escalate.");
            ModSettingsManager.AddOption(new SliderOption(ZapCoefficientReplacement, new SliderConfig { min = 0, max = 10 , FormatString = nonPercentFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            ZapCooldownReplacement = Config.MyConfig.Bind<float>("Abilities", "Zap Cooldown", 3, "Sets the cooldown of De-Escalate (Requires Restart).");
            ModSettingsManager.AddOption(new SliderOption(ZapCooldownReplacement, new SliderConfig { min = 0.5f, max = 10, FormatString = durationFormatString, restartRequired = true, checkIfDisabled = CheckIfStatsDisabled }));
            ApplyZapChange();

            DiveCooldownReplacement = Config.MyConfig.Bind<float>("Abilities", "Evasive Maneuver Cooldown", 4, "Sets the cooldown of Evasive Maneuver (Requires Restart).");
            ModSettingsManager.AddOption(new SliderOption(DiveCooldownReplacement, new SliderConfig { min = 0.5f, max = 10, FormatString = durationFormatString, restartRequired = true , checkIfDisabled = CheckIfStatsDisabled }));
            DiveCrashReplacement = Config.MyConfig.Bind<float>("Abilities", "Evasive Maneuver Crash Duration", 2, "How long is Robomando stunned when Evasive Maneuver ends?");
            ModSettingsManager.AddOption(new SliderOption(DiveCrashReplacement, new SliderConfig { min = 0.5f, max = 10, FormatString = duration2SigFigFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            ApplyDiveChanges();

            HackDurationReplacement = Config.MyConfig.Bind<float>("Abilities", "Re-Wire Duration", 3.33f, "How long is Robomando's Re-Wire animation at base?");
            ModSettingsManager.AddOption(new SliderOption(HackDurationReplacement, new SliderConfig { min = 0.5f, max = 10, FormatString = duration2SigFigFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            HackCooldownReplacement = Config.MyConfig.Bind<float>("Abilities", "Re-Wire Success Cooldown", 8, "Sets the cooldown of Re-Wire after successfully hacking something.");
            ModSettingsManager.AddOption(new SliderOption(HackCooldownReplacement, new SliderConfig { min = 0.5f, max = 30, FormatString = durationFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            HackFailCooldownReplacement = Config.MyConfig.Bind<float>("Abilities", "Re-Wire Failure Cooldown", 2, "Sets the cooldown of Re-Wire after not hacking something.");
            ModSettingsManager.AddOption(new SliderOption(HackFailCooldownReplacement, new SliderConfig { min = 0.5f, max = 30, FormatString = durationFormatString, checkIfDisabled = CheckIfStatsDisabled }));
            ApplyHackChanges();

            SingleShotDamageReplacement.SettingChanged += (sender, args) => { ApplySingleShotChange(); };
            SingleShotCoefficientReplacement.SettingChanged += (sender, args) => { ApplySingleShotChange(); };

            ZapDamageReplacement.SettingChanged += (sender, args) => { ApplyZapChange(); };
            ZapCoefficientReplacement.SettingChanged += (sender, args) => { ApplyZapChange(); };
            ZapCooldownReplacement.SettingChanged += (sender, args) => { ApplyZapChange(); };

            DiveCooldownReplacement.SettingChanged += (sender, args) => { ApplyDiveChanges(); };
            DiveCrashReplacement.SettingChanged += (sender, args) => { ApplyDiveChanges(); };

            HackDurationReplacement.SettingChanged += (sender, args) => { ApplyHackChanges(); };
            HackCooldownReplacement.SettingChanged += (sender, args) => { ApplyHackChanges(); };
            HackFailCooldownReplacement.SettingChanged += (sender, args) => { ApplyHackChanges(); };

            EnableCommandoSkin = Config.MyConfig.Bind<bool>("Skins", "Enable Like Father, Like Son", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableCommandoSkin, true));

            EnableBlueSkin = Config.MyConfig.Bind<bool>("Skins", "Enable Soaked", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableBlueSkin, true));

            EnableGreenSkin = Config.MyConfig.Bind<bool>("Skins", "Enable Goblin", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableGreenSkin, true));

            EnableMasterySkin = Config.MyConfig.Bind<bool>("Skins", "Enable Heros Disciple", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableMasterySkin, true));

            EnableGrandmasterySkin = Config.MyConfig.Bind<bool>("Skins", "Enable Trophy Taker", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableGrandmasterySkin, true));

            EnableSodaSkin = Config.MyConfig.Bind<bool>("Skins", "Enable Caffeinated Cretin", true);
            ModSettingsManager.AddOption(new CheckBoxOption(EnableSodaSkin, true));
            /*
             someConfigFloat = Config.BindAndOptions(
                 section,
                 "someConfigfloat",
                 5f);//blank description will default to just the name

             someConfigFloatWithCustomRange = Config.BindAndOptions(
                 section,
                 "someConfigfloat2",
                 5f,
                 0,
                 50,
                 "if a custom range is not passed in, a float will default to a slider with range 0-20. risk of options only has sliders");
            */
        }
    }
}
