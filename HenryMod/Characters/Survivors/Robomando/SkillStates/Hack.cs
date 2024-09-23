using EntityStates;
using R2API.Networking;
using R2API.Networking.Interfaces;
using RobomandoMod.Survivors.Robomando;
using RoR2;
using RoR2.Orbs;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Hack : BaseSkillState
    {
        public static float BaseDuration = 2.4122f;
        public static float soundDuration = 2f;
        private bool playedSound = false;
        public static GameObject fireFX = EntityStates.Commando.CommandoWeapon.FireLightsOut.effectPrefab;
        //RoR2/Base/Lightning/LightningStrikeImpact.prefab 
        public static GameObject impactFX = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Lightning/LightningStrikeImpact.prefab").WaitForCompletion();
        //delays for projectiles feel absolute ass so only do this if you know what you're doing, otherwise it's best to keep it at 0

        private bool animShouldPlay = false;
        private bool playedOnClient = false;
        private PurchaseInteraction pInter = null;
        private InteractionDriver IRobo = null;

        public override void OnEnter()
        {
            base.OnEnter();
            animShouldPlay = false;
            RoR2.InteractionDriver IDRobomando = null;
            if (gameObject.TryGetComponent<RoR2.InteractionDriver>(out IDRobomando))
            {
                IRobo = IDRobomando;
                if (isAuthority)
                {
                    GameObject interactable = IDRobomando.currentInteractable;
                    if (interactable)
                    {
                        RoR2.PurchaseInteraction pInteraction = null;
                        if (interactable.TryGetComponent<RoR2.PurchaseInteraction>(out pInteraction))
                        {
                            if (!pInteraction.isShrine && pInteraction.costType == CostTypeIndex.Money)
                            {
                                pInter = pInteraction;
                                Util.PlaySound("UnlockingVoice1", gameObject);
                                skillLocator.special.finalRechargeInterval = 10f;
                                animShouldPlay = true;
                            }
                        }
                        else
                        {
                            //RoR2.Chat.SendBroadcastChat(new RoR2.Chat.SimpleChatMessage() { baseToken = $"<style=cEvent><color=#307FFF>No Purchase Interaction Component</color></style>" });
                        }
                    }
                    else
                    {
                        //RoR2.Chat.SendBroadcastChat(new RoR2.Chat.SimpleChatMessage() { baseToken = $"<style=cEvent><color=#307FFF>No Current Interactable Object</color></style>" });
                    }
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(animShouldPlay && !playedOnClient)
            {
                PlayAnimation(4f);
                playedOnClient = true;
            }
            if (animShouldPlay && fixedAge > soundDuration && !playedSound) 
            {
                Util.PlaySound("Tazer", gameObject);
                playedSound = true;
                EffectManager.SpawnEffect(impactFX, new EffectData { origin = pInter.gameObject.transform.position }, true);
                EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FireRocket.effectPrefab, gameObject, "Muzzle", false);
                if (NetworkServer.active)
                {
                    pInter.onPurchase.Invoke(IRobo.interactor);
                    Log.Debug("Does it in server");
                }
                else
                {
                    new HackNetMessage(characterBody.netId, pInter.netId).Send(NetworkDestination.Server);
                    Log.Debug("Does it in client");
                }
            }
            if (animShouldPlay && fixedAge > BaseDuration)
            {
                outer.SetNextStateToMain();
            }
            else if(isAuthority && !animShouldPlay)
            {
                outer.SetNextStateToMain();
                skillLocator.special.finalRechargeInterval = 2f;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        public void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("FullBody, Override", "Hack", "ShootGun.playbackRate", 4f);
            }
        }
    }

    public class HackNetMessage : INetMessage
    {
        NetworkInstanceId RoboID;
        NetworkInstanceId DeviceID;
        public void Deserialize(NetworkReader reader)
        {
            RoboID = reader.ReadNetworkId();
            DeviceID = reader.ReadNetworkId();
        }

        public void OnReceived()
        {
            Log.Debug("Thing Recieved");
            if (NetworkServer.active)
            {
                Log.Debug("Thing Recieved by server");
                GameObject robo = NetworkServer.FindLocalObject(RoboID);
                GameObject device = NetworkServer.FindLocalObject(DeviceID);

                device.GetComponent<PurchaseInteraction>().onPurchase.Invoke(robo.GetComponent<InteractionDriver>().interactor);
            }
        }

        public void Serialize(NetworkWriter writer)
        {
            writer.Write(RoboID);
            writer.Write(DeviceID);
        }

        public HackNetMessage()
        {

        }

        public HackNetMessage(NetworkInstanceId roboID, NetworkInstanceId deviceID)
        {
            RoboID = roboID;
            DeviceID = deviceID;
        }
    }
}