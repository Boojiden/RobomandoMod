using RoR2;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace HenryMod.Characters.Survivors.Robomando.Content
{
    public class DisplayAnimationEvent : MonoBehaviour
    {
        private Animator animator;

        private void Start()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        public void PlayAnimSound(AnimationEvent animEvent)
        {
            if(animEvent.stringParameter != null)
            {
                Util.PlaySound(animEvent.stringParameter, gameObject);
            }
        }

        public void TrySetIdleTrigger()
        {
            if(UnityEngine.Random.Range(0f, 1f) < 0.1f)
            {
                animator.SetTrigger("DoIdleIntroVar");
            }
        }
    }
}
