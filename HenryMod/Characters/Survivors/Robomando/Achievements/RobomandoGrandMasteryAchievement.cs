﻿using RoR2;
using RobomandoMod.Modules.Achievements;

namespace RobomandoMod.Survivors.Robomando.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 20, null)]
    public class RobomandoGrandMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = RobomandoSurvivor.HENRY_PREFIX + "GrandMasteryAchievement";
        public const string unlockableIdentifier = RobomandoSurvivor.HENRY_PREFIX + "GrandMasteryUnlockable";

        public override string RequiredCharacterBody => RobomandoSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3.5f;
    }
}