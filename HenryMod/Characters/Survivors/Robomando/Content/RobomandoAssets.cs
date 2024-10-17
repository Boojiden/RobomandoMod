using RoR2;
using UnityEngine;
using RobomandoMod.Modules;
using System;
using RoR2.Projectile;
using System.Security.Cryptography;
using UnityEngine.AddressableAssets;
using System.Linq;
using RobomandoMod.Characters.Survivors.Robomando.Components;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoAssets
    {
        // particle effects
        public static GameObject zapHitImpactEffect;
        public static GameObject bombHitWorldEffect;

        public static GameObject projectileBouncyBomb;

        public static GameObject hackIndicator;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {
            _assetBundle = assetBundle;
            CreateEffects();
            CreateUI();
            /*
            

            swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("RobomandoSwordHit");

            CreateEffects();
            */
            CreateProjectiles();
            
        }

        #region effects
        private static void CreateEffects()
        {
            //CreateBombExplosionEffect();

            zapHitImpactEffect = _assetBundle.LoadEffect("ImpactRobomandoZap");
            bombHitWorldEffect = _assetBundle.LoadEffect("ImpactRobomandoBombBounce");
            //swordSwingEffect = _assetBundle.LoadEffect("RobomandoSwordSwingEffect", true);
            //swordHitImpactEffect = _assetBundle.LoadEffect("ImpactRobomandoSlash");
        }

        private static void CreateUI()
        {
            hackIndicator = _assetBundle.LoadAsset<GameObject>("RobomandoHackingIndicator");
            Keyframe[] frames =
                {
                    new Keyframe(0f, 1.4f),
                    new Keyframe(1f, 0.9f)
                };
            ObjectScaleCurve objCurve = hackIndicator.transform.GetChild(0).gameObject.AddComponent<ObjectScaleCurve>();
            objCurve.timeMax = 0.1f;
            objCurve.useOverallCurveOnly = true;
            objCurve.resetOnAwake = true;
            var curve = objCurve.overallCurve;
            curve = new AnimationCurve(frames);
            for (int i = 0; i < curve.length; i++)
            {
                curve.SmoothTangents(i, 0);
            }

            objCurve.overallCurve = curve;
            if (hackIndicator == null)
            {
                Debug.LogWarning("HackIndicator is missing!");
            }
        }

        private static void CreateBombExplosionEffect()
        {
            /*
            bombExplosionEffect = _assetBundle.LoadEffect("BombExplosionEffect", "RobomandoBombExplosion");

            if (!bombExplosionEffect)
                return;

            ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
            shakeEmitter.amplitudeTimeDecay = true;
            shakeEmitter.duration = 0.5f;
            shakeEmitter.radius = 200f;
            shakeEmitter.scaleShakeRadiusWithLocalScale = false;

            shakeEmitter.wave = new Wave
            {
                amplitude = 1f,
                frequency = 40f,
                cycleOffset = 0f
            };
            */
        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            
            CreateBombProjectile();
            Content.AddProjectilePrefab(projectileBouncyBomb);
            
        }

        private static void CreateBombProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            projectileBouncyBomb = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "RobomandoBombProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(projectileBouncyBomb.GetComponent<ProjectileImpactExplosion>());
            projectileBouncyBomb.GetComponent<ProjectileSimple>().lifetime = 99f;
            ProjectileImpactExplosion bombImpactExplosion = projectileBouncyBomb.AddComponent<ProjectileImpactExplosion>();
            
            bombImpactExplosion.blastRadius = 8f;
            bombImpactExplosion.blastProcCoefficient = RobomandoStaticValues.bouncyBombProcCoefficient;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 6f;
            bombImpactExplosion.impactEffect = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/StickyBomb/BehemothVFX.prefab").WaitForCompletion(); ;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("Play_item_proc_behemoth");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 0.25f;
            bombImpactExplosion.destroyOnWorld = false;
            bombImpactExplosion.impactOnWorld = false;
            bombImpactExplosion.explodeOnLifeTimeExpiration = true;

            var bouncyMat = _assetBundle.LoadAsset<PhysicMaterial>("BouncyBombPhysicsMaterial");

            ProjectileController bombController = bombImpactExplosion.GetComponent<ProjectileController>();

            if (_assetBundle.LoadAsset<GameObject>("BouncyBombGhost") != null)
                bombController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("BouncyBombGhost");
            
            bombController.startSound = "";

            projectileBouncyBomb.GetComponent<Collider>().material = bouncyMat;

            projectileBouncyBomb.AddComponent<BombImpactComponent>();


        }
        #endregion projectiles

    }
}
