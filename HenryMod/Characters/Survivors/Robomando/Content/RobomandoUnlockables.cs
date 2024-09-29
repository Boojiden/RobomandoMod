using RobomandoMod.Survivors.Robomando.Achievements;
using RoR2;
using UnityEngine;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;
        public static UnlockableDef grandMasterySkinUnlockableDef = null;
        public static UnlockableDef sodaSkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                RobomandoMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(RobomandoMasteryAchievement.identifier),
                RobomandoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texProvidenceSkin"));

            grandMasterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                RobomandoGrandMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(RobomandoGrandMasteryAchievement.identifier),
                RobomandoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texTrueProvidenceSkin"));

            sodaSkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                RobomandoSodaAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(RobomandoSodaAchievement.identifier),
                RobomandoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texSodaSkin"));
        }
    }
}
