using R2API.Utils;
using RoR2;
using RoR2.ContentManagement;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace RobomandoMod.Characters.Survivors.Robomando.Test
{
    internal class LogEvents
    {
        public static void PrintSoundEvents()
        {
            var sounds = ContentManager.networkSoundEventDefs;
            foreach (var sound in sounds)
            {
                Log.Debug($"Sound Event: {sound.name} at {sound.eventName}");
            }
        }

        public static void PrintSceneNames()
        {
            foreach(var name in SceneCatalog.allBaseSceneNames)
            {
                Log.Debug($"[LogEvents]: SceneName: {name}");
            }
        }
    }
}
