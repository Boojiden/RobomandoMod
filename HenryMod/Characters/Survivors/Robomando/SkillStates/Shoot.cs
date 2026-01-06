using EntityStates;
using R2API;
using RobomandoMod.Modules.BaseStates;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Shoot : BaseSkillState
    {
        public static float damageCoefficient = RobomandoStaticValues.shootDamageCoefficient;
        public static float procCoefficient = 1f;
        public static float baseDuration = 0.33f;
        //delay on firing is usually ass-feeling. only set this if you know what you're doing
        public static float firePercentTime = 0.0f;
        public static float force = 100f;
        public static float recoil = 1.2f;
        public static float range = 256f;
        public static GameObject tracerEffectPrefab = RobomandoAssets.gunTracerEffect;
        public static GameObject fireFX = RobomandoAssets.gunMuzzleFlashEffect;
        public static GameObject impactFX = RobomandoAssets.gunImpactEffect;

        private float duration;
        private float fireTime;
        private bool hasFired;
        private string muzzleString;

        public override void OnEnter()
        {
            base.OnEnter();
            duration = baseDuration / attackSpeedStat;
            fireTime = firePercentTime * duration;
            characterBody.SetAimTimer(2f);
            muzzleString = "Muzzle";

            PlayAnimation("RightArm, Override", "ShootGun", "ShootGun.playbackRate", 1.8f);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (fixedAge >= fireTime)
            {
                Fire();
            }

            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        private void Fire()
        {
            if (!hasFired)
            {
                hasFired = true;

                characterBody.AddSpreadBloom(1.5f);
                EffectManager.SimpleMuzzleFlash(fireFX, gameObject, muzzleString, false);
                Util.PlaySound("Play_Robo_Shoot", gameObject);

                if (isAuthority)
                {
                    Ray aimRay = GetAimRay();
                    AddRecoil(-1f * recoil, -2f * recoil, -0.5f * recoil, 0.5f * recoil);

                    var bullet = new BulletAttack
                    {
                        bulletCount = 1,
                        aimVector = aimRay.direction,
                        origin = aimRay.origin,
                        damage = damageCoefficient * damageStat,
                        damageColorIndex = DamageColorIndex.Default,
                        damageType = DamageType.Generic,
                        falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                        maxDistance = range,
                        force = force,
                        hitMask = LayerIndex.CommonMasks.bullet,
                        minSpread = 0f,
                        maxSpread = 0f,
                        isCrit = RollCrit(),
                        owner = gameObject,
                        muzzleName = muzzleString,
                        smartCollision = true,
                        procChainMask = default,
                        procCoefficient = procCoefficient,
                        radius = 0.75f,
                        sniper = false,
                        stopperMask = LayerIndex.CommonMasks.bullet,
                        weapon = null,
                        tracerEffectPrefab = tracerEffectPrefab,
                        spreadPitchScale = 1f,
                        spreadYawScale = 1f,
                        queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                        hitEffectPrefab = impactFX,
                    };
                    bullet.damageType.damageSource = DamageSource.Primary;
                    bullet.Fire();
                }
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }
    }
}