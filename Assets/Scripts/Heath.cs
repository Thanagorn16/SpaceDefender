using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] int health = 50;

    void OnTriggerEnter2D(Collider2D other)
    {
        DamgeDealer damageDealer = other.GetComponent<DamgeDealer>();

        if(damageDealer != null)
        {
            // take damage
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }   
    }
 
    void TakeDamage(int damage)
    {
        Debug.Log("Dagmage: " + damage);
        health -= damage;
        Debug.Log("take damage: "  + health);

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
