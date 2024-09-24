using RoR2;
using RoR2.CharacterAI;
using UnityEngine;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoAI
    {
        public static void Init(GameObject bodyPrefab, string masterName)
        {
            GameObject master = Modules.Prefabs.CreateBlankMasterPrefab(bodyPrefab, masterName);

            BaseAI baseAI = master.GetComponent<BaseAI>();
            baseAI.aimVectorDampTime = 0.1f;
            baseAI.aimVectorMaxSpeed = 360;

            //mouse over these fields for tooltips
            AISkillDriver shotDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            shotDriver.customName = "Use Primary Shot";
            shotDriver.skillSlot = SkillSlot.Primary;
            shotDriver.requiredSkill = null; //usually used when you have skills that override other skillslots like engi harpoons
            shotDriver.requireSkillReady = false; //usually false for primaries
            shotDriver.requireEquipmentReady = false;
            shotDriver.minUserHealthFraction = float.NegativeInfinity;
            shotDriver.maxUserHealthFraction = float.PositiveInfinity;
            shotDriver.minTargetHealthFraction = float.NegativeInfinity;
            shotDriver.maxTargetHealthFraction = float.PositiveInfinity;
            shotDriver.minDistance = 0;
            shotDriver.maxDistance = 256;
            shotDriver.selectionRequiresTargetLoS = true;
            shotDriver.selectionRequiresOnGround = false;
            shotDriver.selectionRequiresAimTarget = false;
            shotDriver.maxTimesSelected = -1;

            //Behavior
            shotDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            shotDriver.activationRequiresTargetLoS = false;
            shotDriver.activationRequiresAimTargetLoS = false;
            shotDriver.activationRequiresAimConfirmation = false;
            shotDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            shotDriver.moveInputScale = 1;
            shotDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            shotDriver.ignoreNodeGraph = false; //will chase relentlessly but be kind of stupid
            shotDriver.shouldSprint = false; 
            shotDriver.shouldFireEquipment = false;
            shotDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold; 

            //Transition Behavior
            shotDriver.driverUpdateTimerOverride = -1;
            shotDriver.resetCurrentEnemyOnNextDriverSelection = false;
            shotDriver.noRepeat = false;
            shotDriver.nextHighPriorityOverride = null;

            //some fields omitted that aren't commonly changed. will be set to default values
            AISkillDriver shootDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            shootDriver.customName = "Use Secondary Shoot";
            shootDriver.skillSlot = SkillSlot.Secondary;
            shootDriver.requireSkillReady = true;
            shootDriver.minDistance = 0;
            shootDriver.maxDistance = 25;
            shootDriver.selectionRequiresTargetLoS = false;
            shootDriver.selectionRequiresOnGround = false;
            shootDriver.selectionRequiresAimTarget = false;
            shootDriver.maxTimesSelected = -1;

            //Behavior
            shootDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            shootDriver.activationRequiresTargetLoS = false;
            shootDriver.activationRequiresAimTargetLoS = false;
            shootDriver.activationRequiresAimConfirmation = true;
            shootDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            shootDriver.moveInputScale = 1;
            shootDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            shootDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold; 
            
            AISkillDriver rollDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            rollDriver.customName = "Use Utility Roll";
            rollDriver.skillSlot = SkillSlot.Utility;
            rollDriver.requireSkillReady = true;
            rollDriver.minDistance = 8;
            rollDriver.maxDistance = 20;
            rollDriver.selectionRequiresTargetLoS = true;
            rollDriver.selectionRequiresOnGround = false;
            rollDriver.selectionRequiresAimTarget = false;
            rollDriver.maxTimesSelected = -1;

            //Behavior
            rollDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            rollDriver.activationRequiresTargetLoS = false;
            rollDriver.activationRequiresAimTargetLoS = false;
            rollDriver.activationRequiresAimConfirmation = false;
            rollDriver.movementType = AISkillDriver.MovementType.StrafeMovetarget;
            rollDriver.moveInputScale = 1;
            rollDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            rollDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;

            AISkillDriver bombDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            bombDriver.customName = "Use Special bomb";
            bombDriver.skillSlot = SkillSlot.Special;
            bombDriver.requireSkillReady = true;
            bombDriver.minDistance = 0;
            bombDriver.maxDistance = 20;
            bombDriver.selectionRequiresTargetLoS = false;
            bombDriver.selectionRequiresOnGround = false;
            bombDriver.selectionRequiresAimTarget = false;
            bombDriver.maxTimesSelected = -1;

            //Behavior
            bombDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            bombDriver.activationRequiresTargetLoS = false;
            bombDriver.activationRequiresAimTargetLoS = false;
            bombDriver.activationRequiresAimConfirmation = false;
            bombDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            bombDriver.moveInputScale = 1;
            bombDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            bombDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;

            AISkillDriver chaseDriver = master.AddComponent<AISkillDriver>();
            //Selection Conditions
            chaseDriver.customName = "Chase";
            chaseDriver.skillSlot = SkillSlot.None;
            chaseDriver.requireSkillReady = false;
            chaseDriver.minDistance = 0;
            chaseDriver.maxDistance = float.PositiveInfinity;

            //Behavior
            chaseDriver.moveTargetType = AISkillDriver.TargetType.CurrentEnemy;
            chaseDriver.activationRequiresTargetLoS = false;
            chaseDriver.activationRequiresAimTargetLoS = false;
            chaseDriver.activationRequiresAimConfirmation = false;
            chaseDriver.movementType = AISkillDriver.MovementType.ChaseMoveTarget;
            chaseDriver.moveInputScale = 1;
            chaseDriver.aimType = AISkillDriver.AimType.AtMoveTarget;
            chaseDriver.buttonPressType = AISkillDriver.ButtonPressType.Hold;

            //recommend taking these for a spin in game, messing with them in runtimeinspector to get a feel for what they should do at certain ranges and such
        }
    }
}
