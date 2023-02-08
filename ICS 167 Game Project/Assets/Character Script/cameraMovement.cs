using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;
    
    public Vector3 newPosition;
    // Start is called before the first frame update
    void Start()
    {
        newPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    void move(){
        if(Input.GetKey(KeyCode.UpArrow)){
            newPosition += (transform.up * movementSpeed);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            newPosition += (transform.right * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            newPosition += (transform.up * -movementSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            newPosition += (transform.right * movementSpeed);
        }

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);

    }
}
