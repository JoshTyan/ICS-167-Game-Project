using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan, Kevin Rogan

public class WaterMage : BaseHealth
{
    //gets the corresponding base hp for the character
    public float maxHealth;
    public float health;
    bool noMaxHealthGained = true; //prevents max health from being increased more than once
    public float damageReductionAmount = 0; //set damage reduction amount to 0 to be used later
    bool takeNoDamage = false;

    public WaterMage() : base()
    {
        maxHealth = getMageHP();
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

    //increases maxHealth by 5 and heals by 5
    public void AddMaxHealth()
    {
        if(noMaxHealthGained)
        {
            maxHealth += 5;
            HealHealth(5);
            noMaxHealthGained = false;
        }
        
    }

    public void reduceDamage()
    {
        damageReductionAmount = 1; //sets damage reduction amount to 1
    }

    public void noDamage()
    {
        takeNoDamage = true;
    }

    public void TakeDamage(float damageAmount)
    {
        if(!takeNoDamage) //if takeNoDamage is false, take damage normally
        {
            health = health - damageAmount + damageReductionAmount;

            //reset damageReductionAmount to 0
            damageReductionAmount = 0;
        }
        if(takeNoDamage) //if take no damage is true, take no damage and reset the bool to false
        {
            takeNoDamage = false;
        }

        if(health <= 0) //when hp is 0 or lower destroy game object
        {
            Destroy(gameObject);
        }
    }
}
