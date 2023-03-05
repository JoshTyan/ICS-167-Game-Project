using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class InvincibilityPotion : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //Invincibility Potion reduces all damage taken from next shot
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if knight trigger potion
        FireKnight knightComponent = collision.gameObject.GetComponent<FireKnight>(); //returns true or false
        if(knightComponent)
        {
            knightComponent.noDamage(); //calls the corresponding noDamage() in the character's script
            Destroy(gameObject);
        }

        
        //checks if archer trigger potion
        WindArcher archerComponent = collision.gameObject.GetComponent<WindArcher>(); //returns true or false
        if(archerComponent)
        {
            archerComponent.noDamage();
            Destroy(gameObject);
        }

        //checks if mage trigger potion
        WaterMage mageComponent = collision.gameObject.GetComponent<WaterMage>(); //returns true or false
        if(mageComponent)
        {
            mageComponent.noDamage();
            Destroy(gameObject);
        }

        //checks if priest trigger potion
        HolyPriest priestComponent = collision.gameObject.GetComponent<HolyPriest>(); //returns true or false
        if(priestComponent)
        {
            priestComponent.noDamage();
            Destroy(gameObject);
        }

        //checks if witch trigger potion
        VoidWitch witchComponent = collision.gameObject.GetComponent<VoidWitch>(); //returns true or false
        if(witchComponent)
        {
            witchComponent.noDamage();
            Destroy(gameObject);
        }
        
    }
}
