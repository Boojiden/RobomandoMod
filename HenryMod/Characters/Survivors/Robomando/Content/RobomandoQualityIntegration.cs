using ItemQualities;
using R2API.Utils;
using RoR2;
using RoR2.Audio;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace RobomandoMod.Characters.Survivors.Robomando.Content
{
    public static class RobomandoQualityIntegration
    {
        //Taken from quality mod
        private static float UncommonQualityWeight = 0.7f;
        private static float RareQualityWeight = 0.2f;
        private static float EpicQualityWeight = 0.08f;
        private static float LegendaryQualityWeight = 0.02f;

        private static WeightedSelection<int> _qualitySelection = new WeightedSelection<int>();

        private static Type _costTypeDefClass = null;
        private static Type _dropTableClass = null;

        private static CostTypeIndex _whiteQuality;
        private static CostTypeIndex _greenQuality;
        private static CostTypeIndex _redQuality;
        private static CostTypeIndex _yellowQuality;

        private static List<CostTypeIndex> typeDefs = new List<CostTypeIndex>(4);
        private static Dictionary<CostTypeIndex, ItemTier> indexToTier = new Dictionary<CostTypeIndex, ItemTier>();

        private static MethodInfo _pickupInfoMethod = null;

        private static bool _loaded = false;
        public static void Init()
        {
            _qualitySelection.AddChoice((int)QualityTier.Uncommon, UncommonQualityWeight);
            _qualitySelection.AddChoice((int)QualityTier.Rare, RareQualityWeight);
            _qualitySelection.AddChoice((int)QualityTier.Epic, EpicQualityWeight);
            _qualitySelection.AddChoice((int)QualityTier.Legendary, LegendaryQualityWeight);

            var assembly = System.Reflection.Assembly.GetAssembly(typeof(ItemQualitiesPlugin));
            bool flag = Reflection.GetTypesSafe(assembly, out var types);
            foreach (Type type in types)
            {
                Debug.Log($"Reflection: type name {type.Name}");
                if (type.Name == "CustomCostTypeIndex")
                {
                    Debug.Log($"Reflection: {type.Name} found");
                    _costTypeDefClass = type;
                }
                else if (type.Name == "DropTableQualityHandler")
                {
                    Debug.Log($"Reflection: {type.Name} found");
                    _dropTableClass = type;
                }

                if(_costTypeDefClass != null && _dropTableClass != null)
                {
                    break;
                }
            }

            _pickupInfoMethod = Reflection.GetMethodCached(_dropTableClass, "GetCurrentPickupRollInfo", new Type[] {typeof(CharacterMaster) });
        } 

        private static void InitQualityTypes()
        {
            if (_costTypeDefClass != null)
            {
                _whiteQuality = Reflection.GetPropertyValue<CostTypeIndex>(_costTypeDefClass, "WhiteItemQuality");
                _greenQuality = Reflection.GetPropertyValue<CostTypeIndex>(_costTypeDefClass, "GreenItemQuality");
                _redQuality = Reflection.GetPropertyValue<CostTypeIndex>(_costTypeDefClass, "RedItemQuality");
                _yellowQuality = Reflection.GetPropertyValue<CostTypeIndex>(_costTypeDefClass, "BossItemQuality");

                if (_whiteQuality != CostTypeIndex.None)
                {
                    typeDefs.Add(_whiteQuality);
                    indexToTier.Add(_whiteQuality, ItemTier.Tier1);
                }
                if (_greenQuality != CostTypeIndex.None)
                {
                    typeDefs.Add(_greenQuality);
                    indexToTier.Add(_greenQuality, ItemTier.Tier2);
                }
                if (_redQuality != CostTypeIndex.None)
                {
                    typeDefs.Add(_redQuality);
                    indexToTier.Add(_redQuality, ItemTier.Tier3);
                }
                if (_yellowQuality != CostTypeIndex.None)
                {
                    typeDefs.Add(_yellowQuality);
                    indexToTier.Add(_yellowQuality, ItemTier.Boss);
                }

                Log.Debug($"Cost Types: {_whiteQuality} {_greenQuality} {_redQuality} {_yellowQuality}");
                Log.Debug($"Cost Type count: {typeDefs.Count}");
            }
        }
        public static bool IsQualityPrinter(GameObject device)
        {
            if(device.TryGetComponent<PurchaseInteraction>(out var dup))
            {
                if (!_loaded) 
                {
                    InitQualityTypes();
                    _loaded = true;
                }
                if (typeDefs.IndexOf(dup.costType) != -1)
                {
                    return true;
                }
            }
            return false;
        }

        public static PickupIndex OverwritePrinterIndex(PickupIndex orig, GameObject device, GameObject robo, Xoroshiro128Plus rng)
        {
            rng = new Xoroshiro128Plus(rng.nextUlong);
            CharacterBody body = robo ? robo.GetComponent<CharacterBody>() : null;
            CharacterMaster master = body ? body.master : null;
            QualityTier tier = (QualityTier)TryRerollQualityTier(master, rng);

            if (device.TryGetComponent<PurchaseInteraction>(out var dup))
            {
                if (indexToTier.ContainsKey(dup.costType))
                {
                    orig = PickupCatalog.FindScrapIndexForItemTier(indexToTier[dup.costType]);
                }
            }

            if (orig == PickupIndex.none)
            {
                orig = PickupCatalog.FindScrapIndexForItemTier(ItemTier.Tier1);
            }

            return QualityCatalog.GetPickupIndexOfQuality(orig, tier);
        }

        public static int TryRerollQualityTier(CharacterMaster roboMaster, Xoroshiro128Plus rng)
        {
            //Quality Item rolls are apparantly only affected by quality clovers, so this is why we're pulling this object.
            PickupRollInfo info = (PickupRollInfo)_pickupInfoMethod.Invoke(null, new object[] { roboMaster });
            int luck = info.Luck;
            int roll = _qualitySelection.Evaluate(rng.nextNormalizedFloat);
            if(luck > 0)
            {
                for(int i = 0; i < luck; i++)
                {
                    int newroll = _qualitySelection.Evaluate(rng.nextNormalizedFloat);
                    if (newroll > roll)
                    {
                        roll = newroll;
                    }
                }
            }
            return roll;
        }
    }
}
