using RoR2;
using RobomandoMod.Modules.Achievements;
using RoR2.Achievements;
using UnityEngine;
using RobomandoMod.Survivors.Robomando.SkillStates;

namespace RobomandoMod.Survivors.Robomando.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, 10, typeof(RobomandoSodaAchievementServer))]
    public class RobomandoSodaAchievement : BaseAchievement
    {
        public const string identifier = RobomandoSurvivor.ROBO_PREFIX + "SodaAchievement";
        public const string unlockableIdentifier = RobomandoSurvivor.ROBO_PREFIX + "SodaUnlockable";

        public static string RequiredCharacterBody => RobomandoSurvivor.instance.bodyName;

        public override void OnInstall()
        {
            base.OnInstall();
            SetServerTracked(true);
        }

        private class RobomandoSodaAchievementServer: BaseServerAchievement
        {
            public override void OnInstall()
            {
                base.OnInstall();
                Hack.onRobomandoHackGlobal += OnHack;
                Overwire.onRobomandoHackGlobal += OnHack;
            }

            private void OnHack(GameObject robo, GameObject device)
            {
                CharacterBody body = robo.GetComponent<CharacterBody>();
                if(body.Equals(this.serverAchievementTracker.networkUser.GetCurrentBody()))
                {
                    PurchaseInteraction pItner = device.GetComponent<PurchaseInteraction>();
                    if(pItner.displayNameToken == "VENDING_MACHINE_NAME")
                    {
                        base.Grant();
                    }
                }
            }

            public override void OnUninstall()
            {
                base.OnUninstall();
                Hack.onRobomandoHackGlobal -= OnHack;
            }
        }

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skin;
    }
}