﻿using RoR2;
using RobomandoMod.Modules.Achievements;

namespace RobomandoMod.Survivors.Robomando.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, null)]
    public class RobomandoMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = RobomandoSurvivor.ROBO_PREFIX + "MasteryAchievement";
        public const string unlockableIdentifier = RobomandoSurvivor.ROBO_PREFIX + "MasteryUnlockable";

        public override string RequiredCharacterBody => RobomandoSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}