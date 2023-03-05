using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShootAI : MonoBehaviour
{
    [SerializeField]
    public GameObject[] playerObject; //player objects to chase

    private enum State
    {
        Roaming,
        ChaseTarget,
        Shooting,
        Idle
    }

    private Vector2 startingRoamPosition;
    private Vector2 randomDir;
    private Vector2 roamPosition;
    private Vector2 chasePosition;
    private Vector2 chasePlayerPosition;
    private State state; //holds current state

    //when true in Shooting AI will shoot, and then stop shooting to prevent killing players too fast
    //switch it back to true in the roam state to allow shooting again
    private bool finishedShoot = false;

    //firepoint to shoot bullet from
    public GameObject bulletPrefab; //temp slot for specific potion
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public float fireForce = 20f; //controls projectile speed

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
                //finishedShoot = true; //set to true to allow shooting again once in range
                transform.position = Vector2.MoveTowards(this.transform.position, roamPosition, 2 * Time.deltaTime);
                
                float reachedPositionDistance = 1f;
                //roam to a new direction when reaching position
                if(Vector2.Distance(transform.position, roamPosition) < reachedPositionDistance)
                {
                    finishedShoot = true; //set to true to allow shooting again once in range, also must roam to two locations before shooting and chasing again
                    roamPosition = GetRoamPosition();
                    FindTarget(); //checks if player gameobject is nearby while roaming
                }
                //FindTarget(); //checks if player gameobject is nearby while roaming
                break;
            case State.ChaseTarget:
                //Chase
                //get player position to chase to and replace roamPosition
                chasePlayerPosition = GetChasePlayerPosition();
                transform.position = Vector2.MoveTowards(this.transform.position, chasePlayerPosition, 5 * Time.deltaTime);
                StartCoroutine(StopChase()); //checks if player gameobject is nearby while fleeing
                break;
            case State.Shooting:
                ShootingBullet();
                //StartCoroutine(ShootingBullet());
                //state = State.Roaming; //also maybe triggering finishedShoot to true again
                state = State.Idle; // switch back to running immediatly after dropping potion
                break;
            case State.Idle:
                StartCoroutine(IdleTimer());
                //Invoke("IdleTimer", 15.0f);
                //need to change starting position so object doesnt move back to it's original spot before roaming again
                startingRoamPosition = transform.position;
                state = State.Roaming; //move to roaming state after idling
                break;
        }

    }

    private Vector2 GetRoamPosition() //random position
    {
        //gets random direction to move to
        randomDir = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
        return startingRoamPosition + randomDir * Random.Range(5f, 5f);
    }

    private Vector2 GetChasePlayerPosition()
    {
        float targetRange = 20f;
        //checks if any playerObject is in range
        for(int i = 0; i < playerObject.Length; i++)
        {
            //make sure object is not null
            if(playerObject[i] != null)
            {
                if(Vector2.Distance(transform.position, playerObject[i].transform.position) < targetRange)
                {
                    chasePosition = playerObject[i].transform.position; //returns first player gameobject's position
                    break;
                }
            }
        }
        return chasePosition;
    }

    private void FindTarget()
    {
        //checks if player is in range of NPC
        float targetRange = 20f;
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
                    state = State.ChaseTarget;
                }
            }
        }
    }

    IEnumerator StopChase()
    {
        yield return new WaitForSeconds(3);
        state = State.Shooting; //switch to shooting state

        //state = State.Roaming;
    }

    private void ShootingBullet()
    {
        //shoots bullets
        if(finishedShoot) //finishedShoot is bool so if true spawn poition
        {
            finishedShoot = false; //switch finishedShoot to false to prevent more potion spawning until it does roaming and fleeing state again
            //4 bullets moment :despair:
            GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
            GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
            GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
            GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
            bullet1.GetComponent<Rigidbody2D>().AddForce(firePoint1.up * fireForce, ForceMode2D.Impulse);
            bullet2.GetComponent<Rigidbody2D>().AddForce(firePoint2.up * fireForce, ForceMode2D.Impulse);
            bullet3.GetComponent<Rigidbody2D>().AddForce(firePoint3.up * fireForce, ForceMode2D.Impulse);
            bullet4.GetComponent<Rigidbody2D>().AddForce(firePoint4.up * fireForce, ForceMode2D.Impulse);
        }
        //else if not true change state to roaming just in case
        //state = State.Roaming; //maybe triggering it back to true again
    }

    IEnumerator IdleTimer()
    //private void IdleTimer()
    {
        yield return new WaitForSeconds(3); //thinks it is waiting 3 seconds from StopChase()
        //state = State.Roaming; //move to roaming state after idling
    }
}
