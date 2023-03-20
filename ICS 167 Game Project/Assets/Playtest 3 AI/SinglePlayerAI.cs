using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Joshua Tyan, Kevin Rogan

public class SinglePlayerAI : MonoBehaviour
{
    [SerializeField]
    public GameObject[] playerObject; //player objects to chase

    [SerializeField]
    public GameObject[] potionObject; //potion objects to get


    private enum State
    {
        GetPotion,
        ChaseTarget,
        Shooting,
        Idle
    }

    public float moveSpeedAI = 5f;

    private Vector2 potionPosition;
    private Vector2 chasePotionPosition;
    private Vector2 chasePosition;
    private Vector2 chasePlayerPosition;
    private State state; //holds current state

    //when true in Shooting AI will shoot, and then stop shooting to prevent killing players too fast
    //switch it back to true in the roam state to allow shooting again
    private bool finishedShoot = false;

    //true false switch for moving from getting potion and chasing enemy
    private bool grabbedPotion = false;
    private bool chaseOnly = false;

    //aiming variables
    public Rigidbody2D rb;
    private Vector2 aimPosition; //aimPosition is enemy position which substitutes mousePosition in CharacterScript

    //firepoint to shoot bullet from
    public GameObject bulletPrefab; //temp slot for specific potion
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public float fireForce = 10f; //controls projectile speed

    private void Awake()
    {
        state = State.GetPotion; //default set state to GetPotion on awake
    }

    private void Update()
    {
        switch(state)
        {
            default:
            case State.GetPotion:
                //Get Potion
                if(grabbedPotion == false) //grabbedPotion alters between getting potion and chasing player
                {
                    chasePotionPosition = GetPotionPosition();
                }
                if(chaseOnly == false)//if chaseOnly is true skip moving to potion position
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, chasePotionPosition, moveSpeedAI * Time.deltaTime);
                }
                
                if(Vector2.Distance(this.transform.position, chasePotionPosition) == 0f) //upon reaching potion position FindTarget
                {
                    finishedShoot = true;
                    state = State.ChaseTarget;
                }
                
                //finishedShoot = true;
                break;
            case State.ChaseTarget:
                //Chase
                //get player position to chase to and replace roamPosition
                chasePlayerPosition = GetChasePlayerPosition();
                if(Vector2.Distance(this.transform.position, chasePlayerPosition)>5){
                    transform.position = Vector2.MoveTowards(this.transform.position, chasePlayerPosition, moveSpeedAI * Time.deltaTime);
                }
                
                //aiming elements
                Vector2 aimDirection = chasePlayerPosition - rb.position;
                float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = aimAngle;

                StartCoroutine(StopChase()); //checks if player gameobject is nearby while fleeing
                break;
            case State.Shooting:
                ShootingBullet();
                state = State.Idle; // switch back to running immediatly after dropping potion
                break;
            case State.Idle:
                StartCoroutine(IdleTimer());
                grabbedPotion = false;
                state = State.GetPotion; //move to GetPotion state after idling
                break;
        }

    }

    private Vector2 GetPotionPosition()
    {
        grabbedPotion = true;
        for(int i = 0; i < potionObject.Length;)
        {
            if(potionObject[i] != null)
            {
                potionPosition = potionObject[i].transform.position;
                break;
            }
            i++; //manually increment i to check if list is out of objects
            if(i == potionObject.Length) //if no more potion to get switch to chase target state
            {
                //potionPosition = this.transform.position;
                chaseOnly = true;
                finishedShoot = true;
                state = State.ChaseTarget;
            }
        }
        return potionPosition;
    }

    private Vector2 GetChasePlayerPosition()
    {
        //check list of targets to chase
        for(int i = 0; i < playerObject.Length; i++)
        {
            //make sure object is not null
            if(playerObject[i] != null)
            {
                chasePosition = playerObject[i].transform.position; //returns first player gameobject's position
                aimPosition = playerObject[i].transform.position; //sets aim position to player object AI will chase
                break;
            }
        }
        return chasePosition;
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
            //here
            finishedShoot = false; //switch finishedShoot to false to prevent more potion spawning until it does roaming and fleeing state again
            //4 bullets moment :despair:
            if(firePoint1 != null)
            {
                GameObject bullet1 = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                bullet1.GetComponent<Rigidbody2D>().AddForce(firePoint1.up * fireForce, ForceMode2D.Impulse);
            }
            if(firePoint2 != null)
            {
                GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                bullet2.GetComponent<Rigidbody2D>().AddForce(firePoint2.up * fireForce, ForceMode2D.Impulse);
            }
            if(firePoint3 != null)
            {
                GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
                bullet3.GetComponent<Rigidbody2D>().AddForce(firePoint3.up * fireForce, ForceMode2D.Impulse);
            }
            if(firePoint4 != null)
            {
                GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
                bullet4.GetComponent<Rigidbody2D>().AddForce(firePoint4.up * fireForce, ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator IdleTimer()
    //private void IdleTimer()
    {
        yield return new WaitForSeconds(3); //thinks it is waiting 3 seconds from StopChase()
    }

    public void increaseSpeed() //increase move speed of AI
    {
        moveSpeedAI += 1;
    }
}
