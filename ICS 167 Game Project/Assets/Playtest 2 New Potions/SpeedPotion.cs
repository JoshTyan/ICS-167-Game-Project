using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan

public class SpeedPotion : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //Speed Potion increases character speed by 1
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if a player with characterScript trigger potion
        CharacterScript playerComponent = collision.gameObject.GetComponent<CharacterScript>(); //returns true or false
        if(playerComponent)
        {
            playerComponent.increaseSpeed(); //calls the corresponding increaseSpeed() in the character's script
            Destroy(gameObject);
        }
    }
}
