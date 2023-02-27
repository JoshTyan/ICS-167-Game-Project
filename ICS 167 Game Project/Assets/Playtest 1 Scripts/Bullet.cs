using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class Bullet : MonoBehaviour
{
    private void Awake() // starts bullet projectile duration
    {
        StartCoroutine(selfDestruct());
    }
    
    IEnumerator selfDestruct() // self destructs bullet after set time
    {
        yield return new WaitForSeconds(1);
        Object.Destroy(this.gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //use On trigger to have players walk on top of each other and not push, and for bullets to still hit players
    //bullets cannot pass through potions on the map, so we call potions obstacles
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if archer is hit and deal damage
        //on collision, checks if gameObject has CharacterScript as a component
        if(collision.gameObject.TryGetComponent<WindArcher>(out WindArcher archerComponent))
        {
            //if it does, call TakeDamage in character script to deal damage
            archerComponent.TakeDamage(2);
        }

        // checks if knight is hit and deal damage
        if(collision.gameObject.TryGetComponent<FireKnight>(out FireKnight knightComponent))
        {
            knightComponent.TakeDamage(2);
        }

        // checks if mage is hit and deal damage
        if(collision.gameObject.TryGetComponent<WaterMage>(out WaterMage mageComponent))
        {
            mageComponent.TakeDamage(2);
        }
        
        // checks if priest is hit and deal damage
        if(collision.gameObject.TryGetComponent<HolyPriest>(out HolyPriest priestComponent))
        {
            priestComponent.TakeDamage(2);
        }
        
        // checks if witch is hit and deal damage
        if(collision.gameObject.TryGetComponent<VoidWitch>(out VoidWitch witchComponent))
        {
            witchComponent.TakeDamage(2);
        }
        
        Destroy(gameObject); //destroys bullet on collision
    }
}
