using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kevin Rogan

public class cameraMovement : MonoBehaviour
{
    public float movementSpeed;
    public float movementTime;
    
    public Vector3 newPosition;

    [SerializeField]
    float topLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
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
        if(transform.position.x >= leftLimit){
            newPosition.x=leftLimit;
        }
        else if(transform.position.x <= rightLimit){
            newPosition.x=rightLimit;
        }
        if(transform.position.y >= topLimit){
            newPosition.y=topLimit;
        }
        else if(transform.position.y <= bottomLimit){
            newPosition.y=bottomLimit;
        }
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
    }
    
}
