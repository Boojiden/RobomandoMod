using RobomandoMod.Survivors.Robomando;
using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace RobomandoMod.Characters.Survivors.Robomando.Components
{
    public class BombImpactComponent : MonoBehaviour
    {
        public void OnCollisionEnter(Collision collision)
        {
            if(NetworkServer.active && collision.gameObject.layer == LayerIndex.world.intVal)
            {
                Quaternion rot = Quaternion.LookRotation(collision.contacts[0].normal);

                var point = collision.contacts[0].point;
                var dir = (transform.position - point) * 0.2f;

                point += dir;

                EffectManager.SpawnEffect(RobomandoAssets.bombHitWorldEffect, 
                    new EffectData { 
                        origin = point, 
                        rotation =  rot}, true);
            }
        }
    }
}
