using EntityStates;
using R2API.Networking;
using R2API.Networking.Interfaces;
using RobomandoMod.Characters.Survivors.Robomando.Components;
using RobomandoMod.Characters.Survivors.Robomando.Content;
using RoR2;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using static RobomandoMod.Survivors.Robomando.SkillStates.Hack;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Hack : BaseSkillState
    {
        public enum PrinterItemType
        {
            NONE,
            WHITE,
            GREEN,
            RED,
            YELLOW
        }
        public static float HackDuration = RobomandoStaticValues.hackTime;
        public static float soundDuration = 2.2f;

        public const float baseHackDuration = 3.33f;
        public const float baseSoundDuration = 2.2f;

        private bool playedSound = false;
        public static GameObject fireFX = RobomandoAssets.zapMuzzleFlashEffect;
        //RoR2/Base/Lightning/LightningStrikeImpact.prefab 
        public static GameObject impactFX = RobomandoAssets.hackEffect;
        public static GameObject printerDestroyFX = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/StickyBomb/BehemothVFX.prefab").WaitForCompletion();
        public static GameObject printerDestroyFX2 = Addressables.LoadAssetAsync<GameObject>("RoR2/Base/Toolbot/CryoCanisterExplosionPrimary.prefab").WaitForCompletion();
        public static event Action<GameObject, GameObject> onRobomandoHackGlobal;

        private PrinterItemType type = PrinterItemType.NONE;

        private bool isQualityPrinter = false;

        private bool animShouldPlay = false;
        private bool playedOnClient = false;
        private PurchaseInteraction pInter = null;
        private InteractionDriver IRobo = null;

        public float GetAttackSpeedDuration()
        {
            return HackDuration / attackSpeedStat;
        }

        public float GetAnimSpeedHack()
        {
            return GetAttackSpeedDuration() / baseHackDuration;
        }

        public float GetSoundSpeed()
        {
            return soundDuration * GetAnimSpeedHack();
        }

        public static bool CanHack(GameObject device)
        {
            RoR2.PurchaseInteraction pInteraction = device.GetComponentInChildren<RoR2.PurchaseInteraction>();
            if (pInteraction != null)
            {
                //Debug.Log(pInteraction.displayNameToken);
                if (!pInteraction.isShrine && pInteraction.costType == CostTypeIndex.Money)
                {
                    if (pInteraction.displayNameToken.Equals("GOLDTOTEM_NAME"))
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    return IsPrinter(device);
                }
            }
            return false;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            if (isAuthority)
            {
                animShouldPlay = false;
            }
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
                        if (CanHack(interactable))
                        {
                            pInteraction = interactable.GetComponent<RoR2.PurchaseInteraction>();

                            if (RobomandoPlugin.qualityInstalled)
                            {
                                if (RobomandoQualityIntegration.IsQualityPrinter(interactable))
                                {
                                    isQualityPrinter = true;
                                }
                            }

                            SetPrinterItemType(pInteraction);
                            pInter = pInteraction;
                            RobomandoSurvivor.TryPlayVoiceLine("UnlockingVoice1", gameObject);
                            //Util.PlaySound("UnlockingVoice1", gameObject);
                            skillLocator.special.finalRechargeInterval = RobomandoStaticValues.successfullHackCooldown;
                            animShouldPlay = true;
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

        public void SetPrinterItemType(PurchaseInteraction pInteraction)
        {

            switch (pInteraction.costType)
            {
                case CostTypeIndex.WhiteItem:
                    type = PrinterItemType.WHITE;
                    break;
                case CostTypeIndex.GreenItem:
                    type = PrinterItemType.GREEN;
                    break;
                case CostTypeIndex.RedItem:
                    type = PrinterItemType.RED;
                    break;
                case CostTypeIndex.BossItem:
                    type = PrinterItemType.YELLOW;
                    break;
            }
            /*
            if (pInteraction.displayNameToken.Equals("DUPLICATOR_NAME"))
            {
                if (pInteraction.costType == CostTypeIndex.WhiteItem)
                {
                    
                }
                else
                {
                    type = PrinterItemType.GREEN;
                }
            }
            else if (pInteraction.displayNameToken.Equals("DUPLICATOR_MILITARY_NAME"))
            {
                type = PrinterItemType.RED;
            }
            else if (pInteraction.displayNameToken.Equals("DUPLICATOR_WILD_NAME"))
            {
                type = PrinterItemType.YELLOW;
            }
            */
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if(animShouldPlay && !playedOnClient)
            {
                PlayAnimation(GetAnimSpeedHack());
                playedOnClient = true;
            }
            if (animShouldPlay && fixedAge > GetSoundSpeed() && !playedSound && isAuthority)
            { 
                var message = new HackNetMessage(characterBody.netId, pInter.netId, type, isQualityPrinter, false);
                message = ModifyHackMessage(message, characterBody.master);
                if (NetworkServer.active)
                {
                    HackDevice(characterBody.gameObject, pInter.gameObject, message.type, message.isQualityPrinter, message.procScepter);
                    Log.Debug("Hack Request on Server");
                }
                else
                {
                    message.Send(NetworkDestination.Server);
                    Log.Debug("Hack Request on Client");
                }
                //Util.PlaySound("Play_Robo_Tazer", gameObject);
                Util.PlaySound("Play_Robo_Hack", gameObject);
                playedSound = true;
                EffectManager.SpawnEffect(ModifyHackEffect(message), new EffectData { origin = pInter.gameObject.transform.position }, true);
                EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FireRocket.effectPrefab, gameObject, "Muzzle", false);
            }
            if (animShouldPlay && fixedAge > GetAttackSpeedDuration())
            {
                outer.SetNextStateToMain();
            }
            else if(isAuthority && !animShouldPlay)
            {
                outer.SetNextStateToMain();
                skillLocator.special.finalRechargeInterval = RobomandoStaticValues.unsuccessfullHackCooldown;
            }
        }

        public virtual HackNetMessage ModifyHackMessage(HackNetMessage message, CharacterMaster master)
        {
            return message;
        }

        public virtual GameObject ModifyHackEffect(HackNetMessage message)
        {
            return impactFX;
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }

        public void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                GetModelAnimator().SetFloat("Hack.playbackRate", GetAnimSpeedHack());
                PlayAnimation("FullBody, Override", "Hack", "Hack.playbackRate", GetAttackSpeedDuration());
            }
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            writer.Write(animShouldPlay);
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            animShouldPlay = reader.ReadBoolean();
        }
        public static void HackDevice(GameObject robo, GameObject device, PrinterItemType type, bool isQuality, bool procScepter)
        {
            
            var pInter = device.GetComponent<PurchaseInteraction>();
            Log.Debug($"Hacked {pInter.displayNameToken}");
            int originalPrice = pInter.cost;
            pInter.cost = 0;
            onRobomandoHackGlobal?.Invoke(robo, device);
            if (type == PrinterItemType.NONE && !isQuality)
            {
                if (procScepter)
                {
                    PreInteractionUpgrade(device);
                    pInter.onDetailedPurchaseServer.AddListener(UpgradeInteractableOutput);
                }
                robo.GetComponent<InteractionDriver>().interactor.CallCmdInteract(device);
                pInter.cost = originalPrice;
            }
            else
            {
                PickupIndex pickupIndex = PickupIndex.none;
                switch (type)
                {
                    case PrinterItemType.NONE:
                        break;
                    case PrinterItemType.WHITE:
                        pickupIndex = PickupCatalog.FindPickupIndex(RoR2Content.Items.ScrapWhite.itemIndex);
                        break;
                    case PrinterItemType.GREEN:
                        pickupIndex = PickupCatalog.FindPickupIndex(RoR2Content.Items.ScrapGreen.itemIndex);
                        break;
                    case PrinterItemType.RED:
                        pickupIndex = PickupCatalog.FindPickupIndex(RoR2Content.Items.ScrapRed.itemIndex);
                        break;
                    case PrinterItemType.YELLOW:
                        pickupIndex = PickupCatalog.FindPickupIndex(RoR2Content.Items.ScrapYellow.itemIndex);
                        break;
                }
                if (isQuality)
                {
                    pickupIndex = RobomandoQualityIntegration.OverwritePrinterIndex(pickupIndex, device, robo, Run.instance.treasureRng);
                }
                Vector3 spawnPos = Vector3.zero;
                var ShopTerminal = device.GetComponent<ShopTerminalBehavior>();
                Transform pivot = ShopTerminal ? ShopTerminal.dropTransform : null;
                if(pivot != null)
                {
                    spawnPos = pivot.position;
                }
                else
                {
                    Debug.Log("pivot is null");
                    spawnPos = device.transform.position;
                }
                UniquePickup pickupInst = new UniquePickup(pickupIndex);
                NetworkServer.DestroyObject(device);
                Destroy(device);
                PickupDropletController.CreatePickupDroplet(pickupInst, spawnPos, device.transform.rotation * new Vector3(0, 15, 6), false, false);
                if (procScepter)
                {
                    PickupDropletController.CreatePickupDroplet(pickupInst, spawnPos, device.transform.rotation * new Vector3(0, 15, 6), false, false);
                }

                EffectManager.SpawnEffect(printerDestroyFX, new EffectData { origin = spawnPos }, true);
                EffectManager.SpawnEffect(printerDestroyFX2, new EffectData { origin = spawnPos }, true);


                //AkSoundEngine.PostEvent("Play_item_proc_behemoth", pInter.gameObject);
            }
        }

        private static void UpgradeInteractableOutput(CostTypeDef.PayCostContext context, CostTypeDef.PayCostResults results)
        {
            var device = context.purchasedObject;
            if(device.TryGetComponent<ChestBehavior>(out ChestBehavior chest))
            {
                chest.dropCount++;
            }
            if (device.TryGetComponent<RouletteChestController>(out RouletteChestController rChest))
            {
                rChest.dropCount++;
            }
            if (device.TryGetComponent<PickupDistributorBehavior>(out PickupDistributorBehavior tShop))
            {
                tShop.baseDropAmount += 5;
            }
        }

        private static void PreInteractionUpgrade(GameObject device)
        {
            if (device.TryGetComponent<SummonMasterBehavior>(out SummonMasterBehavior summon))
            {
                if (summon.droneUpgradeCount == 0)
                {
                    summon.droneUpgradeCount = 1;
                }
            }
            if (device.TryGetComponent<ShopTerminalBehavior>(out ShopTerminalBehavior shop))
            {
                shop.dropAmount++;
            }
            if (device.TryGetComponent<RadiotowerTerminal>(out RadiotowerTerminal radio))
            {
                NetworkServer.Spawn(GameObject.Instantiate(LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/ChestScanner"), device.transform.position, Quaternion.identity));
            }
            if (device.TryGetComponent<VendingMachineBehavior>(out VendingMachineBehavior vending))
            {
                vending.healFraction = 0.5f; //25% increase
            }
        }

        public static bool IsPrinter(GameObject device)
        {
            try
            {
                if (device.GetComponent<EntityStateMachine>().mainStateType.typeName == "EntityStates.Duplicator.Duplicating")
                {
                    return true;
                }
                else if (RobomandoPlugin.qualityInstalled)
                {
                    if (RobomandoQualityIntegration.IsQualityPrinter(device))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                return false;
                //Debug.LogError(e.StackTrace);
                //Debug.Log("Cant cast to EntityStateMachine");
            }

            return false;
        }
    }

    

    public class HackNetMessage : INetMessage
    {
        public NetworkInstanceId RoboID;
        public NetworkInstanceId DeviceID;
        public PrinterItemType type;
        public bool isQualityPrinter;
        public bool procScepter;

        public void Deserialize(NetworkReader reader)
        {
            RoboID = reader.ReadNetworkId();
            DeviceID = reader.ReadNetworkId();
            type = (PrinterItemType)reader.ReadByte();
            isQualityPrinter = reader.ReadBoolean();
        }

        public void OnReceived()
        {
            Log.Debug("Thing Recieved");
            if (NetworkServer.active)
            {
                Log.Debug("Thing Recieved by server");
                GameObject robo = NetworkServer.FindLocalObject(RoboID);
                GameObject device = NetworkServer.FindLocalObject(DeviceID);


                Hack.HackDevice(robo, device, type, isQualityPrinter, procScepter);

                //device.GetComponent<PurchaseInteraction>().onPurchase.Invoke(robo.GetComponent<InteractionDriver>().interactor);
            }
        }

        public void Serialize(NetworkWriter writer)
        {
            writer.Write(RoboID);
            writer.Write(DeviceID);
            writer.Write((byte)type);
            writer.Write(isQualityPrinter);
            writer.Write(procScepter);
        }

        public HackNetMessage()
        {

        }

        public HackNetMessage(NetworkInstanceId roboID, NetworkInstanceId deviceID, PrinterItemType printerType = PrinterItemType.NONE, bool qPrinter = false, bool pScepter = false)
        {
            RoboID = roboID;
            DeviceID = deviceID;
            type = printerType;
            isQualityPrinter = qPrinter;
            procScepter = pScepter;
        }
    }
}