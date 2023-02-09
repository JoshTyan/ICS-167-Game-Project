using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan, Kevin Rogan

public class VoidWitch : BaseHealth
{
    //gets the corresponding base hp for the character
    public float maxHealth;
    public float health;
    public VoidWitch() : base()
    {
        maxHealth = getWitchHP();
    }

    //set health equal to max health at start
    private void Start()
    {
        health = maxHealth;
    }

    //heal on health potion pickup
    public void HealHealth(float healAmount)
    {
        health += healAmount;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
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
