using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RobomandoMod.Characters.Survivors.Robomando.Components
{
    public class KillVFX : MonoBehaviour
    {
        public float lifeTime = 1f;

        public void Start()
        {
            StartCoroutine("KillAfter");
        }

        public IEnumerable KillAfter()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}

