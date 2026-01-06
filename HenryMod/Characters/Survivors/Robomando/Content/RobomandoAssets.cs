using RoR2;
using UnityEngine;
using RobomandoMod.Modules;
using System;
using RoR2.Projectile;
using System.Security.Cryptography;
using UnityEngine.AddressableAssets;
using System.Linq;
using RobomandoMod.Characters.Survivors.Robomando.Components;
using System.Collections.Generic;
using R2API;
using Newtonsoft.Json.Utilities;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoAssets
    {
        // particle effects
        public static GameObject zapHitImpactEffect;
        public static GameObject zapMuzzleFlashEffect;
        public static GameObject bombHitWorldEffect;
        public static GameObject zapTracerEffect;

        public static GameObject gunImpactEffect;
        public static GameObject gunMuzzleFlashEffect;
        public static GameObject gunTracerEffect;

        public static GameObject hackEffect;
        public static GameObject hackRedEffect;
        public static GameObject hackRedEffectProc;

        private static List<GameObject> effects = new List<GameObject>();

        public static GameObject projectileBouncyBomb;

        public static GameObject hackIndicator;
        public static GameObject hackIndicatorRed;

        private static AssetBundle _assetBundle;

        private static AssetBundle _vfxAssets;

        public static void Init(AssetBundle assetBundle, AssetBundle vfxbundle)
        {
            _assetBundle = assetBundle;
            _vfxAssets = vfxbundle;
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

            zapHitImpactEffect = LoadEffect("ImpactRobomandoZap");
            zapMuzzleFlashEffect = LoadEffect("RoboZapMuzzleFlash");
            bombHitWorldEffect = LoadEffect("ImpactRobomandoBombBounce");
            zapTracerEffect = LoadEffect("RoboZapTrail");

            gunImpactEffect = LoadEffect("ImpactRobomandoGun");
            gunMuzzleFlashEffect = LoadEffect("RoboGunMuzzleFlash");
            gunTracerEffect = LoadEffect("RoboGunTrail");

            hackEffect = LoadEffect("RobomandoHack");
            hackRedEffect = LoadEffect("RobomandoHackRed");
            hackRedEffectProc = LoadEffect("RobomandoHackRedProc");
            //swordSwingEffect = _assetBundle.LoadEffect("RobomandoSwordSwingEffect", true);
            //swordHitImpactEffect = _assetBundle.LoadEffect("ImpactRobomandoSlash");
        }

        private static GameObject LoadEffect(string prefabName, float lifeTime = 1f)
        {
            GameObject effect = _vfxAssets.LoadEffect(prefabName);
            effects.Add(effect);
            effect.AddComponent<KillVFX>().lifeTime = lifeTime;
            Log.Debug("Loaded {0}".FormatWith(null, prefabName));
            return effect;
        }

        private static GameObject LoadTracer(string prefabName, float lifeTime = 1f) 
        {
            GameObject effect = _vfxAssets.LoadEffect(prefabName);
            effects.Add(effect);
            effect.AddComponent<KillVFX>().lifeTime = lifeTime;

            //var functions = effect.AddComponent<EventFunctions>();

            //var points = effect.AddComponent<BeamPointsFromTransforms>();
            //points.target = effect.GetComponent<LineRenderer>();
            //points.pointTransforms.Append(effect.transform.GetChild(0));
            //points.pointTransforms.Append(effect.transform.GetChild(1));

            //var tracer = effect.AddComponent<Tracer>();
            //tracer.startTransform = effect.transform.GetChild(2);

            //tracer.headTransform = effect.transform.GetChild(0);
            //tracer.tailTransform = effect.transform.GetChild(1);

            //tracer.length = length;
            //tracer.speed = speed;

            //tracer.onTailReachedDestination = new UnityEngine.Events.UnityEvent();

            //tracer.onTailReachedDestination.AddListener(delegate{
            //    functions.UnparentTransform(effect.transform.GetChild(1).GetChild(0));
            //    Log.Debug("It happened");
            //});
            return effect;
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

            hackIndicatorRed = _assetBundle.LoadAsset<GameObject>("RobomandoHackingIndicatorRed");
            ObjectScaleCurve objCurveRed = hackIndicatorRed.transform.GetChild(0).gameObject.AddComponent<ObjectScaleCurve>();
            objCurveRed.timeMax = 0.1f;
            objCurveRed.useOverallCurveOnly = true;
            objCurveRed.resetOnAwake = true;
            curve = objCurveRed.overallCurve;
            curve = new AnimationCurve(frames);
            for (int i = 0; i < curve.length; i++)
            {
                curve.SmoothTangents(i, 0);
            }

            objCurveRed.overallCurve = curve;
            if (hackIndicator == null)
            {
                Debug.LogWarning("HackIndicator is missing!");
            }
            if (hackIndicatorRed == null)
            {
                Debug.LogWarning("HackIndicatorRed is missing!");
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
            projectileBouncyBomb.GetComponent<ProjectileDamage>().damageType.damageSource = DamageSource.Secondary;
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
