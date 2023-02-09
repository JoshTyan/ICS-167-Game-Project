using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class HealthPotion4 : MonoBehaviour
{
    //TEMP, HealthPotion that heals 4
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if knight trigger potion
        FireKnight knightComponent = collision.gameObject.GetComponent<FireKnight>(); //returns true or false
        if(knightComponent)
        {
            knightComponent.HealHealth(4);
            Destroy(gameObject);
        }


        //checks if archer trigger potion
        WindArcher archerComponent = collision.gameObject.GetComponent<WindArcher>(); //returns true or false
        if(archerComponent)
        {
            archerComponent.HealHealth(4);
            Destroy(gameObject);
        }

        //checks if mage trigger potion
        WaterMage mageComponent = collision.gameObject.GetComponent<WaterMage>(); //returns true or false
        if(mageComponent)
        {
            mageComponent.HealHealth(4);
            Destroy(gameObject);
        }

        //checks if priest trigger potion
        HolyPriest priestComponent = collision.gameObject.GetComponent<HolyPriest>(); //returns true or false
        if(priestComponent)
        {
            priestComponent.HealHealth(4);
            Destroy(gameObject);
        }

        //checks if witch trigger potion
        VoidWitch witchComponent = collision.gameObject.GetComponent<VoidWitch>(); //returns true or false
        if(witchComponent)
        {
            witchComponent.HealHealth(4);
            Destroy(gameObject);
        }
        
    }
}
