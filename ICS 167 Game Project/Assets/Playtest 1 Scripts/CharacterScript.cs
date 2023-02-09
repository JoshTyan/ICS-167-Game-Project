using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kevin Rogan

public class CharacterScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    // controls which weapon bullet comes out from
    public Weapon weapon;
    public Weapon weapon2;
    public Weapon weapon3;
    public Weapon weapon4;

    Vector2 moveDirection;
    Vector2 mousePosition;

    void Update()
    {
        //checks movement
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        //checks shoot condition
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
            if(!(weapon2 == null)){
                weapon2.Fire();
            }
            if(!(weapon3 == null)){
                weapon3.Fire();
            }
            //weapon3.Fire();
            if(!(weapon4 == null)){
                weapon4.Fire();
            }
            //weapon4.Fire();
        }
        //tracks mouse location
        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //move character
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //aiming
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
}
