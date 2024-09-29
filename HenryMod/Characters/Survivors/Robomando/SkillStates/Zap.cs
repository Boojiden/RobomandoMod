using EntityStates;
using R2API;
using Rewired;
using RobomandoMod.Survivors.Robomando;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.ResourceLocations;
using static RoR2.BulletAttack;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Zap : BaseSkillState
    {
        public static float damageCoefficient = RobomandoStaticValues.zapDamageCoefficient;
        public static float procCoefficient = 3f;
        public static float baseDuration = 0.6f;
        //delay on firing is usually ass-feeling. only set this if you know what you're doing
        public static float firePercentTime = 0.0f;
        public static float force = 800f;
        public static float recoil = 3f;
        public static float range = 64f;

        //RoR2/Junk/Wisp/TracerWisp.prefab
        //RoR2/Base/Golem/TracerGolem.prefab
        public static GameObject tracerEffectPrefab = Addressables.LoadAssetAsync<GameObject>("RoR2/Junk/Wisp/TracerWisp.prefab").WaitForCompletion();
        //public static GameObject fireFX = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Common/VFX/Hitspark1.prefab").WaitForCompletion();
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

            PlayAnimation("LeftArm, Override", "ShootGun", "ShootGun.playbackRate", 1.8f);
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
                EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FireBarrage.effectPrefab, gameObject, muzzleString, false);
                Util.PlaySound("Tazer", gameObject);

                if (isAuthority)
                {
                    Ray aimRay = GetAimRay();
                    AddRecoil(-1f * recoil, -2f * recoil, -0.5f * recoil, 0.5f * recoil);

                    GameObject tracer = tracerEffectPrefab;
                    //tracer.transform.GetChild(2).localScale = new Vector3 (0f, 64f, 0f);
                    Destroy(tracer.GetComponent<Tracer>());
                    Tracer tr = tracer.AddComponent<Tracer>();
                    tr.startTransform = tracer.transform.GetChild(2).GetChild(0);
                    tr.beamObject = tracer.transform.GetChild(2).gameObject;
                    tr.beamDensity = 10;
                    tr.headTransform = tracer.transform.GetChild(0);
                    tr.tailTransform = tracer.transform.GetChild(1);
                    tr.speed = 250;
                    tr.length = 64;
                    tracer.AddComponent<DestroyOnTimer>().duration = 1f;

                    LineRenderer lr = tracer.GetComponent<LineRenderer>();
                    lr.widthCurve.keys[0].value = 0.75f;
                    //lr.enabled = false;


                    BulletAttack attack = new BulletAttack
                    {
                        bulletCount = 1,
                        aimVector = aimRay.direction,
                        origin = aimRay.origin,
                        damage = damageCoefficient * damageStat,
                        damageColorIndex = DamageColorIndex.Default,
                        damageType = DamageType.Stun1s,
                        falloffModel = BulletAttack.FalloffModel.None,
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
                        radius = 1f,
                        sniper = false,
                        stopperMask = LayerIndex.world.mask,
                        weapon = null,
                        tracerEffectPrefab = tracer,
                        spreadPitchScale = 1f,
                        spreadYawScale = 1f,
                        queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                        hitEffectPrefab = RobomandoAssets.zapHitImpactEffect,
                    };
                    attack.Fire();
                }
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}