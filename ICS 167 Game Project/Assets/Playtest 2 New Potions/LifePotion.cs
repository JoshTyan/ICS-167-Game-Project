using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class LifePotion : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //private float heal = 1f;
    //Life Potion increases max health by 5 (so also heals by 5)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if knight trigger potion
        FireKnight knightComponent = collision.gameObject.GetComponent<FireKnight>(); //returns true or false
        if(knightComponent)
        {
            knightComponent.AddMaxHealth(); //calls the corresponding AddMaxHealth() in the character's script
            Destroy(gameObject);
        }

        
        //checks if archer trigger potion
        WindArcher archerComponent = collision.gameObject.GetComponent<WindArcher>(); //returns true or false
        if(archerComponent)
        {
            archerComponent.AddMaxHealth();
            Destroy(gameObject);
        }

        //checks if mage trigger potion
        WaterMage mageComponent = collision.gameObject.GetComponent<WaterMage>(); //returns true or false
        if(mageComponent)
        {
            mageComponent.AddMaxHealth();
            Destroy(gameObject);
        }

        //checks if priest trigger potion
        HolyPriest priestComponent = collision.gameObject.GetComponent<HolyPriest>(); //returns true or false
        if(priestComponent)
        {
            priestComponent.AddMaxHealth();
            Destroy(gameObject);
        }

        //checks if witch trigger potion
        VoidWitch witchComponent = collision.gameObject.GetComponent<VoidWitch>(); //returns true or false
        if(witchComponent)
        {
            witchComponent.AddMaxHealth();
            Destroy(gameObject);
        }
        
    }
}
