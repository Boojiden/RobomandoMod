using EntityStates;
using RobomandoMod.Survivors.Robomando;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class BouncyBomb : GenericProjectileBaseState
    {
        public override void OnEnter()
        {
            projectilePrefab = RobomandoAssets.projectileBouncyBomb;

            attackSoundString = "Play_commando_M2_grenade_throw";

            baseDuration = 0.65f;
            baseDelayBeforeFiringProjectile = 0f;
            damageCoefficient = RobomandoStaticValues.bouncyBombDamageCoefficient;
            force = 60f;
            

            recoilAmplitude = 0.1f;
            bloom = 10;
            base.OnEnter();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        public override void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("LeftArm, Override", "ThrowBomb", "Bomb.playbackRate", this.duration / 4f);
            }
        }
    }
}
