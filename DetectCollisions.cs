using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
        Destroy(gameObject,0.1f);//destroy enemy
        Destroy(other.gameObject, 0.1f);// destroy bullet
        }
    }
}
