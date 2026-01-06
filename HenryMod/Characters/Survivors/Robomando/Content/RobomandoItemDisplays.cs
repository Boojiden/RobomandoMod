using AncientScepter;
using RobomandoMod.Characters.Survivors.Robomando.Content;
using RobomandoMod.Modules;
using RobomandoMod.Modules.Characters;
using RoR2;
using System.Collections.Generic;
using UnityEngine;

/* for custom copy format in keb's helper
{childName},
                    {localPos}, 
                    {localAngles},
                    {localScale})
*/

namespace RobomandoMod.Survivors.Robomando
{
    public class RobomandoItemDisplays : ItemDisplaysBase
    {
        protected override void SetItemDisplayRules(List<ItemDisplayRuleSet.KeyAssetRuleGroup> itemDisplayRules)
        {
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AlienHead"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAlienHead"),
                    "UpperLeg_R",
                    new Vector3(0.02298F, -0.0009F, 0.07407F),
                    new Vector3(72.82494F, 168.64F, 330.8979F),
                    new Vector3(0.27648F, 0.27648F, 0.27648F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorPlate"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                    "UpperArm_L",
                    new Vector3(0.01059F, 0.10382F, 0.07175F),
                    new Vector3(75.74503F, 133.282F, 328.2955F),
                    new Vector3(0.22946F, 0.22946F, 0.22946F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ArmorReductionOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarhammer"),
                    "Hand_L",
                    new Vector3(-0.21753F, 0.07681F, -0.01111F),
                    new Vector3(2.36079F, 270.3404F, 98.20595F),
                    new Vector3(0.0916F, 0.0916F, 0.0916F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedAndMoveSpeed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCoffee"),
                    "Pelvis",
                    new Vector3(0.00001F, 0.13226F, -0.19031F),
                    new Vector3(323.3869F, 180F, 98.10122F),
                    new Vector3(0.13253F, 0.13253F, 0.13253F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                    "Head",
                    new Vector3(0.11466F, 0.26658F, -0.00585F),
                    new Vector3(333.446F, 272.1451F, 0.00001F),
                    new Vector3(0.53973F, 0.53973F, 0.53973F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AutoCastEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFossil"),
                   "Chest",
                    new Vector3(0.37847F, 0.2039F, -0.10632F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.40601F, 0.40601F, 0.40601F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bandolier"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBandolier"),
                    "Pelvis",
                    new Vector3(0.00058F, 0.12706F, 0.01744F),
                    new Vector3(85.76807F, 125.5116F, 223.2266F),
                    new Vector3(0.41921F, 0.51513F, 0.51513F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrooch"),
                    "Chest",
                    new Vector3(-0.15512F, -0.02766F, -0.00015F),
                    new Vector3(77.81039F, 90.65997F, 180.6672F),
                    new Vector3(0.30442F, 0.30442F, 0.30442F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnOverHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAegis"),
                    "Hand_L",
                    new Vector3(-0.00001F, 0.14539F, 0.02619F),
                    new Vector3(283.8807F, 180F, 180F),
                    new Vector3(0.11552F, 0.11552F, 0.11552F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Bear"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBear"),
                    "Pelvis",
                    new Vector3(-0.02789F, 0.11062F, -0.20701F),
                    new Vector3(24.10534F, 339.0573F, 311.6451F),
                    new Vector3(-0.11326F, -0.11326F, -0.11326F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BearVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBearVoid"),
                    "Pelvis",
                    new Vector3(-0.02789F, 0.11062F, -0.20701F),
                    new Vector3(24.10534F, 339.0573F, 311.6451F),
                    new Vector3(-0.11326F, -0.11326F, -0.11326F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BeetleGland"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                    "Chest",
                    new Vector3(-0.16948F, 0.18906F, 0.20607F),
                    new Vector3(0F, 217.0119F, 0F),
                    new Vector3(0.03445F, 0.03445F, 0.03445F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Behemoth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBehemoth"),
                    "Chest",
                    new Vector3(0.4476F, 0.1684F, 0F),
                    new Vector3(57.42241F, 0F, 0F),
                    new Vector3(0.08489F, 0.08489F, 0.08489F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTip"),
                    "Head",
                    new Vector3(-0.00004F, 0.28188F, -0.18221F),
                    new Vector3(39.68958F, 0F, 0F),
                    new Vector3(0.26246F, 0.26246F, 0.26246F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitAndExplode"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                    "Pelvis",
                    new Vector3(-0.01924F, 0.16327F, 0.17768F),
                    new Vector3(327.9645F, 349.0708F, 200.0031F),
                    new Vector3(0.0308F, 0.0308F, 0.0308F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BleedOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTriTipVoid"),
                    "Head",
                    new Vector3(-0.00004F, 0.28188F, -0.18221F),
                    new Vector3(39.68958F, 0F, 0F),
                    new Vector3(0.26246F, 0.26246F, 0.26246F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BonusGoldPackOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTome"),
                    "Chest",
                    new Vector3(0.38706F, -0.00002F, 0.00121F),
                    new Vector3(0F, 89.19973F, 0F),
                    new Vector3(0.08809F, 0.08809F, 0.08809F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAPRound"),
                    "UpperArm_L",
                    new Vector3(0.06569F, 0.14611F, 0.05848F),
                    new Vector3(280.38F, 180F, 180F),
                    new Vector3(0.51096F, 0.51096F, 0.51096F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BounceNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHook"),
                    "Chest",
                    new Vector3(0.37708F, 0.18079F, -0.13194F),
                    new Vector3(0F, 271.8644F, 0F),
                    new Vector3(0.4099F, 0.4099F, 0.4099F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkulele"),
                    "Chest",
                    new Vector3(0.38184F, 0.10581F, -0.04645F),
                    new Vector3(-0.00001F, 89.21347F, 42.38668F),
                    new Vector3(0.46474F, 0.46474F, 0.46474F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ChainLightningVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayUkuleleVoid"),
                    "Chest",
                    new Vector3(0.38184F, 0.10581F, -0.04645F),
                    new Vector3(-0.00001F, 89.21347F, 42.38668F),
                    new Vector3(0.46474F, 0.46474F, 0.46474F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Clover"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayClover"),
                    "Head",
                    new Vector3(0.13716F, 0.25095F, 0.08047F),
                    new Vector3(46.06691F, 0F, 305.8102F),
                    new Vector3(0.38918F, 0.38918F, 0.38918F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CloverVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCloverVoid"),
                    "Head",
                    new Vector3(0.13716F, 0.25095F, 0.08047F),
                    new Vector3(46.06691F, 0F, 305.8102F),
                    new Vector3(0.38918F, 0.38918F, 0.38918F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CooldownOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkull"),
                    "Chest",
                    new Vector3(-0.18233F, 0.1925F, -0.0009F),
                    new Vector3(284.8203F, 89.71538F, 180.0001F),
                    new Vector3(0.0656F, 0.0656F, 0.0656F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserSight"),
                    "Gun",
                    new Vector3(0.00974F, 0.23182F, 0.13929F),
                    new Vector3(0.00001F, 268.2265F, 266.6529F),
                    new Vector3(0.27075F, 0.27075F, 0.27075F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlasses"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlasses"),
                    "Head",
                    new Vector3(-0.1762F, 0.14895F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.42183F, 0.36843F, 0.36843F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritGlassesVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlassesVoid"),
                    "Head",
                    new Vector3(-0.1762F, 0.14895F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.42183F, 0.36843F, 0.36843F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Crowbar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCrowbar"),
                    "Chest",
                    new Vector3(0.38428F, 0.13293F, 0.00036F),
                    new Vector3(44.33336F, 2.70468F, 3.90637F),
                    new Vector3(0.37794F, 0.37794F, 0.37794F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Dagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDagger"),
                    "Chest",
                    new Vector3(0.27819F, 0.27178F, 0.10187F),
                    new Vector3(314.6472F, 333.8952F, 309.9166F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathMark"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathMark"),
                    "Hand_L",
                    new Vector3(-0.00237F, 0.0406F, 0.03835F),
                    new Vector3(71.62965F, 185.6784F, 5.98111F),
                    new Vector3(0.02255F, 0.02255F, 0.02255F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElementalRingVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVoidRing"),
                    "Hand_R",
                    new Vector3(0F, 0.01545F, 0F),
                    new Vector3(90F, 0F, 0F),
                    new Vector3(0.15576F, 0.15576F, 0.15576F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EmpowerAlways"],
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Head",
                    new Vector3(0.00414F, 0.04125F, -0.02292F),
                    new Vector3(0F, 180F, 0F),
                    new Vector3(2F, 1F, 2F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(-0.01116F, 0.18729F, -0.00091F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.18409F, 1.18409F, 1.18409F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSun"],
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.Head),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHeadNeck"),
                    "Head",
                    new Vector3(0.00414F, 0.04125F, -0.02292F),
                    new Vector3(0F, 180F, 0F),
                    new Vector3(2F, 1F, 2F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySunHead"),
                    "Head",
                    new Vector3(-0.01116F, 0.18729F, -0.00091F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1.18409F, 1.18409F, 1.18409F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EnergizedOnEquipmentUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarHorn"),
                    "Pelvis",
                    new Vector3(0.02622F, 0.17655F, -0.10024F),
                    new Vector3(88.86168F, 0F, 0F),
                    new Vector3(0.29464F, 0.29464F, 0.29464F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBattery"),
                    "Chest",
                    new Vector3(0.16491F, 0.06534F, -0.21143F),
                    new Vector3(271.1395F, 0F, 0F),
                    new Vector3(0.16372F, 0.16372F, 0.16372F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EquipmentMagazineVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFuelCellVoid"),
                    "Chest",
                    new Vector3(0.16491F, 0.06534F, -0.21143F),
                    new Vector3(5.39821F, 197.1092F, 188.422F),
                    new Vector3(0.16372F, 0.16372F, 0.16372F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExecuteLowHealthElite"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGuillotine"),
                    "Chest",
                    new Vector3(0.38026F, 0.17233F, -0.08967F),
                    new Vector3(275.1825F, 282.0439F, 347.6345F),
                    new Vector3(0.11498F, 0.11498F, 0.11498F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeath"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                    "Pelvis",
                    new Vector3(0.07547F, 0.1578F, -0.17788F),
                    new Vector3(0.10756F, 180F, 180F),
                    new Vector3(0.03485F, 0.03485F, 0.03485F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExplodeOnDeathVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWillowWispVoid"),
                    "Pelvis",
                    new Vector3(0.07547F, 0.1578F, -0.17788F),
                    new Vector3(0.10756F, 180F, 180F),
                    new Vector3(0.03485F, 0.03485F, 0.03485F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLife"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippo"),
                    "Pelvis",
                    new Vector3(-0.06865F, 0.13123F, 0.15381F),
                    new Vector3(0F, 0F, 185.1382F),
                    new Vector3(0.10479F, 0.10479F, 0.10479F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraLifeVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHippoVoid"),
                    "Pelvis",
                    new Vector3(-0.06865F, 0.13123F, 0.15381F),
                    new Vector3(0F, 0F, 185.1382F),
                    new Vector3(0.10479F, 0.10479F, 0.10479F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FallBoots"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "LowerLeg_L",
                    new Vector3(-0.02249F, 0.11781F, -0.00079F),
                    new Vector3(0F, 87.98477F, 180F),
                    new Vector3(0.21425F, 0.21425F, 0.30961F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravBoots"),
                    "LowerLeg_R",
                    new Vector3(-0.02264F, 0.11607F, -0.00171F),
                    new Vector3(-0.00001F, 85.67813F, 180F),
                    new Vector3(0.21425F, 0.21425F, 0.30961F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Feather"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFeather"),
                    "Chest",
                    new Vector3(0.05638F, 0.10219F, -0.17488F),
                    new Vector3(297.4346F, 301.0918F, 6.78463F),
                    new Vector3(0.03228F, 0.03228F, 0.03228F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireRing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireRing"),
                    "Hand_R",
                    new Vector3(-0.00117F, 0.02436F, -0.00026F),
                    new Vector3(275.6162F, 96.23536F, 263.7348F),
                    new Vector3(0.19824F, 0.19824F, 0.19824F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireballsOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                    "Head",
                    new Vector3(-0.2258F, 0.10222F, -0.0155F),
                    new Vector3(0F, 266.0727F, 0F),
                    new Vector3(0.02387F, 0.02387F, 0.02387F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Firework"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFirework"),
                    "Chest",
                    new Vector3(0.25401F, 0.42653F, 0.16305F),
                    new Vector3(277.3063F, 0F, 0F),
                    new Vector3(0.2214F, 0.2214F, 0.2214F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FlatHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                    "Chest",
                    new Vector3(0.22578F, 0.27318F, 0.17616F),
                    new Vector3(303.9393F, 0F, 0F),
                    new Vector3(0.08818F, 0.08818F, 0.08818F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FocusConvergence"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                    "Base",
                    new Vector3(0.53217F, 0.10342F, -0.6504F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.1F, 0.1F, 0.1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FragileDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelicateWatch"),
                    "LowerArm_L",
                    new Vector3(0F, 0.14154F, 0.0108F),
                    new Vector3(89.74056F, 0F, 0F),
                    new Vector3(0.65123F, 0.99608F, 0.65123F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FreeChest"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShippingRequestForm"),
                    "Chest",
                    new Vector3(0.2715F, 0.02682F, -0.22799F),
                    new Vector3(88.92827F, 162.4323F, 342.4408F),
                    new Vector3(0.34588F, 0.34588F, 0.34588F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GhostOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMask"),
                    "Head",
                    new Vector3(-0.06985F, 0.25693F, 0.00218F),
                    new Vector3(307.4319F, 269.3374F, -0.00001F),
                    new Vector3(0.58838F, 0.58838F, 0.58838F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                    "Head",
                    new Vector3(0.00916F, 0.21521F, 0.00043F),
                    new Vector3(0F, 267.3281F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldOnHurt"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRollOfPennies"),
                    "Pelvis",
                    new Vector3(0.06008F, 0.09877F, -0.17844F),
                    new Vector3(0F, 0F, 92.40177F),
                    new Vector3(0.37157F, 0.37157F, 0.37157F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfAttackSpeedHalfCooldowns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderNature"),
                    "Chest",
                    new Vector3(0.00134F, 0.22721F, -0.26897F),
                    new Vector3(0F, 270.556F, 0F),
                    new Vector3(0.55643F, 0.55643F, 0.75432F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HalfSpeedDoubleHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarShoulderStone"),
                    "Chest",
                    new Vector3(0.01142F, 0.26959F, 0.28213F),
                    new Vector3(1.34205F, 88.88927F, 326.5056F),
                    new Vector3(0.4709F, 0.4709F, 0.4709F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HeadHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySkullcrown"),
                    "Pelvis",
                    new Vector3(0.00724F, 0.16292F, 0.00088F),
                    new Vector3(2.49003F, 96.69559F, 180.1723F),
                    new Vector3(0.45114F, 0.09546F, 0.1635F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealingPotion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHealingPotion"),
                    "Pelvis",
                    new Vector3(0.04288F, 0.07119F, 0.20421F),
                    new Vector3(0F, 0F, 255.0073F),
                    new Vector3(0.0415F, 0.0415F, 0.0415F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealOnCrit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScythe"),
                    "Chest",
                    new Vector3(0.17605F, 0.10208F, -0.22209F),
                    new Vector3(270.8736F, 85.32185F, 189.8011F),
                    new Vector3(0.11901F, 0.11901F, 0.11901F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["HealWhileSafe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySnail"),
                    "Chest",
                    new Vector3(-0.10708F, 0.20542F, -0.18892F),
                    new Vector3(326.1525F, 0F, 26.4183F),
                    new Vector3(0.04875F, 0.04875F, 0.04875F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Hoof"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayHoof"),
                    "LowerLeg_R",
                    new Vector3(0.00209F, 0.09807F, 0.00176F),
                    new Vector3(88.23486F, 345.7742F, 83.50031F),
                    new Vector3(0.07114F, 0.09743F, 0.046F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightCalf)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IceRing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIceRing"),
                    "Hand_L",
                    new Vector3(0F, 0.0295F, 0.00298F),
                    new Vector3(275.7753F, 0F, 0F),
                    new Vector3(0.21545F, 0.21545F, 0.21545F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Icicle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                    "Base",
                    new Vector3(0.33846F, 0F, -0.70498F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IgniteOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasoline"),
                    "Chest",
                    new Vector3(0.38702F, -0.04307F, -0.15307F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.37014F, 0.37014F, 0.37014F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ImmuneToDebuff"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRainCoatBelt"),
                    "Pelvis",
                    new Vector3(0F, 0.10828F, -0.00213F),
                    new Vector3(1.12487F, 180F, 180F),
                    new Vector3(1F, 0.58036F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreaseHealing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(-0.00001F, 0.17936F, 0.11094F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.28113F, 0.28113F, 0.28113F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAntler"),
                    "Head",
                    new Vector3(0.02319F, 0.17325F, -0.12699F),
                    new Vector3(0F, 169.6479F, 0F),
                    new Vector3(0.28113F, 0.28113F, 0.28113F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Incubator"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAncestralIncubator"),
                    "Chest",
                    new Vector3(-0.09692F, 0.07947F, 0.09316F),
                    new Vector3(345.4345F, 27.53402F, 115.7528F),
                    new Vector3(0.02469F, 0.02469F, 0.02469F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Infusion"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInfusion"),
                    "UpperArm_R",
                    new Vector3(0.00086F, 0.09135F, -0.06028F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.71111F, 0.71111F, 0.71111F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["JumpBoost"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaxBird"),
                    "Chest",
                    new Vector3(0.05885F, -0.26888F, 0.18969F),
                    new Vector3(0F, 289.1986F, 0F),
                    new Vector3(0.81696F, 0.81696F, 0.81696F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["KillEliteFrenzy"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                    "Chest",
                    new Vector3(-0.00001F, 0.34475F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.29762F, 0.29762F, 0.29762F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Knurl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnurl"),
                    "Chest",
                    new Vector3(-0.14633F, 0.14819F, -0.19558F),
                    new Vector3(273.1141F, 0.00016F, 150.384F),
                    new Vector3(0.06184F, 0.06184F, 0.06184F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LaserTurbine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                    "Chest",
                    new Vector3(0.05797F, 0.27054F, 0.28215F),
                    new Vector3(275.205F, 87.41347F, 92.65015F),
                    new Vector3(0.27603F, 0.27603F, 0.27603F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LightningStrikeOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChargedPerforator"),
                    "Head",
                    new Vector3(-0.20255F, 0.06327F, -0.01457F),
                    new Vector3(83.74957F, 182.851F, 96.65418F),
                    new Vector3(0.35171F, 0.35171F, 0.35171F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarDagger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarDagger"),
                    "Chest",
                    new Vector3(0.37872F, 0.064F, -0.04894F),
                    new Vector3(0F, 0F, 90F),
                    new Vector3(0.24148F, 0.24148F, 0.24148F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPrimaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdEye"),
                    "Head",
                    new Vector3(-0.17904F, 0.10967F, 0F),
                    new Vector3(0F, 0F, 271.4052F),
                    new Vector3(0.28774F, 0.28774F, 0.28774F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSecondaryReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdClaw"),
                    "UpperArm_L",
                    new Vector3(-0.01566F, 0.04553F, 0.17261F),
                    new Vector3(25.14697F, 262.915F, 300.0552F),
                    new Vector3(0.57875F, 0.57875F, 0.57875F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarSpecialReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdHeart"),
                    "Base",
                    new Vector3(0.5561F, 0.76009F, -1.31736F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.25624F, 0.25624F, 0.25624F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarTrinket"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBeads"),
                    "Hand_R",
                    new Vector3(-0.00148F, 0.00653F, 0.02267F),
                    new Vector3(40.24226F, 6.76875F, 3.71193F),
                    new Vector3(0.79834F, 0.79834F, 0.79834F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarUtilityReplacement"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBirdFoot"),
                    "Chest",
                    new Vector3(-0.19991F, 0.06294F, 0.16211F),
                    new Vector3(4.73535F, 3.79002F, 88.27294F),
                    new Vector3(0.47882F, 0.47882F, 0.47882F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Medkit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMedkit"),
                    "Chest",
                    new Vector3(0.37763F, -0.04696F, 0.08757F),
                    new Vector3(276.7809F, 164.0434F, 287.9559F),
                    new Vector3(0.46977F, 0.46977F, 0.46977F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MinorConstructOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDefenseNucleus"),
                    "Base",
                    new Vector3(0.47151F, -0.09959F, 0.58614F),
                    new Vector3(85.07388F, 93.83635F, 180F),
                    new Vector3(0.41629F, 0.41629F, 0.41629F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Missile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                    "Chest",
                    new Vector3(0.32439F, 0.37444F, -0.32218F),
                    new Vector3(0.00001F, 273.6107F, 48.06096F),
                    new Vector3(0.09032F, 0.09032F, 0.09032F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MissileVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileLauncherVoid"),
                    "Chest",
                    new Vector3(0.32439F, 0.37444F, -0.32218F),
                    new Vector3(0.00001F, 273.6107F, 48.06096F),
                    new Vector3(0.09032F, 0.09032F, 0.09032F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MonstersOnShrineUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMonstersOnShrineUse"),
                    "Chest",
                    new Vector3(0.39536F, 0.21471F, -0.02841F),
                    new Vector3(0.36515F, 359.9805F, 4.80343F),
                    new Vector3(0.04878F, 0.04878F, 0.04878F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoreMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayICBM"),
                    "Chest",
                    new Vector3(0.20519F, -0.17419F, -0.0263F),
                    new Vector3(76.91158F, 264.152F, 268.399F),
                    new Vector3(0.09849F, 0.09849F, 0.09849F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MoveSpeedOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrappleHook"),
                    "Chest",
                    new Vector3(0.28704F, -0.10447F, 0.04987F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.16623F, 0.16623F, 0.16623F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Mushroom"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroom"),
                    "Chest",
                    new Vector3(0.25942F, 0.24099F, 0.15927F),
                    new Vector3(10.90517F, 9.89253F, 350.8164F),
                    new Vector3(0.0447F, 0.0447F, 0.0447F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MushroomVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMushroomVoid"),
                    "Chest",
                    new Vector3(0.25942F, 0.24099F, 0.15927F),
                    new Vector3(10.90517F, 9.89253F, 350.8164F),
                    new Vector3(0.0447F, 0.0447F, 0.0447F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NearbyDamageBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDiamond"),
                    "Chest",
                    new Vector3(-0.1732F, 0.07052F, 0.00112F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.04355F, 0.04355F, 0.04355F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(0.06054F, 0.2375F, 0.11199F),
                    new Vector3(346.8735F, 278.1283F, 61.23642F),
                    new Vector3(0.42715F, 0.42715F, 0.42715F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                    "Head",
                    new Vector3(0.04497F, 0.23901F, -0.09358F),
                    new Vector3(320.4057F, 132.4298F, 20.50337F),
                    new Vector3(0.42715F, 0.42715F, 0.42715F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["NovaOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                    "Head",
                    new Vector3(0.00723F, 0.07109F, -0.04747F),
                    new Vector3(351.5559F, 271.7249F, 8.66056F),
                    new Vector3(0.18643F, 0.18643F, 0.18643F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["OutOfCombatArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOddlyShapedOpal"),
                    "Chest",
                    new Vector3(-0.20335F, 0.13565F, 0.01651F),
                    new Vector3(350.5397F, 268.3481F, 10.25539F),
                    new Vector3(0.22899F, 0.22899F, 0.22899F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ParentEgg"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayParentEgg"),
                    "Chest",
                    new Vector3(-0.3108F, 0.04678F, 0.0239F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.07752F, 0.07752F, 0.07752F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Pearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPearl"),
                    "Head",
                    new Vector3(-0.00667F, 0.19522F, 0.00241F),
                    new Vector3(296.5005F, 269.2322F, 88.23769F),
                    new Vector3(0.11716F, 0.11716F, 0.11716F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PermanentDebuffOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScorpion"),
                    "Chest",
                    new Vector3(0.23936F, 0.05519F, -0.00355F),
                    new Vector3(0F, 271.5051F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PersonalShield"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                    "Chest",
                    new Vector3(-0.13922F, 0.01026F, 0F),
                    new Vector3(0F, 0F, 265.7822F),
                    new Vector3(0.13909F, 0.13909F, 0.13909F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Phasing"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStealthkit"),
                    "Chest",
                    new Vector3(-0.16095F, 0.08236F, -0.1654F),
                    new Vector3(4.52965F, 179.7182F, 86.43661F),
                    new Vector3(0.24647F, 0.24647F, 0.24647F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Plant"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                    "Chest",
                    new Vector3(-0.09728F, 0.22585F, -0.23942F),
                    new Vector3(277.1498F, 89.26342F, 179.9999F),
                    new Vector3(0.02977F, 0.02977F, 0.02977F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PrimarySkillShuriken"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShuriken"),
                    "Head",
                    new Vector3(-0.03781F, 0.25267F, -0.16717F),
                    new Vector3(0F, 315.976F, 0F),
                    new Vector3(0.14443F, 0.14443F, 0.14443F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomDamageZone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                    "Chest",
                    new Vector3(0.24095F, 0.31996F, 0.19282F),
                    new Vector3(9.03882F, 180F, 180F),
                    new Vector3(0.06452F, 0.06452F, 0.06452F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomEquipmentTrigger"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBottledChaos"),
                    "Pelvis",
                    new Vector3(-0.07411F, 0.14141F, 0.18817F),
                    new Vector3(0F, 0F, 249.6635F),
                    new Vector3(0.17761F, 0.17761F, 0.17761F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RandomlyLunar"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDomino"),
                    "Base",
                    new Vector3(0.61291F, 0.7002F, 0.59183F),
                    new Vector3(0F, 90.61418F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RegeneratingScrap"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRegeneratingScrap"),
                    "Chest",
                    new Vector3(0.12253F, 0.21664F, -0.25245F),
                    new Vector3(0F, 300.6745F, 0F),
                    new Vector3(0.17439F, 0.17439F, 0.17439F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["RepeatHeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCorpseflower"),
                    "Head",
                    new Vector3(0F, 0.24822F, -0.13029F),
                    new Vector3(322.7118F, 0F, 0F),
                    new Vector3(0.21086F, 0.21086F, 0.21086F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SecondarySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                    "Chest",
                    new Vector3(-0.08449F, 0.00566F, -0.23049F),
                    new Vector3(0F, 271.5404F, 20.59871F),
                    new Vector3(0.04354F, 0.04354F, 0.04354F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Seed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySeed"),
                    "Chest",
                    new Vector3(0.0533F, 0.01476F, 0.21988F),
                    new Vector3(295.6509F, 118.2699F, 20.62117F),
                    new Vector3(0.03433F, 0.03433F, 0.03433F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShieldOnly"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(-0.06864F, 0.26414F, 0.11709F),
                    new Vector3(2.61163F, 173.9743F, 17.78423F),
                    new Vector3(0.28874F, 0.28874F, 0.28874F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBug"),
                    "Head",
                    new Vector3(-0.07673F, 0.26437F, -0.1198F),
                    new Vector3(29.42133F, 178.2117F, 13.74956F),
                    new Vector3(0.28874F, 0.28874F, 0.28874F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShinyPearl"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                    "Head",
                    new Vector3(-0.00667F, 0.19522F, 0.00241F),
                    new Vector3(296.5005F, 269.2322F, 268.2377F),
                    new Vector3(0.11716F, 0.11716F, 0.11716F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShockNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                    "AntennaEnd",
                    new Vector3(0.00096F, -0.01368F, 0.00015F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.31269F, 0.31269F, 0.31269F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SiphonOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                    "Chest",
                    new Vector3(0.16184F, -0.03773F, -0.18741F),
                    new Vector3(330.871F, 326.8534F, 347.9729F),
                    new Vector3(0.04842F, 0.04842F, 0.04842F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBauble"),
                    "Chest",
                    new Vector3(-0.00793F, 0F, 0.16258F),
                    new Vector3(0F, 177.2082F, 0F),
                    new Vector3(0.35076F, 0.35076F, 0.35076F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SlowOnHitVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBaubleVoid"),
                    "Chest",
                    new Vector3(-0.00793F, 0F, 0.16258F),
                    new Vector3(0F, 177.2082F, 0F),
                    new Vector3(0.35076F, 0.35076F, 0.35076F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBuckler"),
                    "LowerArm_R",
                    new Vector3(-0.00248F, 0.0959F, 0.04707F),
                    new Vector3(0F, 357.0033F, 0F),
                    new Vector3(0.09929F, 0.09929F, 0.09929F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintBonus"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySoda"),
                    "Chest",
                    new Vector3(-0.16848F, 0.0698F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.21316F, 0.21316F, 0.34164F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintOutOfCombat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWhip"),
                    "Pelvis",
                    new Vector3(0.00671F, 0.20358F, -0.21216F),
                    new Vector3(0.72368F, 273.0093F, 198.3661F),
                    new Vector3(0.30444F, 0.30444F, 0.30444F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SprintWisp"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                    "Head",
                    new Vector3(-0.00001F, 0.25109F, -0.09894F),
                    new Vector3(308.0753F, 180F, 180F),
                    new Vector3(0.30264F, 0.30264F, 0.30264F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Squid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                    "Chest",
                    new Vector3(0.36103F, 0.04764F, 0.19859F),
                    new Vector3(6.71232F, 297.0324F, 273.413F),
                    new Vector3(0.04409F, 0.04409F, 0.04409F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StickyBomb"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                    "Chest",
                    new Vector3(0.37902F, 0.19489F, 0.14655F),
                    new Vector3(89.44821F, 180F, 180F),
                    new Vector3(0.21393F, 0.21393F, 0.21393F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StrengthenBurn"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGasTank"),
                    "Chest",
                    new Vector3(0.16213F, -0.00003F, 0.21071F),
                    new Vector3(0F, 85.04137F, 0F),
                    new Vector3(0.12782F, 0.12782F, 0.12782F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StunChanceOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                    "Chest",
                    new Vector3(0.3851F, -0.06567F, -0.15477F),
                    new Vector3(305.8094F, 180F, 128.6002F),
                    new Vector3(0.59578F, 0.59456F, 0.59456F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Syringe"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                    "Chest",
                    new Vector3(0.12281F, 0.17744F, -0.23244F),
                    new Vector3(303.9246F, 288.3851F, 9.68246F),
                    new Vector3(0.13846F, 0.13846F, 0.13846F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Talisman"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTalisman"),
                    "Base",
                    new Vector3(1.27459F, -0.42324F, 0.68711F),
                    new Vector3(272.6635F, 84.27998F, 186.1833F),
                    new Vector3(0.61154F, 0.61154F, 0.61154F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Thorns"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                    "LowerLeg_L",
                    new Vector3(0.00466F, -0.14789F, 0.00336F),
                    new Vector3(279.4286F, 262.1378F, 97.96846F),
                    new Vector3(0.41616F, 0.41616F, 0.41616F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TitanGoldDuringTP"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                    "Chest",
                    new Vector3(-0.16185F, -0.00001F, 0.11919F),
                    new Vector3(0F, 285.8631F, 0F),
                    new Vector3(0.24948F, 0.24948F, 0.24948F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tooth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothNecklaceDecal"),
                    "Chest",
                    new Vector3(-0.07265F, 0.17361F, 0.02066F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                    "Chest",
                    new Vector3(-0.20001F, 0.18718F, 0.00561F),
                    new Vector3(0F, 269.7748F, 0F),
                    new Vector3(1.88679F, 1.88679F, 1.88679F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(-0.18841F, 0.1814F, -0.05991F),
                    new Vector3(0F, 83.29137F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                   "Chest",
                    new Vector3(-0.15991F, 0.18517F, -0.10482F),
                    new Vector3(0F, 43.67003F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall2"),
                    "Chest",
                    new Vector3(-0.15027F, 0.18349F, 0.1196F),
                    new Vector3(1.40108F, 126.9516F, 12.72196F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayToothMeshSmall1"),
                    "Chest",
                    new Vector3(-0.18467F, 0.18138F, 0.06782F),
                    new Vector3(0F, 102.3407F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TPHealingNova"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                    "Head",
                    new Vector3(-0.06703F, 0.21518F, -0.13484F),
                    new Vector3(343.5424F, 207.6166F, 138.3708F),
                    new Vector3(0.325F, 0.325F, 0.325F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCache"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKey"),
                    "Hand_L",
                    new Vector3(0.01676F, 0.04853F, -0.0284F),
                    new Vector3(344.8114F, 262.8856F, 265.7532F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TreasureCacheVoid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKeyVoid"),
                    "Hand_L",
                    new Vector3(0.01676F, 0.04853F, -0.0284F),
                    new Vector3(344.8114F, 262.8856F, 265.7532F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["UtilitySkillMagazine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "Chest",
                    new Vector3(-0.07111F, 0.17909F, 0F),
                    new Vector3(0F, 0F, 271.5805F),
                    new Vector3(0.39444F, 0.39444F, 0.39444F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                    "Chest",
                    new Vector3(0.27768F, 0.18104F, -0.00617F),
                    new Vector3(0F, 0F, 92.2831F),
                    new Vector3(0.39444F, 0.39444F, 0.39444F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VoidMegaCrabItem"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMegaCrabItem"),
                    "Pelvis",
                    new Vector3(0.10774F, 0.14956F, 0.00217F),
                    new Vector3(0.00002F, 92.7468F, 179.4006F),
                    new Vector3(0.1127F, 0.1127F, 0.1127F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WarCryOnMultiKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPauldron"),
                    "UpperArm_L",
                    new Vector3(-0.00239F, 0.07986F, 0.07137F),
                    new Vector3(69.2226F, 0F, 0F),
                    new Vector3(0.4481F, 0.4481F, 0.4481F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WardOnLevel"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWarbanner"),
                    "Chest",
                    new Vector3(0.26152F, -0.17184F, -0.0013F),
                    new Vector3(270.1968F, 322.4484F, 37.55149F),
                    new Vector3(0.3182F, 0.3182F, 0.3182F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BFG"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBFG"),
                    "Chest",
                    new Vector3(0.31586F, 0.19245F, 0.12007F),
                    new Vector3(0F, 267.9175F, 322.0025F),
                    new Vector3(0.36063F, 0.36063F, 0.36063F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Blackhole"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGravCube"),
                    "Base",
                    new Vector3(0.50501F, 0.18418F, 0.4267F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.66456F, 0.66456F, 0.66456F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunter"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornGhost"),
                    "Head",
                    new Vector3(0.05316F, 0.35686F, -0.05877F),
                    new Vector3(17.99527F, 263.5692F, 14.54546F),
                    new Vector3(0.59295F, 0.59295F, 0.59295F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBlunderbuss"),
                    "Base",
                    new Vector3(0.84813F, -0.93831F, -0.45449F),
                    new Vector3(5.72752F, 265.7413F, 7.01252F),
                    new Vector3(0.48816F, 0.48816F, 0.48816F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BossHunterConsumed"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTricornUsed"),
                    "Head",
                    new Vector3(0.05316F, 0.35686F, -0.05877F),
                    new Vector3(17.99527F, 263.5692F, 14.54546F),
                    new Vector3(0.59295F, 0.59295F, 0.59295F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BurnNearby"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPotion"),
                    "Chest",
                    new Vector3(0.08836F, -0.10432F, 0.20602F),
                    new Vector3(24.23851F, 0F, 0F),
                    new Vector3(0.03282F, 0.03282F, 0.03148F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Cleanse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWaterPack"),
                    "Chest",
                    new Vector3(0.0645F, -0.17492F, 0.16769F),
                    new Vector3(0F, 5.73057F, 0F),
                    new Vector3(0.03946F, 0.03946F, 0.03946F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CommandMissile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMissileRack"),
                    "Chest",
                    new Vector3(0.41906F, 0.00106F, -0.00167F),
                    new Vector3(63.54191F, 92.66849F, 2.07219F),
                    new Vector3(0.50621F, 0.45912F, 0.45912F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CrippleWard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEffigy"),
                    "Pelvis",
                    new Vector3(0.13311F, 0.20948F, 0.1178F),
                    new Vector3(6.26102F, 249.7522F, 176.3354F),
                    new Vector3(0.34056F, 0.34056F, 0.34056F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                    "Head",
                    new Vector3(-0.24301F, 0.10163F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.27438F, 0.27438F, 0.27438F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DeathProjectile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                    "Pelvis",
                    new Vector3(0.14692F, 0.13858F, 0.06294F),
                    new Vector3(347.4734F, 98.7227F, 179.6219F),
                    new Vector3(0.05998F, 0.05998F, 0.05998F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DroneBackup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRadio"),
                    "Chest",
                    new Vector3(0.27559F, 0.06374F, -0.22417F),
                    new Vector3(0F, 180.4174F, 0F),
                    new Vector3(0.43487F, 0.43487F, 0.43487F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteEarthEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteMendingAntlers"),
                    "Head",
                    new Vector3(-0.1007F, 0.22575F, -0.01523F),
                    new Vector3(0F, 87.79044F, 0F),
                    new Vector3(0.45773F, 0.45773F, 0.45773F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteFireEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(-0.10656F, 0.20931F, 0.08396F),
                    new Vector3(59.54528F, 271.6492F, -0.00001F),
                    new Vector3(0.10092F, 0.10092F, 0.10092F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                    "Head",
                    new Vector3(-0.07786F, 0.1793F, -0.09843F),
                    new Vector3(53.66252F, 295.9502F, 37.80921F),
                    new Vector3(0.10092F, 0.10092F, 0.10092F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteHauntedEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                    "Head",
                    new Vector3(0.03706F, 0.32837F, 0.00051F),
                    new Vector3(87.41578F, 252.7018F, 160.0903F),
                    new Vector3(0.05305F, 0.05305F, 0.05305F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteIceEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                    "Head",
                    new Vector3(0.03706F, 0.32837F, 0.00051F),
                    new Vector3(272.5433F, 75.42621F, 197.188F),
                    new Vector3(0.03533F, 0.03533F, 0.03533F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLightningEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-0.11515F, 0.21965F, 0.01083F),
                    new Vector3(312.2474F, 272.3533F, 1.61811F),
                    new Vector3(0.30562F, 0.30562F, 0.30562F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                    "Head",
                    new Vector3(-0.02394F, 0.28778F, 0.00231F),
                    new Vector3(278.4761F, 265.8581F, 8.62979F),
                    new Vector3(0.2072F, 0.2072F, 0.2072F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteLunarEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteLunar,Eye"),
                    "Head",
                    new Vector3(-0.27937F, 0.15486F, 0F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.15645F, 0.15645F, 0.15645F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ElitePoisonEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                    "Head",
                    new Vector3(0F, 0.21471F, 0F),
                    new Vector3(270F, 0F, 0F),
                    new Vector3(0.05744F, 0.05744F, 0.05744F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteVoidEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayAffixVoid"),
                    "Head",
                    new Vector3(-0.16398F, 0.13871F, -0.00129F),
                    new Vector3(80.02962F, 273.9519F, 3.89244F),
                    new Vector3(0.15721F, 0.15721F, 0.15721F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["FireBallDash"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEgg"),
                    "Pelvis",
                    new Vector3(-0.13095F, 0.11147F, -0.13977F),
                    new Vector3(61.85883F, 225.7944F, 222.195F),
                    new Vector3(0.23875F, 0.23875F, 0.23875F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Fruit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayFruit"),
                    "Chest",
                    new Vector3(0.10001F, 0F, 0.08042F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.22936F, 0.22936F, 0.22936F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GainArmor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                    "LowerLeg_L",
                    new Vector3(-0.10747F, 0.12472F, -0.00726F),
                    new Vector3(84.51481F, 230.073F, 330.2462F),
                    new Vector3(0.35078F, 0.35078F, 0.35078F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Gateway"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVase"),
                    "Chest",
                    new Vector3(0.19245F, 0.20838F, -0.19241F),
                    new Vector3(339.4157F, 0F, 349.9713F),
                    new Vector3(0.18141F, 0.18141F, 0.18141F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GoldGat"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGoldGat"),
                    "Chest",
                    new Vector3(0.48918F, 0.34411F, 0.20797F),
                    new Vector3(18.26444F, 358.9721F, 298.345F),
                    new Vector3(0.12671F, 0.12671F, 0.12671F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GummyClone"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGummyClone"),
                    "LowerLeg_L",
                    new Vector3(-0.07369F, 0.13715F, 0.00499F),
                    new Vector3(8.94131F, 79.4669F, 0F),
                    new Vector3(0.15639F, 0.15639F, 0.15639F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IrradiatingLaser"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIrradiatingLaser"),
                    "Chest",
                    new Vector3(0.19799F, 0.06568F, 0.17483F),
                    new Vector3(346.3088F, 313.3362F, 263.6516F),
                    new Vector3(0.18921F, 0.18921F, 0.18921F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Jetpack"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBugWings"),
                    "Chest",
                    new Vector3(0.35952F, 0.06095F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.10693F, 0.10693F, 0.10693F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LifestealOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                    "Head",
                    new Vector3(0F, 0.21109F, -0.22299F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.06405F, 0.06405F, 0.06405F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Lightning"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLightningArmCustom"),
                    "UpperArm_R",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateLimbMaskDisplayRule(LimbFlags.RightArm)
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LunarPortalOnUse"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLunarPortalOnUse"),
                    "Base",
                    new Vector3(0.85324F, -0.52689F, 0.82213F),
                    new Vector3(292.3038F, 270F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Meteor"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteor"),
                    "Base",
                    new Vector3(0.50703F, -0.66709F, 0.49974F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Molotov"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMolotov"),
                    "Pelvis",
                    new Vector3(-0.14238F, 0.12643F, 0.1959F),
                    new Vector3(18.96058F, 180F, 195.7919F),
                    new Vector3(0.22771F, 0.22771F, 0.22771F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MultiShopCard"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayExecutiveCard"),
                    "Pelvis",
                    new Vector3(0.04081F, 0.10968F, -0.1708F),
                    new Vector3(273.3229F, 236.3019F, 123.7426F),
                    new Vector3(0.48274F, 0.48274F, 0.48274F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["QuestVolatileBattery"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                    "Chest",
                    new Vector3(0.3798F, 0.07584F, 0F),
                    new Vector3(0F, 270F, 0F),
                    new Vector3(0.29432F, 0.29432F, 0.29432F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Recycle"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRecycler"),
                    "Chest",
                    new Vector3(0.20859F, -0.01893F, -0.23034F),
                    new Vector3(270.4131F, 180F, 180F),
                    new Vector3(0.04993F, 0.04993F, 0.04993F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Saw"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySawmerangFollower"),
                    "Base",
                    new Vector3(0.62057F, -0.38055F, 0.3848F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.13693F, 0.13693F, 0.13693F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Scanner"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayScanner"),
                    "Chest",
                    new Vector3(0.26112F, 0.14046F, 0.0484F),
                    new Vector3(311.1332F, 88.70815F, 181.8114F),
                    new Vector3(0.23024F, 0.23024F, 0.23024F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TeamWarCry"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                    "Chest",
                    new Vector3(0.38908F, -0.00001F, 0F),
                    new Vector3(0F, 90F, 0F),
                    new Vector3(0.04936F, 0.04936F, 0.04936F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Tonic"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTonic"),
                    "Head",
                    new Vector3(0.04107F, -0.33387F, 0.17128F),
                    new Vector3(0F, 0F, 300.3592F),
                    new Vector3(0.15407F, 0.15407F, 0.15407F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["VendingMachine"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayVendingMachine"),
                    "Chest",
                    new Vector3(0.22717F, 0.30069F, 0.0884F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.08405F, 0.08405F, 0.08405F)
                    )
                ));

            //SotS Items
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BoostAllStats"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGrowthNectar"),
                   "Pelvis",
                    new Vector3(0.09604F, 0.12288F, 0.17354F),
                    new Vector3(1.25957F, 1.29923F, 166.7407F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DelayedDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDelayedDamage"),
                    "Chest",
                    new Vector3(0.36336F, 0.05242F, -0.05728F),
                    new Vector3(1.31166F, 90.06708F, 11.268F),
                    new Vector3(0.26839F, 0.26839F, 0.26839F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraShrineItem"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayChanceDoll"),
                    "Chest",
                    new Vector3(0.36795F, -0.11478F, 0.18911F),
                    new Vector3(26.02569F, 46.43238F, 359.606F),
                    new Vector3(0.1149F, 0.1149F, 0.1149F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraStatsOnLevelUp"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPrayerBeads"),
                    "Head",
                    new Vector3(0.01962F, 0.08088F, -0.00011F),
                    new Vector3(0F, 270.3165F, 0F),
                    new Vector3(2.16481F, 1.76295F, 2.03607F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrageOnBoss"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTreasuryDividends"),
                    "LowerArm_L",
                    new Vector3(0F, 0.09721F, 0.07705F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreaseDamageOnMultiKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreaseDamageOnMultiKill"),
                    "Chest",
                    new Vector3(0.36431F, -0.03249F, -0.10571F),
                    new Vector3(270.6331F, 93.32165F, 0.00155F),
                    new Vector3(0.16501F, 0.16501F, 0.16501F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["IncreasePrimaryDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayIncreasePrimaryDamage"),
                    "Chest",
                    new Vector3(0.20498F, 0.08168F, 0.20632F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.50201F, 0.50201F, 0.50201F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["KnockBackHitEnemies"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayKnockbackFin"),
                    "Head",
                    new Vector3(-0.07388F, 0.30873F, -0.00495F),
                    new Vector3(81.86796F, 279.8729F, 9.77552F),
                    new Vector3(0.28122F, 0.28122F, 0.28122F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["AttackSpeedPerNearbyAllyOrEnemy"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayRageCrystal"),
                    "Chest",
                    new Vector3(0.21485F, -0.11312F, -0.13799F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["LowerPricedChests"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayLowerPricedChests"),
                    "Base",
                    new Vector3(0.38087F, -0.18446F, 0.51145F),
                    new Vector3(355.1788F, 91.70925F, 5.32296F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MeteorAttackOnHighDamage"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayMeteorAttackOnHighDamage"),
                    "Chest",
                    new Vector3(-0.02467F, 0.26658F, -0.29284F),
                    new Vector3(0F, 272.3377F, 42.02658F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SpeedBoostPickup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElusiveAntlersLeft"),
                    "Head",
                    new Vector3(-0.04168F, 0.26611F, 0.09311F),
                    new Vector3(8.75391F, 95.96777F, 9.1939F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElusiveAntlersRight"),
                    "Head",
                    new Vector3(-0.05426F, 0.26732F, -0.0727F),
                    new Vector3(8.91361F, 75.60503F, 348.535F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["OnLevelUpFreeUnlock"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlock"),
                    "Base",
                    new Vector3(0.51118F, -0.33051F, -0.43643F),
                    new Vector3(287.3323F, 334.5395F, 117.7204F),
                    new Vector3(1F, 1F, 1F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayOnLevelUpFreeUnlockTablet"),
                    "Chest",
                    new Vector3(0.40566F, -0.06154F, -0.03119F),
                    new Vector3(5.33628F, 91.95823F, 312.1917F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ItemDropChanceOnKill"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplaySonorousEcho"),
                    "Pelvis",
                    new Vector3(-0.02903F, 0.10777F, -0.19438F),
                    new Vector3(302.6315F, 7.03862F, 91.02164F),
                    new Vector3(1F, 1F, 1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["StunAndPierce"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayElectricBoomerang"),
                    "Chest",
                    new Vector3(0.38068F, -0.04543F, -0.17514F),
                    new Vector3(356.0883F, 4.83219F, 268.9089F),
                    new Vector3(0.13579F, 0.13579F, 0.13579F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TeleportOnLowHealth"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayTeleportOnLowHealth"),
                    "Chest",
                    new Vector3(0.35286F, -0.22473F, 0.17844F),
                    new Vector3(5.02208F, 85.22944F, 345.5856F),
                    new Vector3(0.54802F, 0.54802F, 0.54802F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["TriggerEnemyDebuffs"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayNoxiousThorn"),
                    "Chest",
                    new Vector3(-0.09529F, 0.12631F, -0.18921F),
                    new Vector3(4.75627F, 3.99451F, 90.98023F),
                    new Vector3(0.63167F, 0.63167F, 0.63167F)
                    )
                ));
            //AC items
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BarrierOnCooldown"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayBarrierOnCooldown"),
                    "Chest",
                    new Vector3(0.04603F, -0.09635F, -0.20142F),
                    new Vector3(4.69576F, 3.46809F, 83.33956F),
                    new Vector3(0.09023F, 0.09023F, 0.09023F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["BonusHealthBoost"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayQuickFix"),
                    "Chest",
                    new Vector3(0.25698F, 0.25716F, 0.02942F),
                    new Vector3(359.9251F, 0.16945F, 356.6676F),
                    new Vector3(0.19697F, 0.19697F, 0.19697F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CookedSteak"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayCookedSteakFlat"),
                   "Chest",
                    new Vector3(0.31303F, 0.27395F, 0.09978F),
                    new Vector3(271.1273F, 53.49149F, 304.5389F),
                    new Vector3(0.07478F, 0.07478F, 0.07478F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["CritAtLowerElevation"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("CritAtLowerElevationDisplay"),
                    "Chest",
                    new Vector3(0.34116F, -0.14736F, -0.1159F),
                    new Vector3(9.4216F, 127.0309F, 14.99453F),
                    new Vector3(0.10074F, 0.10074F, 0.10074F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DronesDropDynamite"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DronesDropDynamiteDisplay"),
                    "Chest",
                    new Vector3(-0.09529F, 0.12631F, -0.18921F),
                    new Vector3(4.75627F, 3.99451F, 90.98023F),
                    new Vector3(0.63167F, 0.63167F, 0.63167F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["DronesDropDynamite"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DronesDropDynamiteDisplay"),
                    "Chest",
                    new Vector3(-0.17069F, -0.09938F, -0.00396F),
                    new Vector3(298.0754F, 90.18692F, 3.05344F),
                    new Vector3(0.15419F, 0.15419F, 0.15419F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Duplicator"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayDuplicator"),
                    "Chest",
                    new Vector3(0.0469F, 0.18598F, -0.36457F),
                    new Vector3(299.2726F, 160.5822F, 1.32627F),
                    new Vector3(0.1402F, 0.1402F, 0.1402F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ExtraEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayExtraEquipment"),
                    "Chest",
                    new Vector3(-0.06338F, -0.14439F, 0.20064F),
                    new Vector3(3.34437F, 339.1364F, 352.9571F),
                    new Vector3(0.17986F, 0.17986F, 0.17986F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["JumpDamageStrike"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJumpDamageStrike"),
                    "LowerLeg_L",
                    new Vector3(-0.09763F, 0.14209F, 0.00978F),
                    new Vector3(278.8739F, 327.9993F, 109.5758F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayJumpDamageStrike"),
                    "LowerLeg_R",
                    new Vector3(-0.09763F, 0.14209F, 0.00978F),
                    new Vector3(278.8738F, 327.9993F, 109.5758F),
                    new Vector3(0.3F, 0.3F, 0.3F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["MasterBattery"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPowerOrbSphere"),
                    "Chest",
                    new Vector3(-0.09529F, 0.12631F, -0.18921F),
                    new Vector3(4.75627F, 3.99451F, 90.98024F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PhysicsProjectile"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("PhysicsProjectileDisplay"),
                    "Chest",
                    new Vector3(0.34684F, 0.08994F, -0.06962F),
                    new Vector3(16.85695F, 100.416F, 358.2826F),
                    new Vector3(0.12101F, 0.12101F, 0.12101F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PowerCube"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPowerCube"),
                    "Chest",
                    new Vector3(-0.10483F, 0.12719F, -0.31498F),
                    new Vector3(4.75627F, 3.99451F, 90.98024F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["PowerPyramid"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayPowerPyramid"),
                    "Chest",
                    new Vector3(-0.10483F, 0.12719F, -0.31498F),
                    new Vector3(4.75627F, 3.99451F, 90.98024F),
                    new Vector3(0.5F, 0.5F, 0.5F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SharedSuffering"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("SharedSufferingDisplay"),
                    "Chest",
                    new Vector3(0.27021F, 0.03462F, -0.21652F),
                    new Vector3(359.4699F, 94.70332F, 270.0923F),
                    new Vector3(0.11716F, 0.11716F, 0.11716F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShieldBooster"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayShieldBooster"),
                    "LowerArm_R",
                    new Vector3(-0.01139F, 0.10372F, 0.04127F),
                    new Vector3(86.89701F, 286.1124F, 287.0939F),
                    new Vector3(0.15137F, 0.15137F, 0.15137F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["ShockDamageAura"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("ShockDamageAuraDisplay"),
                    "Chest",
                    new Vector3(0.02064F, 0.2977F, 0.33082F),
                    new Vector3(39.46093F, 351.5211F, 353.7635F),
                    new Vector3(0.11367F, 0.11367F, 0.11367F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["SpeedOnPickup"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("SpeedOnPickupDisplay"),
                    "Chest",
                    new Vector3(0.20899F, -0.00002F, 0.20936F),
                    new Vector3(22.82153F, 14.39999F, 0F),
                    new Vector3(0.12131F, 0.12131F, 0.12131F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Stew"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("StewDisplay"),
                    "Chest",
                    new Vector3(0.2302F, 0.24304F, 0.13527F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.06356F, 0.06356F, 0.06356F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["UltimateMeal"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("UltimateMealDisplay"),
                    "AntennaEnd",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0F, 0F, 0F),
                    new Vector3(0.76725F, 0.76725F, 0.62022F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["WyrmOnHit"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayWyrmOnHit"),
                    "Chest",
                    new Vector3(0.01411F, 0.30012F, 0.00023F),
                    new Vector3(0F, 269.0552F, 0F),
                    new Vector3(0.1F, 0.1F, 0.1F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["EliteCollectiveEquipment"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteCollectiveHorn"),
                    "Head",
                    new Vector3(0F, 0F, 0F),
                    new Vector3(337.7074F, 55.83787F, 7.37542F),
                    new Vector3(0.2623F, 0.2623F, 0.2623F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteCollectiveHorn"),
                    "Head",
                    new Vector3(-0.04699F, 0.00737F, 0.01106F),
                    new Vector3(345.5632F, 132.4045F, 172.5172F),
                    new Vector3(0.26247F, -0.26247F, 0.26247F)
                    ),
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayEliteCollectiveRing"),
                    "Head",
                    new Vector3(-0.0348F, 0.11507F, 0.00354F),
                    new Vector3(1.54093F, 274.8152F, 8.42855F),
                    new Vector3(0.22511F, 0.22511F, 0.22511F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["GroundEnemies"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("DisplayGroundEnemies"),
                    "Chest",
                    new Vector3(-0.21439F, 0.13497F, 0.00237F),
                    new Vector3(8.53031F, 91.97472F, 358.6857F),
                    new Vector3(0.21832F, 0.21832F, 0.21832F)
                    )
                ));
            itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(ItemDisplays.KeyAssets["Parry"],
                ItemDisplays.CreateDisplayRule(ItemDisplays.LoadDisplay("ParryDisplay"),
                    "Gun",
                    new Vector3(0.00043F, 0.16392F, 0.15534F),
                    new Vector3(273.2132F, 359.6266F, 181.719F),
                    new Vector3(0.63167F, 0.63167F, 0.63167F)
                    )
                ));

            if (RobomandoPlugin.scepterInstalled)
            {
                itemDisplayRules.Add(ItemDisplays.CreateDisplayRuleGroupWithRules(RobomandoScepterIntegration.scepterDef,
                ItemDisplays.CreateDisplayRule(RobomandoScepterIntegration.scepterDisplay,
                    "Hand_L",
                    new Vector3(-0.02244F, 0.09471F, -0.02989F),
                    new Vector3(357.8302F, 343.6697F, 93.39213F),
                    new Vector3(0.19208F, 0.19208F, 0.19208F)
                    )
                ));
            }
        }
    }
}