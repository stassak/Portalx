using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy collided with Player!");
            PlayerHealth playerHP = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damageAmount);
            }
        }
    }

}
