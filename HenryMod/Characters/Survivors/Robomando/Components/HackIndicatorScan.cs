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

        private Color origColor = new Color(163, 255, 248);
        private Color overwireColor = new Color(255, 69, 69);

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
            var name = robo.skillLocator.special.skillDef.skillName;
            bool nameFlag1 = name.Equals("RobomandoHack");
            bool nameFlag2 = name.Equals("RobomandoOverwire");
            if (robo != null && (nameFlag1 || nameFlag2))
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
                            ind = new Indicator(robo.gameObject.transform.root.gameObject, nameFlag2 ? RobomandoAssets.hackIndicatorRed : RobomandoAssets.hackIndicator);
                            bool flag1 = driver.currentInteractable.TryGetComponent<ShopTerminalBehavior>(out var shop);
                            bool flag2 = driver.currentInteractable.TryGetComponent<DroneVendorTerminalBehavior>(out var droneShop);
                            if ((flag1 || flag2) && !Hack.IsPrinter(driver.currentInteractable))
                            {
                                GameObject pickupDisplay = flag1 ? shop.pickupDisplay.gameObject : droneShop.pickupDisplay.gameObject;
                                ind.targetTransform = pickupDisplay.transform;
                            }
                            else
                            {
                                ind.targetTransform = driver.currentInteractable.transform;
                            }
                            ind.active = true;
                            //SpriteRenderer renderer = ind.visualizerInstance.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
                            //renderer.color = origColor;
                            //if (nameFlag2)
                            //{
                            //    renderer.color = overwireColor;
                            //}
                            cachedInteractable = driver.currentInteractable;
                        }
                        
                    }
                    else
                    {
                        ClearIndicator();
                    }
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
                ind.active = false;
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
