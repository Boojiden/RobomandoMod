﻿using RoR2;
using UnityEngine;
using RobomandoMod.Modules;
using System;
using RoR2.Projectile;
using System.Security.Cryptography;

namespace RobomandoMod.Survivors.Robomando
{
    public static class RobomandoAssets
    {
        // particle effects
        public static GameObject zapHitImpactEffect;

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

            CreateProjectiles();
            */
        }

        #region effects
        private static void CreateEffects()
        {
            CreateBombExplosionEffect();

            zapHitImpactEffect = _assetBundle.LoadEffect("ImpactRobomandoZap");
            
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
            /*
            CreateBombProjectile();
            Content.AddProjectilePrefab(bombProjectilePrefab);
            */
        }

        private static void CreateBombProjectile()
        {
            /*
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            bombProjectilePrefab = Asset.CloneProjectilePrefab("CommandoGrenadeProjectile", "RobomandoBombProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(bombProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion bombImpactExplosion = bombProjectilePrefab.AddComponent<ProjectileImpactExplosion>();
            
            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = bombExplosionEffect;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("RobomandoBombExplosion");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = bombProjectilePrefab.GetComponent<ProjectileController>();

            if (_assetBundle.LoadAsset<GameObject>("RobomandoBombGhost") != null)
                bombController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("RobomandoBombGhost");
            
            bombController.startSound = "";
            */
        }
        #endregion projectiles

    }
}
