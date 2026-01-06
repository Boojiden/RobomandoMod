using R2API.Networking;
using RobomandoMod.Survivors.Robomando;
using RobomandoMod.Survivors.Robomando.SkillStates;
using RoR2;
using RoR2BepInExPack.GameAssetPaths;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Overwire : Hack
    {
        public static float doubleChance = 0.2f;

        public override HackNetMessage ModifyHackMessage(HackNetMessage message, CharacterMaster master)
        {
            message.procScepter = Run.instance.runRNG.nextNormalizedFloat <= doubleChance;
            if (!master)
            {
                return base.ModifyHackMessage(message, master);
            }
            if(master.luck == 0)
            {
                return base.ModifyHackMessage(message, master);
            }
            else
            {
                int rolls = (int)Math.Floor(Math.Abs(master.luck));
                for(int i = 0; i < rolls; i++)
                {
                    bool newProc = Run.instance.runRNG.nextNormalizedFloat <= doubleChance;
                    if ((master.luck < 0 && !newProc) || (master.luck > 0 && newProc))
                    {
                        message.procScepter = newProc;
                        break;
                    }
                }
                return message;
            }
        }

        public override GameObject ModifyHackEffect(HackNetMessage message)
        {
            if (message.procScepter)
            {
                return RobomandoAssets.hackRedEffectProc;
            }
            return RobomandoAssets.hackRedEffect;
        }
    }
}
