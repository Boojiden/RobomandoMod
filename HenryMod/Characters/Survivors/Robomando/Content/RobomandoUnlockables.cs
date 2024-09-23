using RobomandoMod.Survivors.Robomando.Achievements;
using RoR2;
using UnityEngine;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                RobomandoMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(RobomandoMasteryAchievement.identifier),
                RobomandoSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
