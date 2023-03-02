using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFlee : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //calculates distance between object and player object to follow
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        //same logic as Chase, but set to negative to Flee
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -1 * speed * Time.deltaTime);
    }
}

/*

THROWAWAY FOR SOMETHING ELSE
private void StopFlee()
    {
        //checks if player is in range of NPC
        float targetRange = 25f;
        float closestDistance = 999f;
        int closestObjectIndex = 0;
        //loop through player entities to check if they are in range
        for(int i = 0; i < playerObject.Length; i++)
        {
            //make sure object is not null
            if(playerObject[i] != null)
            {
                //closestDistance = Vector2.Distance(transform.position, playerObject[i].transform.position);
                //checks if player game object is far enough
                if(Vector2.Distance(transform.position, playerObject[i].transform.position) < closestDistance)
                {
                    //change closest distance and save the index of the closest game object
                    closestDistance = Vector2.Distance(transform.position, playerObject[i].transform.position);
                    closestObjectIndex = i;
                }
                //loop through the rest to find the closest index object
                /*
                else
                {
                    state = State.Roaming; //switch state back to roaming and repeat
                }*/ /*OTHER COMMENT STARTS HERE
            }
        }
        //checks if distance between closestObject and NPC is beyond target range
        if(Vector2.Distance(transform.position, playerObject[closestObjectIndex].transform.position) > targetRange)
        {
            //change state to roaming once far enough
            state = State.Roaming;
        }
        
    }

*/
