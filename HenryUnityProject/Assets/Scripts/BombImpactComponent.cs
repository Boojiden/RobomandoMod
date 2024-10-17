using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombImpactComponent : MonoBehaviour
{
    public GameObject effect;
    public void OnCollisionEnter(Collision collision)
    {

        var point = collision.contacts[0].point;
        var dir = (transform.position - point) * 0.2f;

        point += dir;
        var normal = collision.contacts[0].normal;
        GameObject.Instantiate(effect, point, Quaternion.LookRotation(normal));

        /*
        if (Physics.Raycast(point, dir, out var hitInfo, 10f))
        {
            
            
            Debug.DrawRay(point, Quaternion.LookRotation(normal).eulerAngles);
        }
        */
        Debug.DrawRay(point, dir, Color.red);
        
        //Quaternion rot = Quaternion.LookRotation(collision., Vector3.forward);
        //
    }
}

