using RoR2;
using RobomandoMod.Survivors.Robomando;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RobomandoMod.Survivors.Robomando.SkillStates;
using UnityEngine.UI;

namespace RobomandoMod.Characters.Survivors.Robomando.Components
{
    public class HackIndicatorScan : MonoBehaviour
    {
        private CharacterBody robo;

        private Dictionary<GameObject, HackIndicator> indicators;
        private GameObject cachedInteractable = null;
        private Indicator ind;
        private InteractionDriver driver;

        public void Start()
        {
            Debug.Log("HackIndicator component present");
            robo = this.GetComponentInChildren<CharacterBody>();
            indicators = new Dictionary<GameObject, HackIndicator>();
            driver = this.GetComponentInChildren<InteractionDriver>();
        }
        public void Init()
        {
            robo = this.GetComponentInChildren<CharacterBody>();
            
        }

        public void FixedUpdate()
        {
            //Log.Debug("FixedUpdate");
            if(robo != null && robo.skillLocator.special.skillDef.skillName.Equals("RobomandoHack"))
            {
                //Log.Debug("Has Hack");
                if (robo.skillLocator.special.IsReady())
                {
                    if(driver.currentInteractable && Hack.CanHack(driver.currentInteractable))
                    {
                        //Debug.Log($"Can Hack Current Device {driver.currentInteractable.GetComponent<PurchaseInteraction>().displayNameToken}");
                        if(driver.currentInteractable != cachedInteractable)
                        {
                            if (ind != null)
                            {
                                ClearIndicator();
                            }
                            //Debug.Log("Creating New Indicator");
                            //TODO: Multishops put the indicator below where they should
                            //GetComponent<EntityStateMachine>().mainStateType.typeName == "EntityStates.Duplicator.Duplicating"
                            //GetComponent<PurchaseInteraction>().displayNameToken.Equals("MULTISHOP_TERMINAL_NAME")
                            ind = new Indicator(robo.gameObject.transform.root.gameObject, RobomandoAssets.hackIndicator);
                            if (driver.currentInteractable.TryGetComponent<ShopTerminalBehavior>(out var shop) && !Hack.IsPrinter(driver.currentInteractable))
                            {
                                GameObject pickupDisplay = driver.currentInteractable.transform.GetComponentInChildren<PickupDisplay>().gameObject;
                                ind.targetTransform = pickupDisplay.transform;
                            }
                            else
                            {
                                ind.targetTransform = driver.currentInteractable.transform;
                            }
                            ind.active = true;
                            cachedInteractable = driver.currentInteractable;
                        }
                        
                    }
                    else
                    {
                        ClearIndicator();
                    }
                    /*
                    Log.Debug("Hack is ready");
                    var hits = Physics.SphereCastAll(robo.gameObject.transform.root.position, searchRadius, robo.gameObject.transform.root.forward, searchRadius, LayerIndex.CommonMasks.interactable, QueryTriggerInteraction.Collide);
                    Log.Debug("Cast is fine");
                    foreach(RaycastHit hit in hits)
                    {
                        var entity = hit.collider.gameObject.transform.root.GetComponent<EntityLocator>().entity;
                        if(entity != null)
                        {
                            Log.Debug($"CircleCast hit {entity}");
                            if (Hack.CanHack(entity))
                            {
                                Log.Debug($"{entity}Can be Hacked");
                                HackIndicator indicator;
                                if (!indicators.TryGetValue(hit.collider.gameObject.transform.root.gameObject, out indicator))
                                {
                                    Log.Debug($"Made HackIndicator");
                                    indicator = new HackIndicator(robo.gameObject.transform.root.gameObject, RobomandoAssets.hackIndicator);
                                    indicator.targetTransform = robo.gameObject.transform.root;
                                    indicator.active = true;
                                }
                                indicators[hit.collider.gameObject.transform.root.gameObject] = indicator;
                            }
                        }
                    }
                    Log.Debug("No Items Found");
                    foreach(var indicator in indicators)
                    {
                        if((indicator.Value.targetTransform.position - robo.gameObject.transform.root.position).magnitude > searchRadius)
                        {
                            Log.Debug($"Indicator out of range, removing");
                            RemoveIndicator(indicator.Key);
                        }
                    }
                    */
                }
                else
                {
                    ClearIndicator();
                    //ClearIndicators();
                }
            }
            else
            {
                if (!robo)
                {
                    //Debug.Log("No CharacterBody Somehow");
                    robo = this.GetComponentInChildren<CharacterBody>();
                }
                if (!robo.skillLocator.special.skillDef.skillName.Equals("RobomandoHack"))
                {
                    //Debug.Log("No Hack :(");
                }
            }
        }

        public void ClearIndicator()
        {
            if(ind != null)
            {
                ind.DestroyVisualizer();
                ind = null;
            }
            cachedInteractable = null;
        }

        public void RemoveIndicator(GameObject device) 
        {
            var indicator = indicators[device];
            indicator.active = false;
            indicators.Remove(device);
        }

        public void ClearIndicators()
        {
            foreach(var indicator in indicators)
            {
                indicator.Value.active = false;
                indicators.Remove(indicator.Key);
            }
        }

        private class HackIndicator : Indicator
        {

            public override void UpdateVisualizer()
            {
                base.UpdateVisualizer();

            }
            public HackIndicator(GameObject owner, GameObject visualizerPrefab) : base(owner, visualizerPrefab)
            {
                
            }
        }
    }

    
}
