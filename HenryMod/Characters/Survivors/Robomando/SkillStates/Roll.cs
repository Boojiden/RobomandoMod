using EntityStates;
using RobomandoMod.Survivors.Robomando;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RobomandoMod.Survivors.Robomando.SkillStates
{
    public class Roll : BaseSkillState
    {
        public static float duration = 1f;
        public static float initialSpeedCoefficient = 1.8f;
        public static float crashDuration = 2f;
        public static float finalSpeedCoefficient = 0.9f;
        public static float upwardThrust = 15f;

        public static string dodgeSoundString = "RobomandoRoll";
        public static float dodgeFOV = global::EntityStates.Commando.DodgeState.dodgeFOV;

        private float rollSpeed;
        private Vector3 forwardDirection;
        private float currentUpwardThrust;
        private Animator animator;
        private Vector3 previousPosition;

        private bool canLeave = false;
        private bool updateVelocity = true;
        private float currentGroundDuration = 0f;

        private float startingLiftTime = 0.5f;

        public override void OnEnter()
        {
            base.OnEnter();
            animator = GetModelAnimator();
            canLeave = false;
            if (isAuthority && inputBank && characterDirection)
            {
                forwardDirection = (inputBank.moveVector == Vector3.zero ? characterDirection.forward : inputBank.moveVector).normalized;
            }

            Vector3 rhs = characterDirection ? characterDirection.forward : forwardDirection;
            Vector3 rhs2 = Vector3.Cross(Vector3.up, rhs);

            float num = Vector3.Dot(forwardDirection, rhs);
            float num2 = Vector3.Dot(forwardDirection, rhs2);

            RecalculateRollSpeed();

            if (characterMotor && characterDirection)
            {
                characterMotor.velocity = forwardDirection * rollSpeed;
                characterMotor.velocity.y += upwardThrust;
                currentUpwardThrust = upwardThrust;
            }

            Vector3 b = characterMotor ? characterMotor.velocity : Vector3.zero;
            previousPosition = transform.position - b;

            PlayAnimation("FullBody, Override", "RollStart", "Roll.playbackRate", duration);
            Util.PlaySound(dodgeSoundString, gameObject);

            if (NetworkServer.active)
            {
                //characterBody.AddTimedBuff(RobomandoBuffs.armorBuff, 3f * duration);
                characterBody.AddTimedBuff(RoR2Content.Buffs.HiddenInvincibility, 0.5f * duration);
            }
        }

        private void RecalculateRollSpeed()
        {
            rollSpeed = moveSpeedStat * Mathf.Lerp(initialSpeedCoefficient, finalSpeedCoefficient, fixedAge / duration);
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            //RecalculateRollSpeed();

            if (characterDirection) characterDirection.forward = forwardDirection;
            if (cameraTargetParams) cameraTargetParams.fovOverride = Mathf.Lerp(dodgeFOV, 60f, fixedAge / duration);

            Vector3 normalized = (transform.position - previousPosition).normalized;
            if (characterMotor && characterDirection && normalized != Vector3.zero && (!isGrounded || startingLiftTime > 0f))
            {
                Vector3 vector = normalized * rollSpeed;
                float d = Mathf.Max(Vector3.Dot(vector, forwardDirection), 0f);
                vector = forwardDirection * d;
                vector.y = characterMotor.velocity.y;

                characterMotor.velocity = vector;
            }
            previousPosition = transform.position;

            if(startingLiftTime > 0f)
            {
                startingLiftTime -= GetDeltaTime();
            }

            if (isGrounded && startingLiftTime <= 0f)
            {
                if(canLeave == false)
                {
                    PlayAnimation("FullBody, Override", "RollCrash", "Roll.playbackRate", crashDuration);
                    Util.PlaySound("GroundHit", gameObject);
                    if (!RobomandoConfig.ShutHimUp.Value)
                    {
                        Util.PlaySound("GroundHitVoice", gameObject);
                    }
                    characterMotor.velocity = Vector3.zero;
                }
                canLeave = true;
            }

            if (canLeave)
            {
                currentGroundDuration += GetDeltaTime();
                if (currentGroundDuration > crashDuration)
                {
                    outer.SetNextStateToMain();
                }
            }
        }

        public override void OnExit()
        {
            if (cameraTargetParams) cameraTargetParams.fovOverride = -1f;
            base.OnExit();

            characterMotor.disableAirControlUntilCollision = true;
        }

        public override void OnSerialize(NetworkWriter writer)
        {
            base.OnSerialize(writer);
            writer.Write(forwardDirection);
        }

        public override void OnDeserialize(NetworkReader reader)
        {
            base.OnDeserialize(reader);
            forwardDirection = reader.ReadVector3();
        }
    }
}