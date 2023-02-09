using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaterMage : BaseHealth
{
    //gets the corresponding base hp for the character
    public float health;
    public WaterMage() : base()
    {
        health = getMageHP();
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
