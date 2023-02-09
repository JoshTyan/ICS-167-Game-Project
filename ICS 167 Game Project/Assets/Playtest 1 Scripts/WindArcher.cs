using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WindArcher : BaseHealth
{
    //gets the corresponding base hp for the character
    public float health;
    public WindArcher() : base()
    {
        health = getArcherHP();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if(health <= 0) //when hp is 0 or lower destroy game object
        {
            Destroy(gameObject);
        }
    }
}
