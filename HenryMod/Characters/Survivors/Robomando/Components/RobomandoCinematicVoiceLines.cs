using R2API.Networking.Interfaces;
using RobomandoMod.Survivors.Robomando;
using RoR2;
using RoR2BepInExPack.GameAssetPaths;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace RobomandoMod.Characters.Survivors.Robomando.Components
{
    public class RobomandoCinematicVoiceLines : MonoBehaviour
    {
        public ParticleSystem system;

        private GameObject characterGameObject;
        private CharacterBody body;
        public Xoroshiro128Plus rng;

        private bool canPlayVoice = true;
        private bool isPlaying = false;

        private float voiceCooldownTime = 5f;

        private float randomVoiceLineTimeMin = 30f;
        private float randomVoiceLineTimeMax = 60f;

        private float currentWaitTime = 0f;
        private float currentWaitGoal = 0f;

        private List<string> grabBagList = new List<string> 
        {
            "Play_Robo_Voice_Enemies_Check",
            "Play_Robo_Voice_Gold_Number",
            "Play_Robo_Voice_Survival_Time",
            "Play_Robo_Voice_Grab_Bag",
            "Play_Robo_Voice_Grab_Bag",
            "Play_Robo_Voice_Grab_Bag",
            "Play_Robo_Voice_Grab_Bag",
        };

        public void Start()
        {
            characterGameObject = gameObject;
            body = characterGameObject.GetComponent<CharacterBody>();
            if (NetworkServer.active)
            {
                rng = new Xoroshiro128Plus(Run.instance.runRNG.nextUlong);
            }
            else
            {
                //Component will share the event with the network anyway so idk if its synced
                rng = new Xoroshiro128Plus((ulong)UnityEngine.Random.RandomRangeInt(0, int.MaxValue));
            }

            currentWaitGoal = rng.RangeFloat(randomVoiceLineTimeMin, randomVoiceLineTimeMax);
        }

        public void Update()
        {
            if (!RobomandoConfig.CinematicMode.Value)
            {
                return;
            }
            currentWaitTime += Time.deltaTime;
            if(currentWaitTime > currentWaitGoal)
            {
                currentWaitTime = 0;
                currentWaitGoal = rng.RangeFloat(randomVoiceLineTimeMin, randomVoiceLineTimeMax);
                RandomVoiceBag();
            }
        }
        private void RandomVoiceBag()
        {
            string voiceEvent = grabBagList[rng.RangeInt(0, grabBagList.Count)];
            if (voiceEvent.Equals("Play_Robo_Voice_Enemies_Check"))
            {
                EnemiesNearbyBehavior();
            }
            else
            {
                PlayVoiceEvent(voiceEvent);
            }
        }

        public void EnemiesNearbyBehavior()
        {
            SphereSearch search = new SphereSearch();
            search.origin = body.corePosition;
            search.radius = 13f;
            search.queryTriggerInteraction = QueryTriggerInteraction.Ignore;
            search.mask = LayerIndex.entityPrecise.mask;
            search.RefreshCandidates();

            TeamMask mask = TeamMask.GetEnemyTeams(body.teamComponent.teamIndex);
            search.FilterCandidatesByHurtBoxTeam(mask);
            search.FilterCandidatesByDistinctHurtBoxEntities();
            HurtBox[] entities = search.GetHurtBoxes();
            int count = 0;
            foreach(HurtBox entity in entities)
            {
                if((bool)entity && (bool)entity.healthComponent)
                {
                    var health = entity.healthComponent;
                    if(health.alive && !(health.gameObject.Equals(characterGameObject)))
                    {
                        count++;
                    }
                }
            }

            if(count <= 0)
            {
                PlayVoiceEvent("Play_Robo_Voice_No_Enemies");
            }
            else
            {
                PlayVoiceEvent("Play_Robo_Voice_Enemies_Near");
            }
        }

        public static void PlayRoboVoice(GameObject robo, string voiceEvent)
        {
            if (!robo)
            {
                return;
            }
            if(!robo.TryGetComponent<CharacterBody>(out var body))
            {
                return;
            }
            if(!(body.baseNameToken != null && body.baseNameToken.Equals("RAT_ROBOMANDO_NAME")))
            {
                return;
            }
            if(!robo.TryGetComponent<RobomandoCinematicVoiceLines>(out var lines))
            {
                return;
            }
            lines.PlayVoiceEvent(voiceEvent);
        }

        public void PlayVoiceEvent(string voiceEvent)
        {
            VoiceLineNetMessage message = new VoiceLineNetMessage(body.netId, voiceEvent);
            if(body.hasAuthority)
            {
                PlayVoiceEventInternal(voiceEvent);
                if (!NetworkServer.active)
                {
                    Log.Debug("Auth Client Sent Voice Request");
                    message.Send(R2API.Networking.NetworkDestination.Server);
                }
                else
                {
                    Log.Debug("Auth Server Sent Voice Request");
                    message.Send(R2API.Networking.NetworkDestination.Clients);
                }
            }
        }

        private void PlayVoiceEventInternal(string voiceEvent)
        {
            Log.Debug($"[CinematicVoiceController] Tried playing voice event {voiceEvent}");
            if (AkSoundEngine.GetIDFromString(voiceEvent).Equals(AkSoundEngine.AK_INVALID_UNIQUE_ID))
            {
                return;
            }
            if (!RobomandoConfig.CinematicMode.Value)
            {
                return;
            }
            if (!canPlayVoice)
            {
                return;
            }
            VoiceChain chain = new VoiceChain(new List<string> { voiceEvent });
            if(voiceEvent.Equals("Play_Robo_Voice_Gold_Number"))
            {
                chain = ConstructGoldVoiceChain(chain);
            }
            else if (voiceEvent.Equals("Play_Robo_Voice_Survival_Time"))
            {
                chain = ConstructSurvivalTimeVoiceChain(chain);
            }
            else if (voiceEvent.Equals("Play_Robo_Voice_Spawn_Stage"))
            {
                chain = ConstructStageVoiceChain(chain);
            }
            chain.Reset();
            AkSoundEngine.PostEvent(chain.PopNext(), characterGameObject, 8, postEvent, chain);
            isPlaying = true;
            canPlayVoice = false;
        }

        private void postEvent(object in_cookie, AkCallbackType in_type, AkCallbackInfo in_info)
        {
            VoiceChain chain = (VoiceChain)in_cookie;
            if(in_type == AkCallbackType.AK_Duration)
            {
                var durationInfo = (AkDurationCallbackInfo)in_info;
                float duration = durationInfo.fDuration / 1000f;//in ms
                //float eDuration = durationInfo.fEstimatedDuration;
                //Log.Debug($"[CinematicController] Event Duration: {duration} or ~{eDuration}");
                //Log.Debug($"[CinematicController] Cookie: {in_cookie}");
                if (!system.isPlaying)
                {
                    system.Play();
                }
                if (!chain.IsValid())
                {
                    StartCoroutine(StopVoiceSystemAndReset(duration));
                }
                else
                {
                    StartCoroutine(DelayNextPostEvent(duration, chain));
                }
            }
        }
        private IEnumerator DelayNextPostEvent(float duration, VoiceChain chain)
        {
            yield return new WaitForSeconds(duration);
            AkSoundEngine.PostEvent(chain.PopNext(), characterGameObject, 8, postEvent, chain);
        }

        private IEnumerator StopVoiceSystemAndReset(float duration)
        {
            yield return new WaitForSeconds(duration);
            system.Stop();
            isPlaying = false;
            yield return new WaitForSeconds(voiceCooldownTime);
            canPlayVoice = true;
        }

        private VoiceChain ConstructStageVoiceChain(VoiceChain chain)
        {
            int stageNum = Run.instance.stageClearCount + 1;
            chain = AddNumberLines(chain, stageNum.ToString());
            return chain;
        }

        private VoiceChain ConstructGoldVoiceChain(VoiceChain chain)
        {
            uint gold = 0;
            //Should already have the first line
            if(characterGameObject && characterGameObject.TryGetComponent<CharacterBody>(out var body))
            {
                if (body.master)
                {
                    gold = body.master.money;
                }
            }
            chain = AddNumberLines(chain, gold.ToString());
            return chain;
        }
        private VoiceChain ConstructSurvivalTimeVoiceChain(VoiceChain chain)
        {
            float timer = Run.instance.GetRunStopwatch();
            var timeSpan = TimeSpan.FromSeconds(timer);
            string timerString = string.Format("{0:D1}:{1:D2}", (int)Math.Floor(timeSpan.TotalMinutes), (int)Math.Abs(timeSpan.Seconds));
            string[] split = timerString.Split(":");
            chain = AddNumberLines(chain, split[0]);
            chain.Append("Play_Robo_Voice_Minutes_And");
            chain = AddNumberLines(chain, split[1]);
            chain.Append("Play_Robo_Voice_Seconds");

            return chain;
        }

        private VoiceChain AddNumberLines(VoiceChain chain, string numbers)
        {
            char[] nums = numbers.ToCharArray();
            foreach(char n in nums)
            {
                if(char.IsDigit(n))
                    chain.Append("Play_Robo_Voice_Num_" + n);
            }
            return chain;
        }

        public class VoiceLineNetMessage : INetMessage
        {
            public NetworkInstanceId obj;
            public string voiceEvent;
            public bool visitedServer;

            public VoiceLineNetMessage(NetworkInstanceId gObj, string voiceEvent, bool visited = false)
            {
                obj = gObj;
                this.voiceEvent = voiceEvent;
                visitedServer = visited;
            }
            public VoiceLineNetMessage()
            {
                obj = NetworkInstanceId.Invalid;
                voiceEvent = string.Empty;
                visitedServer = false;
            }
            public void Deserialize(NetworkReader reader)
            {
                obj = reader.ReadNetworkId();
                voiceEvent = reader.ReadString();
                visitedServer = reader.ReadBoolean();
            }

            public void OnReceived()
            {
                if (obj == NetworkInstanceId.Invalid)
                {
                    Log.Warning($"[VoiceLineController] Message came back with invalid id.");
                    return;
                }
                GameObject gObj = null;
                if (NetworkServer.active)
                {
                    gObj = NetworkServer.FindLocalObject(obj);
                }
                else
                {
                    gObj = ClientScene.FindLocalObject(obj);
                }
                if (gObj == null)
                {
                    Log.Warning($"[VoiceLineController] Message came back with invalid object and valid id.");
                    return;
                }
                if (!gObj.TryGetComponent<RobomandoCinematicVoiceLines>(out var lines))
                {
                    Log.Warning($"[VoiceLineController] Message came back without voice line component, but with valid id.");
                    return;
                }
                if(!gObj.TryGetComponent<CharacterBody>(out var body))
                {
                    Log.Warning($"[VoiceLineController] Message came back without body component, but with valid id.");
                    return;
                }
                bool auth = body.hasAuthority;
                if (auth)
                {
                    return;
                }
                if (NetworkServer.active && !visitedServer)
                {
                    lines.PlayVoiceEventInternal(voiceEvent);
                    Log.Debug("Server Recieved Voice Request and sends to clients");
                    VoiceLineNetMessage newMessage = new VoiceLineNetMessage(obj, voiceEvent, true);
                    newMessage.Send(R2API.Networking.NetworkDestination.Clients);
                }
                else
                {
                    Log.Debug("Client recieved voice request");
                    lines.PlayVoiceEventInternal(voiceEvent);
                }
            }

            public void Serialize(NetworkWriter writer)
            {
                writer.Write(obj);
                writer.Write(voiceEvent);
                writer.Write(visitedServer);
            }
        }
        private class VoiceChain : IEnumerator<string>
        {
            private VoiceNode _current;
            private VoiceNode _head;

            public string Current => _current.soundEvent;

            object IEnumerator.Current => Current;

            private class VoiceNode
            {
                public string soundEvent = "";
                public float offset;
                public VoiceNode next;

                public VoiceNode(string soundEvent, float offset = 0f)
                {
                    this.soundEvent = soundEvent;
                    this.offset = offset;
                    next = null;
                }
            }

            public VoiceChain(List<string> soundEvents)
            {
                foreach(string soundEvent in soundEvents)
                {
                    Append(soundEvent);
                }
                Reset();
            }
            /// <summary>
            /// Adds a string node to the end of the chain
            /// </summary>
            /// <param name="soundEvent"></param>
            public void Append(string soundEvent, float in_offset = 0f)
            {
                var newNode = new VoiceNode(soundEvent,in_offset);
                if (_head == null)
                {
                    _head = newNode;
                    _current = _head;
                }
                else
                {
                    _current.next = newNode;
                    _current = _current.next;
                }
            }

            public bool MoveNext()
            {
                if(!IsValid())
                {
                    return false;
                }
                _current = _current.next;
                return true;
            }
            /// <summary>
            /// Returns the current chain node string and goes to the next one, if possible
            /// </summary>
            /// <returns></returns>
            public string PopNext()
            {
                var toReturn = Current;
                MoveNext();
                return toReturn;
            }
            /// <summary>
            /// Brings the chain to the start for iteration
            /// </summary>
            public void Reset()
            {
                _current = _head;
            }
            /// <summary>
            /// Returns true if the chain has ended. Otherwise returns false
            /// </summary>
            /// <returns></returns>
            public bool IsValid()
            {
                return _current != null;
            }

            public void Dispose()
            {
                Reset();
                while(_current != null)
                {
                    _current = _current.next;
                }
                _head = null;
            }
        }
    }

}
