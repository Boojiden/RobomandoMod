using RoR2;
using System;
using EmotesAPI;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using RobomandoMod.Survivors.Robomando;

namespace RobomandoMod.Characters.Survivors.Robomando.Content
{
    public class RobomandoAddEmoteSkeleton
    {
        public static bool emotesSetup = false;
        public static void AddSkeleton(AssetBundle assetBundle)
        {
            Log.Debug("Attempting to add emote skeleton");
            On.RoR2.SurvivorCatalog.Init += (orig) =>
            {
                orig();

                if (!emotesSetup)
                {
                    emotesSetup = true;
                    foreach (var item in SurvivorCatalog.allSurvivorDefs)
                    {
                        if (item.bodyPrefab.name == "RobomandoBody")
                        {
                            var skele = assetBundle.LoadAsset<GameObject>("robomandoEmoteSkeletonFinal");
                            CustomEmotesAPI.ImportArmature(item.bodyPrefab, skele);
                            CustomEmotesAPI.CreateNameTokenSpritePair("RAT_ROBOMANDO_NAME", assetBundle.LoadAsset<Sprite>("texEmoteIcon"));
                            Debug.Log("Setup Emote Skeleton");

                            //skele.GetComponentInChildren<BoneMapper>().scale = 1.5f;
                        }
                    }
                        
                }
            };
        }
    }
}
