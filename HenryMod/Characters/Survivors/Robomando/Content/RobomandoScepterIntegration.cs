using AncientScepter;
using RobomandoMod.Modules;
using RobomandoMod.Modules.Characters;
using RobomandoMod.Survivors.Robomando;
using RobomandoMod.Survivors.Robomando.SkillStates;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace RobomandoMod.Characters.Survivors.Robomando.Content
{
    public class RobomandoScepterIntegration
    {
        public static ItemDef scepterDef;
        public static GameObject scepterDisplay;
        public static void Init(SurvivorBase<RobomandoSurvivor> robo, SkillFamily family, SkillDef specialSkillDef2)
        {
            ItemBase<AncientScepterItem>.instance.RegisterScepterSkill(specialSkillDef2, robo.bodyName, SkillSlot.Special, 0);
            scepterDef = ItemBase<AncientScepterItem>.myDef;
            scepterDisplay = ItemBase<AncientScepterItem>.displayPrefab;
            //Skills.AddSpecialSkills(robo.bodyPrefab, specialSkillDef2);
        }
    }
}
