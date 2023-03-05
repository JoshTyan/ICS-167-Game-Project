using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPotionAI : MonoBehaviour
{
    [SerializeField]
    public GameObject[] playerObject; //player objects to flee from

    /* //currently unused
    [SerializeField]
    public GameObject[] potionObject;
    */

    private enum State
    {
        Roaming,
        FleeTarget,
        DropPotion
    }

    private Vector2 startingRoamPosition;
    private Vector2 randomDir;
    private Vector2 roamPosition;
    private Vector2 fleePosition;
    private Vector2 fleePlayerPosition;
    private State state; //holds current state

    //when true in DroppingPotion drop a potion, then switch to false so it doesn't drop potion again
    //switch it back to true in the roam state
    private bool finishedFlee = false;

    //firepoint to drop potion from
    public GameObject potionPrefab; //temp slot for specific potion
    public Transform firePoint;

    private void Awake()
    {
        state = State.Roaming; //default set state to Roaming on awake
    }

    private void Start()
    {
        startingRoamPosition = transform.position;
        roamPosition = GetRoamPosition();
    }

    private void Update()
    {
        switch(state)
        {
            default:
            case State.Roaming:
                //roaming speed set to 1
                //move object to new position
                //finishedFlee = true; //set to true to drop A SINGLE POTION after fleeing
                transform.position = Vector2.MoveTowards(this.transform.position, roamPosition, 2 * Time.deltaTime);
                
                float reachedPositionDistance = 1f;
                //roam to a new direction when reaching position
                if(Vector2.Distance(transform.position, roamPosition) < reachedPositionDistance)
                {
                    finishedFlee = true; //set to true to drop A SINGLE POTION after fleeing, also must roam to two locations before dropping potion again
                    roamPosition = GetRoamPosition();
                }
                FindTarget(); //checks if player gameobject is nearby while roaming
                break;
            case State.FleeTarget:
                //Flee
                //get player position to flee from and replace roamPosition
                fleePlayerPosition = GetFleePlayerPosition();
                transform.position = Vector2.MoveTowards(this.transform.position, fleePlayerPosition, -1 * 5 * Time.deltaTime);
                StartCoroutine(StopFlee()); //checks if player gameobject is nearby while fleeing

                if(finishedFlee) //if true
                {
                    state = State.DropPotion; //now drops a potion on the start of fleeing and only one time so good enough
                }
                //if false, state stays as roaming from StopFlee()
                //need to change starting position so object doesnt move back to it's original spot before roaming again
                startingRoamPosition = transform.position;
                break;
            case State.DropPotion:
                DroppingPotion();
                //StartCoroutine(DroppingPotion());
                //state = State.Roaming; //also maybe triggering finishedFlee to true again
                state = State.FleeTarget; // switch back to running immediatly after dropping potion
                break;
        }

    }

    private Vector2 GetRoamPosition() //random position
    {
        //gets random direction to move to
        randomDir = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        return startingRoamPosition + randomDir * Random.Range(5f, 5f);
    }

    private Vector2 GetFleePlayerPosition()
    {
        float targetRange = 15f;
        //checks if any playerObject is in range
        for(int i = 0; i < playerObject.Length; i++)
        {
            //make sure object is not null
            if(playerObject[i] != null)
            {
                if(Vector2.Distance(transform.position, playerObject[i].transform.position) < targetRange)
                {
                    fleePosition = playerObject[i].transform.position; //returns first player gameobject's position
                    break;
                }
            }
        }
        return fleePosition;
    }

    private void FindTarget()
    {
        //checks if player is in range of NPC
        float targetRange = 5f;
        //loop through player entities to check if they are in range
        for(int i = 0; i < playerObject.Length; i++)
        {
            //make sure object is not null
            if(playerObject[i] != null)
            {
                //checks if player game objects are in range
                if(Vector2.Distance(transform.position, playerObject[i].transform.position) < targetRange)
                {
                    //change state if player game object is in range
                    state = State.FleeTarget;
                }
            }
        }
    }

    IEnumerator StopFlee()
    {
        yield return new WaitForSeconds(3);
        //state = State.DropPotion; //automatically switch to drop potion state after fleeing // maybe bad idea

        state = State.Roaming;
    }

    private void DroppingPotion()
    //IEnumerator DroppingPotion()
    {
        //drop a random potion randomly
        //yield return new WaitForSeconds(5);
        if(finishedFlee) //finishedFlee is bool so if true spawn poition
        {
            finishedFlee = false; //switch finishedFlee to false to prevent more potion spawning until it does roaming and fleeing state again
            GameObject potion = Instantiate(potionPrefab, firePoint.position, firePoint.rotation);
            //state = State.Roaming;
        }
        //else if not true change state to roaming just in case
        //state = State.Roaming; //maybe triggering it back to true again
    }
}
